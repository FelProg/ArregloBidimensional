using System;
using System.Data;
using System.Linq;

namespace ArregloBidimensional
{
    //Programa que trabaja con 5 materias por alumno, entrega un promedio
    //el programa solicita el tipo de reporte:
    //1. Despliegue de la tabla en general
    //2. Reporte individual con promedio
    
    
    class Program
    {
        //datos de los alumnos inicializados.
        static string[,] califAlumnos = new string[,]
            {
                {"Abel    ","10","9","10","10" },
                {"Ana     ","10","10","10","9"},
                {"David   ","8","10","10","8" },
                {"Germán  ","10","9","10","10" },
                {"José    ","10","10","10","10" }
            };
        
        //arreglo para tomar los valores de las calificaciones numericas.
        static decimal[] total = new decimal[4];

        static void Main(string[] args)
        {
            MenuPrincipal();
            Console.ReadLine();
        }
        private static void MenuPrincipal()
        {
            Console.Clear();
            Console.Write($"\n\tBienvenido al programa de contról de calificaciones" +
                $"\n\tSeleccione el número de la opcion deseada  " +
                $"\n\n\t1.  Despliegue de calificaciones totales" +
                $"\n\t2.  Consulta de alumno" +
                $"\n\t3.  Salir   " +
            $"\n\n\tDigite la opción :   ");
            try
            {
                int op = Int32.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        DespliegaTabla();
                        break;
                    case 2:
                        DespliegaRepoIndividual();
                        break;
                    case 3:
                        Console.WriteLine("\n\n\tGracias!!! Que pase un buen día.");
                        break;
                    default:
                        Console.Clear();
                        throw new Exception ("\nOpcion invalida");
                }
               
            }
            catch(Exception ex)
            {
                Console.Clear();
                Console.WriteLine("\n\tOpcion invalida del tipo: "+ex.Message);
                Console.ReadLine();
                MenuPrincipal();

            }
            
        }

        private static void Encabezado(bool principal = true, string nombre ="anonymus")
        {
            Console.Clear();
            if(principal)
            //Despliega si principal es true (valor de default)
            Console.WriteLine("\n\t\t\t\tRegistro de calificaciones ciclo escolar 2020-2021\n");
            else
            //Despliega si el método DespliegaReporteIndividual cambia los parámetros al 
            //llamar a encabezado.
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
                    //Almacenamiento de las calificaciones en total.
                    if (j > 0)
                        total[j-1] = Int32.Parse(califAlumnos[i, j]);
                }
                Console.WriteLine($"\t{CalculaPromedio(total)}");
                Console.WriteLine();
            }
            Console.Write("\t");
            Console.ReadLine();
            MenuPrincipal();
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
            MenuPrincipal();
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
