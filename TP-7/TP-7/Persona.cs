using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_7
{
    class Persona
    {
        public string Nombre, Apellido, Direccion, EstadoCivil, Genero, Cargo;
        public string Telefono;// se define de tipo string por convencion para la carga
        public double SueldoBasic, Salario, Adicional;
        public DateTime FechaNac, FechaIngreso;
        public int Antiguedad, CantHijos;

        public void CalcularSalario(Persona Empleado)
        {
            int anio;
            TimeSpan dif = DateTime.Now - Empleado.FechaIngreso;
            int dif_dias = dif.Days, por;
            anio = dif_dias / 365;
            Empleado.Antiguedad = anio;


            if (Empleado.EstadoCivil == "Casado" && Empleado.CantHijos > 2)
            {
                if (Empleado.Cargo == "Especialista" || Empleado.Cargo == "Ingeniero")
                {
                    if (Empleado.Antiguedad >= 20)
                    {
                        Empleado.Adicional = (Empleado.SueldoBasic * 25)/100;
                        Empleado.Adicional = Empleado.Adicional + (Empleado.Adicional * 50)/100;
                        Empleado.Adicional = Empleado.Adicional + 5000;
                        Empleado.Salario = Empleado.SueldoBasic + Empleado.Adicional;
                    }
                    else
                    {
                        por = 2 * Empleado.Antiguedad;
                        Empleado.Adicional = (Empleado.SueldoBasic * por) / 100;
                        Empleado.Adicional = Empleado.Adicional + 5000;
                        Empleado.Salario = Empleado.SueldoBasic + Empleado.Adicional;
                    }

                }

                else
                {
                    if (Empleado.Antiguedad >= 20)
                    {
                        Empleado.Adicional = (Empleado.SueldoBasic * 25) / 100;
                        Empleado.Salario = Empleado.SueldoBasic + Empleado.Adicional;
                    }
                    else
                    {
                        por = 2 * Empleado.Antiguedad;
                        Empleado.Adicional = (Empleado.SueldoBasic * por) / 100;
                        Empleado.Salario = Empleado.SueldoBasic + Empleado.Adicional;
                    }
                }

            }
            else
            {
                if (Empleado.Cargo == "Especialista" || Empleado.Cargo == "Ingeniero")
                {
                    if (Empleado.Antiguedad >= 20)
                    {
                        Empleado.Adicional = (Empleado.SueldoBasic * 25) / 100;
                        Empleado.Adicional = Empleado.Adicional + (Empleado.Adicional * 50) / 100;
                        Empleado.Salario = Empleado.SueldoBasic + Empleado.Adicional;
                    }
                    else
                    {
                        por = 2 * Empleado.Antiguedad;
                        Empleado.Adicional = (Empleado.SueldoBasic * por) / 100;
                        Empleado.Adicional = Empleado.Adicional + (Empleado.Adicional * 50) / 100;
                        Empleado.Salario = Empleado.SueldoBasic + Empleado.Adicional;
                    }

                }
                else
                {
                    if (Empleado.Antiguedad >= 20)
                    {
                        Empleado.Adicional = (Empleado.SueldoBasic * 25) / 100;
                    }
                    else
                    {
                        por = 2 * Empleado.Antiguedad;
                        Empleado.Adicional = (Empleado.SueldoBasic * 25) / 100;
                        Empleado.Salario = Empleado.SueldoBasic + Empleado.Adicional;
                    }
                }


            }

        }


        public void MostrarDatos(Persona Empleado)
        {
            Console.WriteLine($"Nombre: {Empleado.Nombre}");
            Console.WriteLine($"Apellido: {Empleado.Apellido}");
            Console.WriteLine($"Genero: {Empleado.Genero}");
            Console.WriteLine($"Cargo: {Empleado.Cargo}");
            Console.WriteLine($"Estado Civil: {Empleado.EstadoCivil}");
            Console.WriteLine($"Cantidad de hijos: {Empleado.CantHijos}");
            Console.WriteLine($"Fecha de nacimiento: {Empleado.FechaNac}");
            Console.WriteLine($"Fecha de ingreso: {Empleado.FechaIngreso}");
            Console.WriteLine($"Antiguedad: {Empleado.Antiguedad} Años");
            Console.WriteLine($"Sueldo Basico: {Empleado.SueldoBasic}");
            Console.WriteLine($"Adicional: {Empleado.Adicional}");
            Console.WriteLine($"Salario: {Empleado.Salario}");
        }



    }
}
