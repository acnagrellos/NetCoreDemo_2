1. Crear un proyecto de consola desde un cmd

```bash
dotnet sln new -n ejemplo
```

2. Ejecuta la carpeta Ejercicio 2 de dentro del repo. Apunta el resultado

```bash
dotnet ejercicio2/1.DotNetCli.dll
```
El resultado es: Well done!

3. Sin usar dotnet run, crea los ejecutable y ejecuta la carpeta del Ejercicio3

```bash
dotnet build ejercicio3/ejercicio3.csproj
dotnet ejercicio3/bin/Debug/netcoreapp2.2/ejercicio3.dll
```

4. Elimina el contenido de la carpeta bin del proyecto del Ejercicio3.

```bash
dotnet clean ejercicio3/ejercicio3.csproj
```

5. Crea un archivo de solución sln y luego añade un proyecto de consola a éste. Después compila la solucion, que los binarios estén en una carpeta dist y ejecuta la dll generada.

```bash
dotnet new sln -n ejercicio5
dotnet new console -n ejercicio5.console
dotnet sln ejercicio5.sln add ejercicio5.console/ejercicio5.console.csproj
dotnet build ejercicio5.sln -o dist
dotnet ejercicio5.console/bin/Debug/netcoreapp2.2/ejercicio5.console.dll
```

6. Arregla la solución de la carpeta ejercicio6. No compila.

El problema de la solución del ejercicio6 es que tiene añadido un proyecto que no existe. Esto lo podemos ver con el comando:

```bash
dotnet sln ejercicio6.sln list
```

Ahí podemos ver que el proyecto añadido que tiene se llama ejercicio6temp.csproj. Para dejarlo todo funcionando correctamente podemos eliminar este proyecto y añadir el proyecto ejercicio6.csproj

```bash
dotnet sln ejercicio6.sln remove ejercicio6temp/ejercicio6temp.csproj
dotnet sln ejercicio6.sln add ejercicio6/ejercicio6.csproj
```

7. Crea un archivo de solución sln. Crea una librería de clases netstandard y otra netcore. Añade las dos a la solucion. Crea un proyecto de consola y añadelo también. Lista todos los proyectos.

```bash
dotnet new sln -n ejercicio7.sln
dotnet new classlib -n netstandardlib
dotnet new classlib -f netcoreapp2.2 -n netcorelib
dotnet sln ejercicio7.sln add netstandardlib/netstandardlib.csproj
dotnet sln ejercicio7.sln add netcorelib/netcorelib.csproj
dotnet new console -n console
dotnet sln ejercicio7.sln add console/console.csproj
dotnet sln ejercicio7.sln list
```

Cuidado para añadir la librería de .netcore, ya que en el parámetro -f hay que añadir justo la versión de .netcore que tengamos instalada.

8. Enlazada el proyecto de consola del ejercicio anterior con la librería de clases netstandard.

```bash
dotnet add console/console.csproj reference netstandardlib/netstandardlib.csproj
```

9. Crea un proyecto de solución llamada MiProyecto. Crea un proyecto de consola llamado MiConsola. Crea una librería de clases llamada MiLibreria. Añade los dos proyectos a la solucion. Enlazada el proyecto MiLibreria como dependencia de MiConsola. Lista las referencias de MiConsola.

```bash
dotnet new sln -n MiProyecto
dotnet new console -n MiConsola
dotnet new classlib -n MiLibreria
dotnet sln MiProyecto.sln add MiConsola/MiConsole.csproj
dotnet sln MiProyecto.sln add MiLibreria/MiLibreria.csproj
dotnet add MiConsola/MiConsola.csproj reference MiLibreria/MiLibreria.csproj
dotnet list MiConsola/MiConsola.csproj reference
```

10. Arregla el sln de la carpeta ejercicio10.

El problema de la solución del ejercicio 10 es que hay una dependencia circular. Si listamos los proyectos nos sale:

```bash
dotnet sln ejercicio10.sln list
Proyectos
---------
console\console.csproj
MiLibreria\MiLibreria.csproj
MiLibreria2\MiLibreria2.csproj
```

Si vamos a ver las referencias de los demás proyectos veremos que:

```bash
$ dotnet list console/console.csproj reference
Referencias de proyecto
-----------------------
..\MiLibreria\MiLibreria.csproj

$ dotnet list MiLibreria/MiLibreria.csproj reference
Referencias de proyecto
-----------------------
..\MiLibreria2\MiLibreria2.csproj

$ dotnet list MiLibreria2/MiLibreria2.csproj reference
Referencias de proyecto
-----------------------
..\MiLibreria\MiLibreria.csproj
```

Por tanto, la librería MiLibreria llama a Libreria2 y viceversa. Si borramos la dependencia de MiLibreria en MiLibreria2 quedaría todo solucionado:

```bash
$ dotnet remove MiLibreria2/MiLibreria2.csproj reference MiLibreriaMiLibreria.csproj
$ dotnet build ejercicio10.sln
```