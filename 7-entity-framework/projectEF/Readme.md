#### Crear base de datos
```shell
$ docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Santi1026!" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
```

#### conectarse a DB 
- dominio: localhost
- usuario: sa
- password: Santi1026!