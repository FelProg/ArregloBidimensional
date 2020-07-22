using System;
using System.Linq;

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
            //*********** Despliega la lista de los alumnos *********
            Console.WriteLine("\n\tLista de alumnos\n\n");
            for(int i=0; i<califAlumnos.GetLength(0); i++)
            {
                Console.Write($"\t{califAlumnos[i, 0]}  ");
            }
            //*********** fin de despliegue *************************
            
            //********** toma el dato para consultar en "nombre" *******
            Console.Write("\n\n\tCual desea consultar :  ");
            string nombre = Console.ReadLine();

            Console.Clear();

            //*** busca el nombre y devuelve su renglon para desplegar******
            //*** sus calificaciones iterando sobre el renglón *************
            //*** Encontrar devuelve -1 si no encuentra nombre *************
            
            int renglon = Encontrar(nombre);
            if (renglon != -1)
            {
                //variables para controlar el promedio
                //int cont = 0; 
                //int sum = 0;
                //decimal prom = 0m;
                decimal[] total = new decimal[4];

                
                Encabezado();
                for(int i=0; i<califAlumnos.GetLength(1); i++)
                {
                    Console.Write($"\t{califAlumnos[renglon, i]}          ");

                    if (i > 0)
                    {
                        total[i-1]= Int32.Parse(califAlumnos[renglon, i]);
                        //cont++;
                        //sum += 
                    }
                }
                decimal prom = total.Sum() / total.Length;
                Console.Write($"\n\n\tEl promedio total de {califAlumnos[renglon, 0]} es :    {prom}");
            }
            else
            {
                Console.WriteLine("\tAlumno no fue encontrado");
            }
            
            //***** fin de despliegue de calificaciones individuales ******
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
