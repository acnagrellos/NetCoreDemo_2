# Temario

1. Introducción a .NET Core
    * 1.1 Por qué .NET Core?
    * 1.2 Instalación del SDK de .NET Core
    * 1.2 Aplicación de consola en .NET Core
    * 1.3 dotnet CLI
    * 1.4 Ejercicios dotnet cli
    * 1.5 Deployments
2. Fundamentos de C#
    * 2.1 Clases y objetos (propiedades y funciones)
    * 2.2 Interfaces
    * 2.3 Métodos de extensión
    * 2.4 Atributos en C#
    * 2.5 Paquetes Nuget
    * 2.6 Async/await 
3. HTTP API REST
    * 3.1 ¿Qué es un API REST?
    * 3.2 URI y QueryString.
    * 3.3 Operaciones con un API (Get, Post, Put, Delete)
    * 3.6 Códigos de respuesta
    * 3.4 Body en Put y Post.
    * 3.5 Cabeceras (Content-type, authentication, etc.)
    * 3.7 Buenas prácticas de nombrado.
    * 3.8 HATEOAS
4. Fundamentos de .NET Core (Todo sin controladores, solo con Startup)
    * 4.1 Hello World en .NET Core
    * 4.2 Project structure (global.json, launchSettings.json, hosting.json, wwwroot)
    * 4.3 Variables de Entorno
    * 4.4 Startup (ConfigureServices y Configure)
    * 4.5 Logging (LoggerFactory, ILogger) 
    * 4.6 Appsettings y AppSecrets
    * 4.7 Middlewares
5. ASP.NET MVC Core
    * 5.1 Patron MVC
    * 5.2 Controladores (ApiController)
    * 5.3 Enrutado
    * 5.4 Versionado
    * 5.5 Model Binding
    * 5.6 Actions Result and Result Types
    * 5.7 DTOs and Fluent Validation
    * 5.8 Gestion de errores (ProblemDetails)
    * 5.9 Swagger
    * 5.10 Postman
    * 5.11 Inyección de dependencias en un Controlador
6. Capa de datos (EF Core and Dapper)
    * 6.1 EF Core
        * 6.1.1 ¿Que es un ORM?
        * 6.1.2 Configuracion y migracion de la base de datos
        * 6.1.3 Objetos de dominio (Mapeo con DTOs)
        * 6.1.4 EF migrations and tooling
        * 6.1.5 LinQ. (IQueryable vs IEnumerable, Lazy loading...)
    * 6.2 Dapper
        * 6.2.1 MicroORM Dapper.NET
        * 6.2.2 Configuracion de DapperQueryBase
        * 6.2.3 Ejemplos
    * 6.3 Separacion entre Commands and Queries
        * 6.3.1 Integración de Dapper y EF en la solución con los controladores.
