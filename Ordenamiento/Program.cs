using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenamiento
{
    class Program
    {
        static LinkedList<string> elementos = new LinkedList<string>();
        static void Main(string[] args)
        {
            
            char lectura;
            do
            {
                Console.WriteLine("[A]gregar elementos | [O]rdenar elementos | [M]odificar elementos | [E]liminar elementos | [V]er elementos | [B]orrar todos los elementos | [S]alir");
                Console.Write("Selecciona una opcion: ");
                lectura = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();
                switch (lectura)
                {
                    case 'A':
                        AddElement();
                        break;
                    case 'M':
                        ModifyElement();
                        break;
                    case 'E':
                        DeleteElement();
                        break;
                    case 'O':
                        OrderElement();
                        break;
                    case 'V':
                        ShowElements("elementos registrados");
                        break;
                    case 'S':
                        Console.WriteLine("Adios. Programa finalizado.");
                        break;
                    case 'B':
                        elementos.Clear();
                        Console.WriteLine("Todos los elementos han sido eliminados... Pulse una tecla para continuar");
                        break;
                    default:
                        break;
                }
                
                Console.ReadKey();
                Console.Clear();
            } while (lectura != 'S');
            Console.WriteLine("");
        }
        static void AddElement()
        {
            Console.WriteLine("Agregando un elemento.({0} / 50)", elementos.Count);
            Console.Write("Ingrese un elemento: ");
            string elem = Console.ReadLine();
            if (elem != "" )
            {
                elementos.AddFirst(elem);
                Console.WriteLine("Agregado exitosamente, pulsa una tecla para continuar...");
            }
            else
            {
                Console.WriteLine("Ingrese un valor valido...");
            }
            //elementos.Push(Console.ReadLine());
        }

        static void ModifyElement()
        {
            Console.WriteLine("Modificando un elemento.({0} / 50)", elementos.Count);
            ShowElements("Elementos disponibles para su modificacion");
            Console.Write("Ingrese el elemento a modificar: ");
            string modif = Console.ReadLine();
            if (elementos.Contains(modif) == true)
            {
                elementos.Remove(modif);
                Console.Write("Ingrese el nuevo valor para {0}: ", modif);
                string valor = Console.ReadLine();
                elementos.AddLast(valor);
                Console.WriteLine("El elemento: {0} ha sido modificado satisfactoriamente, su nuevo valor es: {1} , pulsa una tecla para continuar...", modif, valor);
            }
            else
            {
                Console.WriteLine("El elemento: {0} no existe en la lista, pulsa una tecla para continuar...", modif);
            }
        }

        static void DeleteElement()
        {
            Console.WriteLine("Eliminando un elemento.({0} / 50)", elementos.Count);
            ShowElements("Elementos disponibles para su eliminacion");
            Console.Write("Ingrese el elemento a eliminar: ");
            string elim = Console.ReadLine();
            if (elementos.Contains(elim) == true)
            {
                elementos.Remove(elim);
                Console.WriteLine("El elemento: {0} ha sido eliminado satisfactoriamente, pulsa una tecla para continuar...", elim);
            }
            else
            {
                Console.WriteLine("El elemento: {0} no existe en la lista, pulsa una tecla para continuar...", elim);
            }
        }

        static void ShowElements(string text)
        {
            int num = 1;
            IEnumerator enumerator = elementos.GetEnumerator();
            while (enumerator.MoveNext())
            {

                Console.WriteLine("Elemento {0}: {1}",num, enumerator.Current);
                num = num + 1;
            }
        }
        static void OrderElement()
        {
            IEnumerable<string> ElemOrdenado = from item in elementos orderby item select item;
            foreach (var item in ElemOrdenado)
            {
                elementos.RemoveFirst();
                elementos.AddLast(item);
            }
            Console.WriteLine("Elementos ordenados correctamente, pulsa una tecla para continuar...");
        }
    }
}
