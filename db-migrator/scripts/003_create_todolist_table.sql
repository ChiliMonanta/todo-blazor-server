CREATE SEQUENCE todos.todolist_id_seq
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 9223372036854775807
    CACHE 1;

ALTER SEQUENCE todos.todolist_id_seq OWNER TO postgres;

CREATE TABLE todos.todolist
(
    id bigint NOT NULL DEFAULT nextval('todos.todolist_id_seq'::regclass),
    name text COLLATE pg_catalog."default",
    CONSTRAINT todolist_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE todos.todolist OWNER to postgres;

GRANT ALL ON TABLE todos.todolist TO postgres;
GRANT DELETE, UPDATE, INSERT, SELECT ON TABLE todos.todolist TO webuser;