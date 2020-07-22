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
            DespliegaRepoIndividual();

            
        }
        private static void Encabezado()
        {
            //encabezado de tabla
            Console.WriteLine("\n\tNombre del alumno\tEspañol \tMatemáticas \tProgramación \tProyectos \n");
        }
        private static void DespliegaTabla()
        {
            Encabezado();
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

        private static void DespliegaRepoIndividual()
        {
            Console.Clear();
            Console.WriteLine("\n\tLista de alumnos\n\n");
            for(int i=0; i<califAlumnos.GetLength(0); i++)
            {
                Console.Write($"\t{califAlumnos[i, 0]}  ");
            }
            Console.Write("\n\n\tCual desea consultar :  ");
            string nombre = Console.ReadLine();

            Console.Clear();
            int renglon = Encontrar(nombre);
            if (renglon != -1)
            {
                Encabezado();
                for(int i=0; i<califAlumnos.GetLength(1); i++)
                {
                    Console.Write($"\t{califAlumnos[renglon, i]}          ");
                }
            }
            else
            {
                Console.WriteLine("\tAlumno no fue encontrado");
            }
            Console.ReadLine();
        }

        private static int Encontrar(string nombre)
        {
            for (int i = 0; i < califAlumnos.GetLength(0); i++)
            {
                //El Trim, corta los espacios asignados por estetica en el arreglo
                if (nombre.ToUpper() == califAlumnos[i, 0].Trim().ToUpper())
                    return i;
            }
            return -1;
        }
    }
}
