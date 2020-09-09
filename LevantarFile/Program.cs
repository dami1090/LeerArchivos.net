using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LevantarFile
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0, resp=0;
            bool esnumero = false;
            string ruta;
            string[] lineas;
            DirectoryInfo d;
            do
            {
                System.Console.WriteLine("Seleccione la ruta archivo: ");
                ruta = Console.ReadLine();
                d = new DirectoryInfo(ruta);
            } while (!d.Exists);
            //DirectoryInfo d = new DirectoryInfo(@"C:\Proyectos c#\Archivos para probar");
            FileInfo[] Files = d.GetFiles("*.txt"); 

           System.Console.WriteLine("Nombre de los Archivo/s:");
            foreach (FileInfo File in Files)
            {
                i++;
                System.Console.WriteLine("{0}) {1}", i, File.Name);
            }
            while (!esnumero || !(resp <= Files.Length) || (Files.Length < 0) || (resp == 0))
            {
                Console.WriteLine("ingrese numero del archivo que desea leer:");
                esnumero = int.TryParse(Console.ReadLine(), out resp);
                if (!esnumero)
                {
                    Console.WriteLine("error al ingresar un numero no valido:");
                }
            }
            lineas = System.IO.File.ReadAllLines(Files[resp - 1].FullName);
            Console.Clear();
            Console.WriteLine("El archivo seleccionado es: \t{0}",Files[resp-1].Name);
            for (int l = 0; l < lineas.Length; l++)
            {
                Console.WriteLine(" {0}-\t{1}", l + 1, lineas[l]);
            }
            System.Console.WriteLine("**************************************");
            Console.WriteLine("Presione cualquier tecla para salir.");
            System.Console.ReadKey();
        }
    }
}
