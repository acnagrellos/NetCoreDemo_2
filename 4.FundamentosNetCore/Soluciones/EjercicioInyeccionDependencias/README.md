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

Para resolver este problema tenemos que jugar con el ciclo de vida de los servicios que se inyectan en la inyección de dependencias. El servicio ```RandomNumberService``` creará un número aleatorio con ayuda de la clase ```Random``` de C#:

```csharp
public class RandomNumberService
{
    private int _randomNumber;
    public RandomNumberService()
    {
        var random = new Random();
        _randomNumber = random.Next(100);
    }

    public int GetRandomNumber()
    {
        return _randomNumber;
    }
}
```

Así en los diferentes casos del ejercicio usaremos el ciclo de vida correspondiente del servicio RandomNumber. Estos son los tres casos para inyectar un servicio:

* __Trasient__: siempre se hace una instancia nueva del objeto.
* __Scoped__: se hace una instancia nueva del objeto por llamada.
* __Singleton__: solo se crea la instancia la primera vez. Las demás se usa la misma instancia. 

Finalmente en la clase Startup inyectamos todos los casos de los servicios y ponemos los Maps en el método ```Configure``` del ```Staptup```.

```csharp
using DIMap.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DIMap
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRandomNumberService, RandomNumberService>();
            services.AddScoped<IRandomNumberServiceScoped, RandomNumberService>();
            services.AddSingleton<IRandomNumberServiceSingleton, RandomNumberService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Map("/equals", appbuilder =>
                {
                    appbuilder.Run(async (context) =>
                    {
                        var randomService = context.RequestServices.GetService(typeof(IRandomNumberServiceSingleton)) as IRandomNumberServiceSingleton;
                        var randomService2 = context.RequestServices.GetService(typeof(IRandomNumberServiceSingleton)) as IRandomNumberServiceSingleton;
                        await context.Response.WriteAsync($"RandomNumber1: {randomService.GetRandomNumber()}. RandomNumber2: {randomService2.GetRandomNumber()}");
                    });
                })
                .Map("/different", appbuilder =>
                {
                    appbuilder.Run(async (context) =>
                    {
                        var randomService = context.RequestServices.GetService(typeof(IRandomNumberService)) as IRandomNumberService;
                        var randomService2 = context.RequestServices.GetService(typeof(IRandomNumberService)) as IRandomNumberService;
                        await context.Response.WriteAsync($"RandomNumber1: {randomService.GetRandomNumber()}. RandomNumber2: {randomService2.GetRandomNumber()}");
                    });
                })
                .Run(async (context) =>
                {
                    var randomService = context.RequestServices.GetService(typeof(IRandomNumberServiceScoped)) as IRandomNumberServiceScoped;
                    var randomService2 = context.RequestServices.GetService(typeof(IRandomNumberServiceScoped)) as IRandomNumberServiceScoped;
                    await context.Response.WriteAsync($"RandomNumber1: {randomService.GetRandomNumber()}. RandomNumber2: {randomService2.GetRandomNumber()}");
                });
        }
    }
}
```