using FluentNHibernate.Mapping;

public class TodoListMap : ClassMap<TodoList>
{
    public TodoListMap()
    {
        Schema("todos");
        Table("todos.todolist");
        Id(x => x.id)
            .Column("id")
            .UnsavedValue(0)
            .Not.Nullable()
            .GeneratedBy.SeqHiLo("todolist_id_seq", "1000");
        Map(x => x.name).Column("name");
        HasMany(x => x.todoItems)
            .LazyLoad()
            .Inverse();
    }
}