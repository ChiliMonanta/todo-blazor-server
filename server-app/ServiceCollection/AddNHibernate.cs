using Microsoft.Extensions.DependencyInjection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.SqlCommand;
using Serilog;

public static class NHibernateExtensions
{
    public static IServiceCollection AddNHibernate(this IServiceCollection services, string connectionString)
    {
        var sessionFactory = Fluently.Configure()
            .Database(PostgreSQLConfiguration.Standard.ConnectionString(connectionString))
            .Mappings(m =>
                m.FluentMappings.AddFromAssemblyOf<TodoListMap>())
            //.ExposeConfiguration(cfg => { new SchemaExport(cfg).Create(false, true); })
            .BuildSessionFactory();


        services.AddSingleton<ISessionFactory>(sessionFactory);
        services.AddTransient<ISession>(factory =>
        {
            ISession session;
#if(DEBUG)
            session = sessionFactory.WithOptions()
                .Interceptor(new SqlDebugOutputInterceptor()).OpenSession();
#else
            session = sessionFactory.OpenSession();
#endif
            session.FlushMode = FlushMode.Commit;
            return session;
        });
        services.AddTransient<ITodoService, TodoService>();

        return services;
    }

    public class SqlDebugOutputInterceptor : EmptyInterceptor
    {
        public override SqlString OnPrepareStatement(SqlString sql)
        {
            Log.Debug($"NHibernate Sql: {sql}");
            return base.OnPrepareStatement(sql);
        }
    }
}