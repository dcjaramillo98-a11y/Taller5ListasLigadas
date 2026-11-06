using System;
using Taller5ListasLigadas.Estructuras;

namespace Taller5ListasLigadas;

internal class Program
{
    static void Main(string[] args)
    {
        // PRUEBA DE GENERICIDAD CON CADENAS DE TEXTO.
        Console.WriteLine("======================================");
        Console.WriteLine("   PRUEBA DE LISTA DOBLE GENERICA");
        Console.WriteLine("======================================");

        ListaDoble<string> pruebaColores = new ListaDoble<string>();

        pruebaColores.Insertar("Blanco");
        pruebaColores.Insertar("Azul");
        pruebaColores.Insertar("Amarillo");
        pruebaColores.Insertar("Verde");
        pruebaColores.Insertar("Negro");

        Console.WriteLine("\nElementos ingresados:");
        Console.WriteLine("Blanco, Azul, Amarillo, Verde, Negro");

        Console.WriteLine("\nLista ordenada ascendentemente:");
        Console.WriteLine(string.Join(" <-> ", pruebaColores.RecorrerAdelante()));

        Console.WriteLine("\nPresione una tecla para continuar...");
        Console.ReadKey(true);

        // MENU PRINCIPAL CON NUMEROS ENTEROS.
        ListaDoble<int> lista = new ListaDoble<int>();

        int opcion;

        do
        {
            Console.Clear();

            Console.WriteLine("======================================");
            Console.WriteLine("       TALLER 5 - LISTAS LIGADAS");
            Console.WriteLine("======================================");
            Console.WriteLine("1. Adicionar");
            Console.WriteLine("2. Mostrar hacia adelante");
            Console.WriteLine("3. Mostrar hacia atras");
            Console.WriteLine("4. Ordenar descendentemente");
            Console.WriteLine("5. Mostrar la(s) moda(s)");
            Console.WriteLine("6. Mostrar grafico");
            Console.WriteLine("7. Existe");
            Console.WriteLine("8. Eliminar una ocurrencia");
            Console.WriteLine("9. Eliminar todas las ocurrencias");
            Console.WriteLine("0. Salir");
            Console.WriteLine("======================================");

            Console.Write("Seleccione una opcion: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Ingrese una opcion valida.");
                Pausar();
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Adicionar(lista);
                    break;

                case 2:
                    MostrarAdelante(lista);
                    break;

                case 3:
                    MostrarAtras(lista);
                    break;

                case 4:
                    lista.OrdenarDescendente();
                    Console.WriteLine("Lista ordenada descendentemente.");
                    MostrarAdelante(lista);
                    break;

                case 5:
                    MostrarModas(lista);
                    break;

                case 6:
                    MostrarGrafico(lista);
                    break;

                case 7:
                    BuscarElemento(lista);
                    break;

                case 8:
                    EliminarUna(lista);
                    break;

                case 9:
                    EliminarTodas(lista);
                    break;

                case 0:
                    Console.WriteLine("Programa finalizado.");
                    break;

                default:
                    Console.WriteLine("Opcion no valida.");
                    break;
            }

            if (opcion != 0)
                Pausar();

        } while (opcion != 0);
    }

    // Opcion 1: adicionar elementos.
    static void Adicionar(ListaDoble<int> lista)
    {
        Console.Write("Ingrese un numero entero: ");

        if (int.TryParse(Console.ReadLine(), out int numero))
        {
            lista.Insertar(numero);

            Console.WriteLine("Elemento agregado correctamente.");
            Console.WriteLine("La lista conserva el orden ascendente.");
        }
        else
        {
            Console.WriteLine("Debe ingresar un numero entero valido.");
        }
    }

    // Opcion 2: mostrar hacia adelante.
    static void MostrarAdelante(ListaDoble<int> lista)
    {
        Console.WriteLine("\nRECORRIDO HACIA ADELANTE:");

        if (lista.EstaVacia)
        {
            Console.WriteLine("La lista esta vacia.");
            return;
        }

        Console.WriteLine(
            string.Join(" <-> ", lista.RecorrerAdelante()));

        Console.WriteLine("Cantidad de elementos: " + lista.Cantidad);
    }

    // Opcion 3: mostrar hacia atras.
    static void MostrarAtras(ListaDoble<int> lista)
    {
        Console.WriteLine("\nRECORRIDO HACIA ATRAS:");

        if (lista.EstaVacia)
        {
            Console.WriteLine("La lista esta vacia.");
            return;
        }

        Console.WriteLine(
            string.Join(" <-> ", lista.RecorrerAtras()));
    }

    // Opcion 5: mostrar las modas.
    static void MostrarModas(ListaDoble<int> lista)
    {
        Console.WriteLine("\nMODA(S) DE LA LISTA:");

        if (lista.EstaVacia)
        {
            Console.WriteLine("No hay elementos para calcular la moda.");
            return;
        }

        var modas = lista.ObtenerModas();

        if (modas.Count == 1)
        {
            Console.WriteLine("La moda es: " + modas[0]);
        }
        else
        {
            Console.WriteLine("Las modas son: " + string.Join(", ", modas));
        }
    }

    // Opcion 6: mostrar grafico de ocurrencias.
    static void MostrarGrafico(ListaDoble<int> lista)
    {
        Console.WriteLine("\nGRAFICO DE OCURRENCIAS:");

        if (lista.EstaVacia)
        {
            Console.WriteLine("La lista esta vacia.");
            return;
        }

        var frecuencias = lista.ObtenerFrecuencias();

        foreach (var elemento in frecuencias)
        {
            Console.WriteLine(
                $"{elemento.Elemento} {new string('*', elemento.Ocurrencias)}");
        }
    }

    // Opcion 7: consultar si existe un elemento.
    static void BuscarElemento(ListaDoble<int> lista)
    {
        Console.Write("\nIngrese el numero que desea buscar: ");

        if (int.TryParse(Console.ReadLine(), out int numero))
        {
            if (lista.Existe(numero))
            {
                Console.WriteLine(
                    $"El elemento {numero} si existe en la lista.");
            }
            else
            {
                Console.WriteLine(
                    $"El elemento {numero} no existe en la lista.");
            }
        }
        else
        {
            Console.WriteLine("Numero invalido.");
        }
    }

    // Opcion 8: eliminar una ocurrencia.
    static void EliminarUna(ListaDoble<int> lista)
    {
        Console.Write("\nIngrese el numero que desea eliminar: ");

        if (int.TryParse(Console.ReadLine(), out int numero))
        {
            if (lista.EliminarUnaOcurrencia(numero))
            {
                Console.WriteLine(
                    "Se elimino una ocurrencia del elemento.");
            }
            else
            {
                Console.WriteLine(
                    "El elemento no se encuentra en la lista.");
            }
        }
        else
        {
            Console.WriteLine("Numero invalido.");
        }
    }

    // Opcion 9: eliminar todas las ocurrencias.
    static void EliminarTodas(ListaDoble<int> lista)
    {
        Console.Write("\nIngrese el numero que desea eliminar: ");

        if (int.TryParse(Console.ReadLine(), out int numero))
        {
            int cantidad = lista.EliminarTodasLasOcurrencias(numero);

            Console.WriteLine(
                $"Se eliminaron {cantidad} ocurrencia(s) del elemento {numero}.");
        }
        else
        {
            Console.WriteLine("Numero invalido.");
        }
    }

    // Pausa para que el usuario pueda leer los resultados.
    static void Pausar()
    {
        Console.WriteLine("\nPresione una tecla para continuar...");
        Console.ReadKey(true);
    }
}