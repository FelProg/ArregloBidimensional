using System;

namespace ArregloBidimensional
{
    //Programa que trabaja con 5 materias por alumno, entrega un promedio
    //el programa solicita el tipo de reporte:
    //1. Despliegue de la tabla en general
    //2. Reporte individual con promedio
    //3. Despliega los 3 primeros lugares
    
    class Program
    {

        static string[,] califAlumnos = new string[,]
            {
                {"Abel    ","10","9","10","10" },
                {"Ana     ","10","10","10","9"},
                {"David   ","8","10","10","8" },
                {"Germán  ","10","9","10","10" },
                {"José    ","10","10","10","10" }
            };

        static void Main(string[] args)
        {
            DespliegaTabla();

            
        }

        private static void DespliegaTabla()
        {
            //encabezado de tabla
           
            Console.WriteLine("\n\tNombre del alumno\tEspañol \tMatemáticas \tProgramación \tProyectos \n");
            for (int i = 0; i < califAlumnos.GetLength(0); i++)
            {
                for (int j = 0; j < califAlumnos.GetLength(1); j++)
                {
                    Console.Write($"\t{califAlumnos[i, j]}          ");
                }
                Console.WriteLine();
            }
            Console.Write("\t");
            Console.ReadLine();
        }
    }
}
