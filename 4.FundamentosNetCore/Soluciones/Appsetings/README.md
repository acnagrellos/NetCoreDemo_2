1. Pon en el fichero AppSettings los valores:

```
{
  "ConnectionString": "production",
}
```

Y crea un servicio que sea IMiServicio que devuelva un string con el valor: "Mi cadena de conexion es: {MiCadena}" que se corresponda con el valor de las settings. Esto devuelvelo en una llamada "/settings" con el Map.