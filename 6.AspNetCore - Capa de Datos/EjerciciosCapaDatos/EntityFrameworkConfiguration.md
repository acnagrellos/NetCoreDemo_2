Para configurar Entity Framework:

1. Añade los paquetes nuget a la solucion de data de: Microsoft.EntityFrameworkCore y Microsoft.EntityFrameworkCore.SqlServer
2. Crea un objeto DbContext dentro de la solución.
3. Dentro de este objeto DbContext añade el correspondiente DbSet del Cliente: 
```csharp
    public DbSet<Client> Clients { get; set; }
```
4. Añade una clase de Mappings para el cliente que cumpla la interfaz ```IEntityTypeConfiguration<Client>```.
5. Añade estos Mappings al contexto de EntityFramework sobreescribiendo la función: OnModelCreating
```csharp
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientMapping());

            base.OnModelCreating(modelBuilder);
        }
```
6. Añade tu contexto en la clase Startup. Recuerda añadir las settings antes. Para ello usa:
```
    services.AddDbContext<OrdersAppContext>(options =>
    {
        options.UseSqlServer(configuration.Get<ConfigurationSettings>().ConnectionStrings.DefaultConnection);
    })
```
7. Crea una migration con el comando add-migration "nombremigracion". Hazlo en la consola de Package Manager Console.
8. Haz un Update de la base de datos con el comando update-database
9. Si usas SQLEXPRESS puedes usar esta connectionstring:
```json
  "ConnectionStrings": {
    "DefaultConnection": "Server=LOCALHOST\\SQLEXPRESS;Database=ordersapp;Trusted_Connection=True;"
  },
```