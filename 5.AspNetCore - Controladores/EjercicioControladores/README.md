1. Crea un controlador de Clientes. Los clientes tendrán los campos Id, Dni, Nombre, Apellidos, Edad, Genero, Email. Añade cuatro casos de ejemplo a la lista por defecto. En tu controlador crea endpoints para poder listar, editar, crear y borrar un cliente. Para hacer esto crea un servicio que sea singleton y tenga una lista de clientes como variable privada con la que jugar.
2. Añade un campo al cliente que sea FechaModificacion. No devuelvas ese campo en el API.
3. Añade en el appsettings el tamaño de pagina que quiere devolver el cliente. Crea un nuevo endpoint que sea /customers/bypage en el cual se pase la página que se quiere y devuelva esa página utilizando el tamaño de página del appsettings.
4. Añade a la llamada de la lista el numero de clientes actuales para que el cliente pueda saber la cantidad de paginas que hay.
5. Usa el logger para logear cuando se borra un usuario como warning.
6. Cuando se consulte un usuario que no está en el sistema en el GET de un usuario con id, devuelve un 404.
7. Devuelve un 201 junto con el lugar donde puedes encontrar el usuario en la creación. Mira el método CreatedAt.
8. Crea una librería de clases. Mete en ella todo lo relacionado con los servicios, para ello llévate el interfaz de los servicios que tengas y sus modelos. Referenciala desde tu proyecto destino y haz que todo funcione igual que antes.

