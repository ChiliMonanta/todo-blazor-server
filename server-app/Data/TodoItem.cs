public class TodoItem
{
    public virtual long id { get; set; }
    public virtual string name { get; set; }
    public virtual string description { get; set; }
    public virtual TodoList todoList { get; set; }

    public static TodoItem from(TodoItem todo)
    {
        return new TodoItem()
        {
            id = todo.id,
            name = todo.name,
            description = todo.description,
            todoList = todo.todoList
        };
    }
}