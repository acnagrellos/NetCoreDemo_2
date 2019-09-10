1. Inyección de dependencias.

Crea un API que usando Map devuelva:

* en la llamada __/equals__: dos números siempre iguales usando dos servicios diferentes.
* en la llamada __/different__: dos números siempre distintos usando diferentes servicios.
* en la llamada por defecto dos números siempre iguales solo por llamada usando diferentes servicios.

Para ello crea dos servicios IMiServicio y IRandomNumber. IMiServicio contendrá una instancia de IRandomNumber. Cada Map tendrá la clase diferente. Usa la clase Random para generar números aleatorios.