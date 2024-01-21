Este repositorio contiene un proyecto en C# utilizando la API de la Nasa.
Se utiliza un endpoint que recibe un número de días entre 1 y 7 y que devuelva un listado en formato json con el top 3 de asteroides más grandes con potencial 
riesgo de impacto en el planeta Tierra entre el día de hoy y la fecha obtenida de sumar a la fecha de hoy el número de días introducido como parámetro.

- .NET 6
- Aquitectura Domain Driven Desingn (DDD).
- Principios SOLID y buenas prácticas de código.
- Test unitarios con xUnit y Moq
- Migración mediante EntityFramework
  

NOTA:
A efectos prácticos es mejor utilzar un Handler ya que en DDD es donde debe ir el negocio expecífico y en el Service el negocio general.
Se ha optado por hacer la lógica de negocio en el Service en vez de en un Handler porque es un proyecto pequeño y el Handler supondría una capa más.

