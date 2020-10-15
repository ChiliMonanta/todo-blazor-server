CREATE SEQUENCE todos.todoitems_id_seq
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 9223372036854775807
    CACHE 1;

ALTER SEQUENCE todos.todoitems_id_seq
    OWNER TO postgres;

CREATE TABLE todos.todoitems
(
    id bigint NOT NULL DEFAULT nextval('todos.todoitems_id_seq'::regclass),
    name text COLLATE pg_catalog."default",
    description text COLLATE pg_catalog."default",
    todolist_id bigint NOT NULL,
    CONSTRAINT todoitems_pkey PRIMARY KEY (id),
    CONSTRAINT todolist FOREIGN KEY (todolist_id)
        REFERENCES todos.todolist (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)

TABLESPACE pg_default;
ALTER TABLE todos.todoitems OWNER to postgres;
GRANT DELETE, UPDATE, INSERT, SELECT ON TABLE todos.todoitems TO webuser;
