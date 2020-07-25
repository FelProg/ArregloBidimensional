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

        //Arreglo con datos para citas de padres.
        static string[][] datosCitas = new string[4][]
            {
              new[]  {"Lunes","Martes","Miercoles","Jueves","Viernes"},
              new[]  {"Enero","Febrero","Marzo","Abril","Mayo","Junio","Agosto","Septiembre","Octubre","Noviembre","Diciembre" },
              new[]  {"8", "9", "10" },
              new[]  {"1","2","3","4","5","6","7","8","9","10"}
            };

        //variables para recoleccion de posiciones de control de citas
        private static int diaSelecc, diaNumSelecc, mesSelecc, horaSelecc, ren;
        

        
        
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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"\n\tBienvenido al programa de contról de calificaciones");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"\n\n\tSeleccione el número de la opcion deseada  " +
                $"\n\n\t1.  Despliegue de calificaciones totales" +
                $"\n\t2.  Consulta de alumno" +
                $"\n\t3.  Agendar cita" +
                $"\n\t4.  Salir   " +
            $"\n\n\tDigite la opción :   ");
            Console.ResetColor();

            try
            {
                //int op = Int32.Parse(Console.ReadLine());

                //regresa 0 si no lo encuentra.
                Int32.TryParse(Console.ReadLine(), out int op);
                switch (op)
                {
                    case 1:
                        DespliegaTabla();
                        break;
                    case 2:
                        DespliegaRepoIndividual();
                        break;
                    case 3:
                        AgendarCita();
                        break;
                    case 4:
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

        private static void Encabezado(bool principal = true, string nombre ="anonymus",bool citas=false)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;

                if (citas)
                {
                    Console.WriteLine("\n\t\t\t\tSistema de registro de cítas ciclo 2020-2021\n\n");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\t\t\t      Complete el formulario con los datos que se piden");
                    Console.ResetColor();
                }
            
                if(principal)
                //Despliega si principal es true (valor de default)
                Console.WriteLine("\n\t\t\t\tRegistro de calificaciones ciclo escolar 2020-2021\n");

                if(nombre != "anonymus")
                //Despliega si el método DespliegaReporteIndividual cambia los parámetros al 
                //llamar a encabezado.
                Console.WriteLine($"\n\t\t\t\tReporte individual del alumno(a) : {nombre}");

            Console.ResetColor();
            if (principal || nombre != "anonymus")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n\tNombre del alumno\tEspañol \tMatemáticas \tProgramación \tProyectos \tPromedio\n");
                Console.ResetColor();
            }
        }

        private static void DespliegaTabla()
        {
            Encabezado();
            for (int i = 0; i < califAlumnos.GetLength(0); i++)
            {
                for (int j = 0; j < califAlumnos.GetLength(1); j++)
                {
                    //Despliega el nombre del alumno y sus calificaciones
                    Console.Write($"\t{califAlumnos[i, j]}          ");
                    //Almacenamiento de las calificaciones en total.
                    if (j > 0)
                        total[j-1] = Int32.Parse(califAlumnos[i, j]);
                }
                //Agrega el promedio al final del renglón
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

        private static void AgendarCita(bool dia=true, bool diaNum=false, bool mes=false, bool hora=false)
        {
            //se aprovecha el método Encabezado para imprimir el encabezado de citas
            //activando el tercer parametro como true.
            Encabezado(false,"anonymus",true);
           
            //grupo de if's que piden un dato almacenando su resultado en una variable
            //para despues limpiar la pantalla y activar el siguiente if cambiando los
            //parametros del método.
            if (dia)
            {
                ren = 0;
                DesplegarDatosDeCita(ren);
                Console.Write("\n\t\tSeleccione el día :  ");
                diaSelecc = OpcionDeCita(Console.ReadLine(),ren);
                Console.Clear();
                AgendarCita(false, true, false, false);
            }

            if (diaNum)
            {
                ren = 3;
                DesplegarDatosDeCita(ren);
                Console.Write("\n\t\tSeleccione el numero de fecha :  ");
                diaNumSelecc = OpcionDeCita(Console.ReadLine(),ren);
                Console.Clear();
                AgendarCita(false, false, true, false);
            }

            if (mes)
            {
                ren = 1;
                DesplegarDatosDeCita(ren);
                Console.Write("\n\t\tSeleccione el mes :  ");
                mesSelecc = OpcionDeCita(Console.ReadLine(),ren);
                Console.Clear();
                AgendarCita(false, false, false, true);
            }

            if (hora)
            {
                ren = 2;
                DesplegarDatosDeCita(ren);
                Console.Write("\n\t\tSeleccione la hora :  ");
                horaSelecc = OpcionDeCita(Console.ReadLine(),ren);
                Console.Clear();
                AgendarCita(false, false, false, false);
            }

            //este if se forza cuando ya paso y recolecto todas las posiciones de los 
            //datos de la cita y los despliega en pantalla utilizando las posisiones
            //recolectadas y pasandolas al arreglo.
            if(!dia && !diaNum && !mes && !hora)
            {
                Console.Write("\n\n\tSu cita esta programada para la siguiente fecha:  ");
                Console.WriteLine($"{datosCitas[0][diaSelecc]}  " +
                    $"{datosCitas[3][diaNumSelecc]} de " +
                    $"{datosCitas[1][mesSelecc]} en punto de las " +
                    $"{datosCitas[2][horaSelecc]}:00am");
                Console.ReadLine();
                MenuPrincipal();
            }
           
        }
        
        private static int OpcionDeCita(string seleccion, int ren)
        {
            //recorre el renglon recibido y devuelve la columna donde encuentra
            //el dato o -1 si no lo encuentra.
            for (int i = 0; i < datosCitas[ren].Length; i++)
            {
                if (seleccion.ToUpper() == datosCitas[ren][i].ToUpper())
                    return i;
            }
            return -1;   
        }

        private static void DesplegarDatosDeCita(int ren)
        {
            //Despliega las opciones a elegir en el renglon recibido.
            for(int i=0; i<datosCitas[ren].Length; i++)
            {
                Console.WriteLine($"\t\t{datosCitas[ren][i]}  ");
            }
            Console.WriteLine("\n\n");
        }

       
    }
}
