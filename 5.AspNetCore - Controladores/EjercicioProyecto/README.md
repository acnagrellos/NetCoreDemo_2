Coge el proyecto de OrdersApp situado en la sección ASP.NET Core Controladores.

1. Añadir al proyecto los endpoints correspondientes para poder consultar una lista de productos con un servicio en memoria. Tiene que ser equivalente al de Clientes. Un Producto tendrá las propiedades de: Id, Name, Description, Price.
2. Añadir al Producto un campo LastUpdate que se actualice cuando se cambie el objeto. Este campo no se debería enviar al API.
3. Añadir un middleware para capturar todos los errores que se produzcan en nuestro API y devolver el código de error correspondiente.
