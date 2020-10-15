# Example of a Todo management system
An example of a simple todo management system.
- Add/remove todo lists
- Add/remove todo in a list
- Move a todo to another list

Based on a postgresql database

How to run (localhost):
```
source envsetup.sh
d-up
cd server-app/
dotnet run
```

For localhost the pgadmin4 is bundled in the docker compose file and can be accessed on http://localhost:5050/
For pgadmin the default user=a@a.org and password=pass
For the database the user=postgres, password=pass and the postgres database=todos

Environment variables if you want to change the default:
- POSTGRES_USER
- POSTGRES_PASSWORD
- PGADMIN_DEFAULT_EMAIL
- PGADMIN_DEFAULT_PASSWORD
- PGADMIN_PORT
- POSTGRES_DATABASE