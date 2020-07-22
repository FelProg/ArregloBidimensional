using System;
using System.Linq;

namespace ArregloBidimensional
{
    //Programa que trabaja con 5 materias por alumno, entrega un promedio
    //el programa solicita el tipo de reporte:
    //1. Despliegue de la tabla en general
    //2. Reporte individual con promedio
    
    
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
        
        //arreglo para tomar los valores de las calificaciones numericas
        static decimal[] total = new decimal[4];

        static void Main(string[] args)
        {
            DespliegaTabla();
            DespliegaRepoIndividual();

            
        }
        private static void Encabezado(bool principal = true, string nombre ="anonymus")
        {
            if(principal)
            Console.WriteLine("\n\t\t\t\tRegistro de calificaciones ciclo escolar 2020-2021\n");
            else
            Console.WriteLine($"\n\t\t\t\tReporte individual del alumno(a) : {nombre}");

            Console.WriteLine("\n\tNombre del alumno\tEspañol \tMatemáticas \tProgramación \tProyectos \tPromedio\n");
        }

        private static void DespliegaTabla()
        {
            Encabezado();
            for (int i = 0; i < califAlumnos.GetLength(0); i++)
            {
                for (int j = 0; j < califAlumnos.GetLength(1); j++)
                {
                    Console.Write($"\t{califAlumnos[i, j]}          ");
                    //Como almaceno los numeros german
                    if (j > 0)
                        total[j-1] = Int32.Parse(califAlumnos[i, j]);
                }
                Console.WriteLine($"\t{CalculaPromedio(total)}");
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
            //*** sus calificaciones y promedio iterando sobre el renglón **
            //*** Encontrar devuelve -1 si no encuentra nombre *************
            
            int renglon = Encontrar(nombre);
            if (renglon != -1)
            {
                
                Encabezado(false,nombre);
                for(int i=0; i<califAlumnos.GetLength(1); i++)
                {
                    Console.Write($"\t{califAlumnos[renglon, i]}          ");

                    //parsea los numeros para meterlos en total
                    if (i > 0)
                        total[i-1]= Int32.Parse(califAlumnos[renglon, i]);
                }
                Console.WriteLine($"\t{CalculaPromedio(total)}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("\n\tAlumno no fue encontrado");
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

        private static decimal CalculaPromedio(decimal[] total)
        {
            return total.Sum() / total.Length;

        }

       
    }
}
