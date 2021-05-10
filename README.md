# App-Condominio

**Pré-requisitos**:

- .Net Core instalado no seu ambiente de desenvolvimento;
- Ef Core Tools, através do comando: `dotnet tool install --global dotnet-ef`

Na classe DbAppContext metodo ConfigureDbContext, mudar o host do banco para qual host se encotra seu banco de dados

Vamos criar as migrações (initial) do banco de dados

dotnet ef migrations add Initial --output-dir Migrations/PgSql --project App.Infra.Data --context DbAppContext

Depois rodar o comando para utilizar as migrações criadas 

dotnet ef database update --project App.Infra.Data --context DbAppContext

Na raiz da solução, executamos o seguinte command:

- `$ cd App.Api`
- `$ dotnet run`

Para acessar a API, basta copiar o link abaixo e colar no navegador de sua preferência:
`http://localhost:5001`

Para uma melhor visualização da API pode se utilizar o swagger acessando
`https://localhost:5001/swagger/index.html`