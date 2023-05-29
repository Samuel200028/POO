using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //2 Desarrolladores Desarrollador(string nombre, DateTime fechaIngreso,
            //string email, Categoria categoria)
            Desarrollador desarrollador1 = new Desarrollador("Juan", DateTime.Now, "juan@gmail.com", Categoria.Nivel1);
            Desarrollador desarrollador2 = new Desarrollador("Pedro", DateTime.Now, "pedro@gmail.com", Categoria.Nivel2);

            //2 proyectos Proyecto(string nombre, Categoria categoria,
            //int duracion, DateTime fechaInicio)
            Proyecto proyecto1 = new Proyecto("Proyecto A", Categoria.Nivel1, 100, DateTime.Now);
            Proyecto proyecto2 = new Proyecto("Proyecto B", Categoria.Nivel2, 200, DateTime.Now);

            // Asignar proyectos a desarrolladores
            desarrollador1.AsignarProyecto(proyecto1);
            desarrollador2.AsignarProyecto(proyecto2);

            // Capturar horas de trabajo
            desarrollador1.CapturarHoras(proyecto1, 50);
            desarrollador2.CapturarHoras(proyecto2, 150);
            desarrollador1.CapturarHoras(proyecto2, 100); // Intento de capturar horas de un proyecto no asignado al desarrollador

            Console.ReadLine();
        }
    }
    class Desarrollador
    {
        //De cada desarrollador interesa mantener la información de su Nombre,
        //Fecha de ingreso, Email y Categoría (Nivel 1, Nivel 2, Nivel 3).
        public string Nombre { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Email { get; set; }
        public Categoria Categoria { get; set; }
        public List<Proyecto> Proyectos { get; set; }
        public Desarrollador(string nombre, DateTime fechaIngreso, string email, Categoria categoria)
        {
            Nombre = nombre;
            FechaIngreso = fechaIngreso;
            Email = email;
            Categoria = categoria;
            Proyectos = new List<Proyecto>();
        }
        //Se hacen asignaciones de proyectos a cada desarrollador
        public void AsignarProyecto(Proyecto proyecto)
        {
            if (proyecto.Desarrollador == null)
            {
                proyecto.Desarrollador = this;
                Proyectos.Add(proyecto);
            }
            else
            {
                //1 proyecto no puede tener más de un desarrollador
                Console.WriteLine("El proyecto ya tiene asignado un desarrollador.");
            }
        }
        public void CapturarHoras(Proyecto proyecto, int horas)
        {
            if (Proyectos.Contains(proyecto))
            {
                if (horas <= proyecto.Duracion)
                {
                    proyecto.Duracion -= horas;
                    Console.WriteLine($"Se han capturado {horas} horas para el proyecto {proyecto.Nombre}.");
                }
                else
                {
                    Console.WriteLine("No puedes capturar más horas de las disponibles en el proyecto.");
                }
            }
            else
            {
                Console.WriteLine("El proyecto no está asignado a este desarrollador.");
            }
        }
    }
    //Categoría (Nivel 1, Nivel 2, Nivel 3).
    enum Categoria
    {
        Nivel1,
        Nivel2,
        Nivel3
    }
    class Proyecto
    {
        //De cada Proyecto interesa guardar Nombre, Categoría (Nivel 1, Nivel 2, Nivel 3),
        //Duración en horas y Fecha de inicio.
        public string Nombre { get; set; }
        public Categoria Categoria { get; set; }
        public int Duracion { get; set; }
        public DateTime FechaInicio { get; set; }
        public Desarrollador Desarrollador { get; set; }

        public Proyecto(string nombre, Categoria categoria, int duracion, DateTime fechaInicio)
        {
            Nombre = nombre;
            Categoria = categoria;
            Duracion = duracion;
            FechaInicio = fechaInicio;
            Desarrollador = null;
        }
    }
}

