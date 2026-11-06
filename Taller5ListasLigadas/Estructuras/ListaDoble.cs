using System;
using System.Collections.Generic;

namespace Taller5ListasLigadas.Estructuras;

public class Nodo<T>
{
    public T Dato { get; set; }
    public Nodo<T>? Anterior { get; set; }
    public Nodo<T>? Siguiente { get; set; }

    public Nodo(T dato)
    {
        Dato = dato;
        Anterior = null;
        Siguiente = null;
    }
}

public class ListaDoble<T> where T : IComparable<T>
{
    private Nodo<T>? cabeza;
    private Nodo<T>? cola;

    private bool estaOrdenDescendente = false;

    public int Cantidad { get; private set; }

    public bool EstaVacia => cabeza == null;

    // Inserta un elemento manteniendo el orden ascendente.
    public void Insertar(T dato)
    {
        // Si la lista estaba descendente, recupera el orden ascendente.
        OrdenarAscendente();

        Nodo<T> nuevo = new Nodo<T>(dato);

        // Caso 1: la lista está vacía.
        if (EstaVacia)
        {
            cabeza = nuevo;
            cola = nuevo;
        }
        // Caso 2: el elemento va al principio.
        else if (dato.CompareTo(cabeza!.Dato) <= 0)
        {
            nuevo.Siguiente = cabeza;
            cabeza.Anterior = nuevo;
            cabeza = nuevo;
        }
        // Caso 3: el elemento va al final.
        else if (dato.CompareTo(cola!.Dato) >= 0)
        {
            nuevo.Anterior = cola;
            cola.Siguiente = nuevo;
            cola = nuevo;
        }
        // Caso 4: el elemento va en medio.
        else
        {
            Nodo<T> actual = cabeza;

            while (actual.Siguiente != null &&
                   dato.CompareTo(actual.Siguiente.Dato) > 0)
            {
                actual = actual.Siguiente;
            }

            nuevo.Siguiente = actual.Siguiente;
            nuevo.Anterior = actual;

            actual.Siguiente!.Anterior = nuevo;
            actual.Siguiente = nuevo;
        }

        Cantidad++;
    }

    // Recorrido desde el primer nodo hasta el último.
    public IEnumerable<T> RecorrerAdelante()
    {
        Nodo<T>? actual = cabeza;

        while (actual != null)
        {
            yield return actual.Dato;
            actual = actual.Siguiente;
        }
    }

    // Recorrido desde el último nodo hasta el primero.
    public IEnumerable<T> RecorrerAtras()
    {
        Nodo<T>? actual = cola;

        while (actual != null)
        {
            yield return actual.Dato;
            actual = actual.Anterior;
        }
    }

    // Invierte los enlaces de la lista.
    private void InvertirEnlaces()
    {
        Nodo<T>? actual = cabeza;

        while (actual != null)
        {
            Nodo<T>? temporal = actual.Anterior;

            actual.Anterior = actual.Siguiente;
            actual.Siguiente = temporal;

            actual = actual.Anterior;
        }

        Nodo<T>? auxiliar = cabeza;
        cabeza = cola;
        cola = auxiliar;
    }

    // Ordena la lista descendentemente.
    public void OrdenarDescendente()
    {
        if (!estaOrdenDescendente)
        {
            InvertirEnlaces();
            estaOrdenDescendente = true;
        }
    }

    // Recupera el orden ascendente.
    private void OrdenarAscendente()
    {
        if (estaOrdenDescendente)
        {
            InvertirEnlaces();
            estaOrdenDescendente = false;
        }
    }

    // Comprueba si un elemento existe.
    public bool Existe(T dato)
    {
        Nodo<T>? actual = cabeza;

        while (actual != null)
        {
            if (actual.Dato.CompareTo(dato) == 0)
                return true;

            actual = actual.Siguiente;
        }

        return false;
    }

    // Elimina la primera ocurrencia encontrada.
    public bool EliminarUnaOcurrencia(T dato)
    {
        Nodo<T>? actual = cabeza;

        while (actual != null)
        {
            if (actual.Dato.CompareTo(dato) == 0)
            {
                if (actual.Anterior != null)
                    actual.Anterior.Siguiente = actual.Siguiente;
                else
                    cabeza = actual.Siguiente;

                if (actual.Siguiente != null)
                    actual.Siguiente.Anterior = actual.Anterior;
                else
                    cola = actual.Anterior;

                Cantidad--;
                return true;
            }

            actual = actual.Siguiente;
        }

        return false;
    }

    // Elimina todas las ocurrencias de un elemento.
    public int EliminarTodasLasOcurrencias(T dato)
    {
        int eliminados = 0;
        Nodo<T>? actual = cabeza;

        while (actual != null)
        {
            Nodo<T>? siguiente = actual.Siguiente;

            if (actual.Dato.CompareTo(dato) == 0)
            {
                if (actual.Anterior != null)
                    actual.Anterior.Siguiente = actual.Siguiente;
                else
                    cabeza = actual.Siguiente;

                if (actual.Siguiente != null)
                    actual.Siguiente.Anterior = actual.Anterior;
                else
                    cola = actual.Anterior;

                Cantidad--;
                eliminados++;
            }

            actual = siguiente;
        }

        return eliminados;
    }

    // Obtiene las frecuencias de cada elemento.
    public List<(T Elemento, int Ocurrencias)> ObtenerFrecuencias()
    {
        var frecuencias = new List<(T Elemento, int Ocurrencias)>();

        foreach (T dato in RecorrerAdelante())
        {
            int posicion = frecuencias.FindIndex(
                x => x.Elemento.CompareTo(dato) == 0);

            if (posicion == -1)
            {
                frecuencias.Add((dato, 1));
            }
            else
            {
                var elemento = frecuencias[posicion];

                frecuencias[posicion] =
                    (elemento.Elemento, elemento.Ocurrencias + 1);
            }
        }

        return frecuencias;
    }

    // Obtiene todas las modas, incluyendo los empates.
    public List<T> ObtenerModas()
    {
        var frecuencias = ObtenerFrecuencias();
        var modas = new List<T>();

        if (frecuencias.Count == 0)
            return modas;

        int mayorFrecuencia = 0;

        foreach (var elemento in frecuencias)
        {
            if (elemento.Ocurrencias > mayorFrecuencia)
                mayorFrecuencia = elemento.Ocurrencias;
        }

        foreach (var elemento in frecuencias)
        {
            if (elemento.Ocurrencias == mayorFrecuencia)
                modas.Add(elemento.Elemento);
        }

        return modas;
    }
}