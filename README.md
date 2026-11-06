# Taller 5 - Listas Doblemente Ligadas

**Estudiante:** Diana Carolina Jaramillo González  
**Asignatura:** Estructura de Datos y Laboratorio  
**Programa:** Tecnología en Diseño y Programación de Soluciones de Software  
**Institución:** Instituto Tecnológico Metropolitano (ITM)

## Descripción

Este proyecto desarrolla una estructura de datos de lista doblemente ligada genérica en C#, utilizando nodos que contienen referencias al elemento anterior y al siguiente.

La implementación permite almacenar elementos, mantenerlos ordenados y realizar diferentes operaciones sobre la lista.

## Funcionalidades

1. Adicionar elementos manteniendo el orden ascendente.
2. Mostrar la lista hacia adelante.
3. Mostrar la lista hacia atrás.
4. Ordenar la lista descendentemente.
5. Calcular y mostrar las modas, incluyendo los empates.
6. Generar un gráfico de frecuencias mediante asteriscos.
7. Consultar si un elemento existe.
8. Eliminar una ocurrencia de un elemento.
9. Eliminar todas las ocurrencias de un elemento.

## Implementación

El proyecto utiliza:

- Lenguaje C#.
- Programación genérica mediante `Nodo<T>` y `ListaDoble<T>`.
- Referencias `Anterior` y `Siguiente`.
- Control de cantidad de elementos.
- Menú interactivo por consola.

## Ejecución

1. Abrir `Taller5ListasLigadas.slnx` en Visual Studio.
2. Compilar el proyecto mediante **Build > Build Solution**.
3. Ejecutar el programa.
4. Utilizar las opciones del menú para probar las operaciones de la lista.

## Pruebas realizadas

Se verificaron operaciones de inserción, recorridos en ambos sentidos, ordenamiento, cálculo de modas, frecuencias, búsqueda y eliminación.

También se probaron casos especiales como listas vacías, elementos repetidos, eliminación de los extremos y reutilización de la lista después de quedar vacía.
