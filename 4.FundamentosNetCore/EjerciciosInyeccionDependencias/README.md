1. Inyección de dependencias.

Crea un API que usando Map devuelva:

* en la llamada __/equals__: dos números siempre iguales usando un servicio dos veces con la clase Random.
* en la llamada __/different__: dos números siempre distintos usando diferentes un servicio dos veces con la clase Random.
* en la llamada por defecto dos números siempre iguales solo por llamada usando un servicio dos veces con la clase Random.

Sigue esta estructura en el Configure de la clase Startup:

```
app.Map("/equals", appbuilder =>
    {
        appbuilder.Run(async (context) =>
        {
            // Forma de obtener dos veces el mismo servicio
            var miServicio1 = context.RequestServices.GetService(typeof(IMiServicio)) as IMiServicio;
            var miServicio2 = context.RequestServices.GetService(typeof(IMiServicio)) as IMiServicio;
            await context.Response.WriteAsync($"Numero1: {miServicio1.GetRandomNumber()}. Numero2: {miServicio1.GetRandomNumber()}");
        });
    })
```