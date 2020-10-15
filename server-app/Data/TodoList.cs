using System.Collections.Generic;

public class TodoList
{
    public virtual long id { get; set; }
    public virtual string name { get; set; }
    public virtual IList<TodoItem> todoItems { get; set; }
}