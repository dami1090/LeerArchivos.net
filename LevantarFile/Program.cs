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
            int i = 0, resp=0, h=0;
            bool esnumero = false;
            string ruta;
            string[] lineas;
            string rutaBajada = @"D:\Development\LeerArchivo\bajada.txt";
            //DirectoryInfo d;
           /* do
            {
                System.Console.WriteLine("Seleccione la ruta archivo: ");
                ruta = Console.ReadLine();
                d = new DirectoryInfo(ruta);
            } while (!d.Exists);*/
            DirectoryInfo d = new DirectoryInfo(@"D:\Development\LeerArchivo");
            FileInfo[] Files = d.GetFiles("*.csv"); 

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
            StreamWriter mylogs = File.AppendText(rutaBajada);
            for (int l = lineas.Length; l > 0; l--)
            { 
                mylogs.WriteLine("["+lineas[l-1]+"]"+",");
                Console.WriteLine(" {0}-\t{1}", l, lineas[l-1]);
            }
            /*for (int l = 0; l < lineas.Length; l++)
            { 
                mylogs.WriteLine("["+lineas[l]+"]");
                Console.WriteLine(" {0}-\t{1}", l + 1, lineas[l]);
            }*/
            mylogs.Close();
            System.Console.WriteLine("**************************************");
            Console.WriteLine("Presione cualquier tecla para salir.");
            System.Console.ReadKey();
        }
    }
}
