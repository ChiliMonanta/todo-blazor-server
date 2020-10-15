using System.Linq;
using System.Threading.Tasks;
using NHibernate;

public interface ITodoService
{
    ITransaction BeginTransaction();
    Task SaveTodoListAsync(TodoList todoList);
    Task SaveTodoAsync(TodoItem todo);
    Task DeleteTodoListAsync(TodoList todoList);
    Task DeleteTodoAsync(TodoItem todo);
 
    IQueryable<TodoList> TodoLists { get; }
    Task<TodoList> GetTodoList(long id);
    Task<TodoItem> GetTodo(long id);
}