using FluentNHibernate.Mapping;

public class TodoItemMap : ClassMap<TodoItem>
{
    public TodoItemMap()
    {
        Schema("todos");
        Table("todoitems");
        Id(x => x.id)
            .Column("id")
            .UnsavedValue(0)
            .Not.Nullable()
            .GeneratedBy.SeqHiLo("todoitems_id_seq", "1000");
        Map(x => x.name).Column("name");
        Map(x => x.description).Column("description");
        References(x => x.todoList)
            .Cascade.None()
            .LazyLoad()
            .Columns("todolist_id");
    }
}