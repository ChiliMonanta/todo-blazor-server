using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Microsoft.Extensions.Logging;

public class TodoService : ITodoService
{
    private readonly ISession session;
    private readonly ILogger<TodoService> logger;
 
    public TodoService(ISession session, ILogger<TodoService> logger)
    {
        this.session = session;
        this.logger = logger;
    }
 
    public IQueryable<TodoList> TodoLists =>session.Query<TodoList>().OrderBy(x => x.name);
 
    public async Task<TodoList> GetTodoList(long id) => await session.GetAsync<TodoList>(id);

    public async Task<TodoItem> GetTodo(long id) => await session.GetAsync<TodoItem>(id);

    public ITransaction BeginTransaction() => session.BeginTransaction();
 
    public async Task SaveTodoListAsync(TodoList todoList)
    {
        logger.LogTrace("Save todo");
        await session.SaveOrUpdateAsync(todoList);
    }

    public async Task SaveTodoAsync(TodoItem todo)
    {
        await session.SaveOrUpdateAsync(todo);
    }

    public async Task DeleteTodoListAsync(TodoList todoList)
    {
        await session.DeleteAsync(todoList);
    }

    public async Task DeleteTodoAsync(TodoItem todo)
    {
        await session.DeleteAsync(todo);
    }
}