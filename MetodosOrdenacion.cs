using System;
using System.Diagnostics;
using System.Linq;

namespace ProyectoOrdenacionConsola
{
    public static class OrdenamientoBurbuja
    {
        public static void Ordenar(int[] arreglo)
        {
            int n = arreglo.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (arreglo[j] > arreglo[j + 1])
                        (arreglo[j], arreglo[j + 1]) = (arreglo[j + 1], arreglo[j]);
        }
    }

    public static class OrdenamientoSacudida
    {
        public static void Ordenar(int[] arreglo)
        {
            int izquierda = 0, derecha = arreglo.Length - 1;
            while (izquierda < derecha)
            {
                for (int i = izquierda; i < derecha; i++)
                    if (arreglo[i] > arreglo[i + 1])
                        (arreglo[i], arreglo[i + 1]) = (arreglo[i + 1], arreglo[i]);

                derecha--;

                for (int i = derecha; i > izquierda; i--)
                    if (arreglo[i - 1] > arreglo[i])
                        (arreglo[i - 1], arreglo[i]) = (arreglo[i], arreglo[i - 1]);

                izquierda++;
            }
        }
    }

    public static class OrdenamientoInsercion
    {
        public static void Ordenar(int[] arreglo)
        {
            for (int i = 1; i < arreglo.Length; i++)
            {
                int clave = arreglo[i], j = i - 1;
                while (j >= 0 && arreglo[j] > clave)
                {
                    arreglo[j + 1] = arreglo[j];
                    j--;
                }
                arreglo[j + 1] = clave;
            }
        }
    }

    public static class OrdenamientoSeleccion
    {
        public static void Ordenar(int[] arreglo)
        {
            for (int i = 0; i < arreglo.Length - 1; i++)
            {
                int minIdx = i;
                for (int j = i + 1; j < arreglo.Length; j++)
                    if (arreglo[j] < arreglo[minIdx])
                        minIdx = j;
                (arreglo[i], arreglo[minIdx]) = (arreglo[minIdx], arreglo[i]);
            }
        }
    }

    public static class OrdenamientoShell
    {
        public static void Ordenar(int[] arreglo)
        {
            int n = arreglo.Length;
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = arreglo[i], j = i;
                    while (j >= gap && arreglo[j - gap] > temp)
                    {
                        arreglo[j] = arreglo[j - gap];
                        j -= gap;
                    }
                    arreglo[j] = temp;
                }
            }
        }
    }

    public static class OrdenamientoQuicksort
    {
        public static void Ordenar(int[] arreglo, int bajo, int alto)
        {
            if (bajo < alto)
            {
                int pivote = Particionar(arreglo, bajo, alto);
                Ordenar(arreglo, bajo, pivote - 1);
                Ordenar(arreglo, pivote + 1, alto);
            }
        }

        private static int Particionar(int[] arreglo, int bajo, int alto)
        {
            int pivote = arreglo[alto], i = bajo;
            for (int j = bajo; j < alto; j++)
            {
                if (arreglo[j] < pivote)
                {
                    (arreglo[i], arreglo[j]) = (arreglo[j], arreglo[i]);
                    i++;
                }
            }
            (arreglo[i], arreglo[alto]) = (arreglo[alto], arreglo[i]);
            return i;
        }
    }

    public static class OrdenamientoHeapsort
    {
        public static void Ordenar(int[] arreglo)
        {
            int n = arreglo.Length;

            // Construir el heap (reorganizar el arreglo)
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(arreglo, n, i);

            // Extraer elementos del heap uno por uno
            for (int i = n - 1; i >= 0; i--)
            {
                (arreglo[0], arreglo[i]) = (arreglo[i], arreglo[0]);
                Heapify(arreglo, i, 0);
            }
        }

        private static void Heapify(int[] arreglo, int n, int i)
        {
            int mayor = i;
            int izquierda = 2 * i + 1;
            int derecha = 2 * i + 2;

            if (izquierda < n && arreglo[izquierda] > arreglo[mayor])
                mayor = izquierda;

            if (derecha < n && arreglo[derecha] > arreglo[mayor])
                mayor = derecha;

            if (mayor != i)
            {
                (arreglo[i], arreglo[mayor]) = (arreglo[mayor], arreglo[i]);
                Heapify(arreglo, n, mayor);
            }
        }
    }
}
