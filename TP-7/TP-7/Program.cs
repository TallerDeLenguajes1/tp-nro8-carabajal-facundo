using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TP_7
{
    class Program
    {
        public struct Datos
        {
            public string Nombre, Apellido, Direccion,EstadoCivil,Genero,Cargo;
            public string Telefono;// se define de tipo string por convencion para la carga
            public double SueldoBasic,Salario,Adicional;
            public DateTime FechaNac,FechaIngreso;
            public int Antiguedad, CantHijos;
        }

        public enum Cargos { Auxiliar, Administrativo, Ingeniero, Especialista, Investigador }
        public enum Nombres_M { Facundo, Adrian, Juan, Adam }
        public enum Nombres_F { Sintia, Ana, Silvia, Abril }
        public enum Apellidos { Carabajar, Juarez, Fernandez, Garcia }
        static void Main(string[] args)
        {
            List<Persona> Agenda = new List<Persona>();
            Random rnd = new Random();
            string nom, ap, genero, cargo, estado;
            int num, anio, mes, dia,canthijos;
            double sueldo,tot=0;
            DateTime fecha, fecha_in;
            for (int i = 0; i < 20; i++) {
                num = rnd.Next(1 , 3);
                if (num == 1) {
                    genero = "Masculino";
                    num = rnd.Next(4);
                    nom = Convert.ToString((Nombres_M)num);
                }
                else {
                    genero = "Femenino";
                    num = rnd.Next(4);
                    nom = Convert.ToString((Nombres_F)num);
                }
                num = rnd.Next(1, 3);
                if (num==1){
                    estado = "Casado";
                }
                else
                {
                    estado = "Soltero";
                }
                num = rnd.Next(4);
                ap = Convert.ToString((Apellidos)num);
                num = rnd.Next(5);
                cargo = Convert.ToString((Cargos)num);
                sueldo = rnd.Next(8000 , 15001);
                dia = rnd.Next(1 , 30);
                mes = rnd.Next(1 , 12);
                anio = rnd.Next(1970 , 2001);
                fecha = new DateTime(anio,mes,dia);
                dia = rnd.Next(1 , 30);
                mes = rnd.Next(1 , 12);
                anio = rnd.Next(2001 , 2019);
                fecha_in = new DateTime(anio, mes, dia);
                canthijos = rnd.Next(4);
                Agenda.Add(new Persona() { Genero = genero,
                    Nombre = nom,
                    Apellido = ap,
                    EstadoCivil = estado,
                    Cargo = cargo,
                    SueldoBasic = sueldo,
                    FechaNac = fecha,
                    FechaIngreso = fecha_in,
                    CantHijos = canthijos,
                    Telefono = "xxx-xxxxxx",
                    Direccion = "Barrio xxxx calle xxxx" });
            }
            int cont = 1,op;
            foreach (Persona datos in Agenda)
            {
                datos.CalcularSalario(datos);
                tot = tot + datos.Salario;
                Console.WriteLine($"{cont}. Nombre: {datos.Nombre} {datos.Apellido}");
                cont++;
            }
            Console.Write("\nQue empleado desea ver (0 para finalizar): ");
            op=int.Parse(Console.ReadLine());
            while (op != 0) {
                cont = 0;
                if (op == 1)
                {
                    foreach (Persona datos in Agenda)
                    {
                        cont++;
                        if (cont==op) { datos.MostrarDatos(datos); }
                    }
                }
                else {
                    cont = 0;
                    foreach (Persona datos in Agenda)
                    {
                        cont++;
                        if (cont == op)
                        {
                            datos.MostrarDatos(datos);
                        }
                    }
                }
                Console.WriteLine();
                cont = 1;
                foreach (Persona datos in Agenda)
                {
                    Console.WriteLine($"{cont}. Nombre: {datos.Nombre} {datos.Apellido}");
                    cont++;
                }

                Console.Write("\n\nQue empleado desea ver (0 para finalizar): ");
                op = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"\nEl monto total es: {tot}");

            string ruta = "tp-7.csv";
            StreamWriter Arch = new StreamWriter (ruta);
            Arch.Write("Nombre;");
            Arch.Write("Apellido;");
            Arch.Write("Direccion;");
            Arch.Write("Genero;");
            Arch.WriteLine("Fecha de nacimiento;");
            foreach (Persona persona in Agenda)
            {
                Arch.Write($"{persona.Nombre};");
                Arch.Write($"{persona.Apellido};");
                Arch.Write($"{persona.Direccion};");
                Arch.Write($"{persona.Genero};");
                Arch.WriteLine($"{persona.FechaNac};");
            }
            Arch.Close();
            Console.Write("direccion para hacer backup: ");
            ruta=Console.ReadLine();
            ruta = ruta + "tp-7.csv";
            File.Copy("tp-7.scv",ruta);
            

            Console.ReadKey();
        }

    }
   
}

