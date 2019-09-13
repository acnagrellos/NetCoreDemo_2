1. Con la nueva estructura de Proyecto crea la configuración de un contexto de EntityFramework. Para ello añade solo el cliente a la base de datos. Ponle en el mapping de nombre de la tabla Customers.
2. Cambia el servicio de memoria que se estaba llamando por uno que use el contexto de Entity Framework y traiga los datos de la base de datos.
3. Valida que el nombre, apellidos y el email del cliente sea obligatorio. ¿Que pasa si en Swagger no los pasas? Válida que si no viene el email no se puede añadir el cliente y ponle el código de error correspondiente en el controlador.
4. Haz lo mismo que con la tabla Clientes y añade a la migracion la tabla Productos. Para ello comenta la lista que tiene asociada de 
```csharp
// public ICollection<OrderDetail> OrderDetails { get; set; }
```
5. Añade ahora a la migracion la tabla Order sin los Tickets ni los OrdersDetail. Para ello comenta sus propiedades correspondientes.
6. Añade a la base de datos tanto los Tickets como los OrderDetails. Comprueba que todo esta funcionando bien.
7. Crea una llamada que haga que un usuario pueda guardar un pedido. Crea otra llamada que haga que un usuario pueda pagar un pedido. Hazlo todo con un nuevo servicio que vaya a base de datos y lo deje todo registrado.
