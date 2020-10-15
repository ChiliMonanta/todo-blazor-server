using System.Linq;
using System.Threading.Tasks;
using NHibernate;

public class TodoService : ITodoService
{
    private readonly ISession session;
 
    public TodoService(ISession session)
    {
        this.session = session;
    }
 
    public IQueryable<TodoList> TodoLists =>session.Query<TodoList>().OrderBy(x => x.name);
 
    public async Task<TodoList> GetTodoList(long id) => await session.GetAsync<TodoList>(id);

    public async Task<TodoItem> GetTodo(long id) => await session.GetAsync<TodoItem>(id);

    public ITransaction BeginTransaction() => session.BeginTransaction();
 
    public async Task SaveTodoListAsync(TodoList todoList)
    {
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