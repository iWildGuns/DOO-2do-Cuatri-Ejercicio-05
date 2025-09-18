using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace Ejercicio05
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello, World!");
            DataProcess dp1 = new("Prueba", 13.2F, "Linux", "Entrando", "Saliendo");

            dp1.TurnEstado("Entrando", "Saliendo");
            dp1.clonarDB();

        }
        public abstract class Servidor
        {
            protected string Nombre;
            protected float Version;
            protected string SistemaOptvo;
            protected bool Estado;
            public Servidor(string nombre, float version, string sistemaOptvo)
            {
                this.Nombre = nombre;
                this.Version = version;
                this.SistemaOptvo = sistemaOptvo;
                this.Estado = false;
            }
            public void TurnEstado()
            {
                System.Console.WriteLine("Confirma tu acceso a la instancia");
            }
            public void VerStado()
            {
                System.Console.WriteLine($"{this.Estado}");
            }
        }
        public class DataProcess : Servidor
        {
            private string DatosOrigen;
            private string DatosFin;
            public DataProcess(string nombre, float version, string sistemaoptvo, string datosOrigen, string datosFin) : base(nombre, version, sistemaoptvo)
            {
                this.DatosOrigen = datosOrigen;
                this.DatosFin = datosFin;
            }
            public void TurnEstado(string origen, string fin)
            {
                if (origen != this.DatosOrigen || fin != this.DatosFin)
                {
                    System.Console.WriteLine("Confirmacion denegada...");
                    return;
                }
                this.Estado = !this.Estado;
                if (this.Estado)
                {
                    System.Console.WriteLine("Se ha levantado correctamente la instancia... \nPosee acceso a datos de Origen y Fin almacenados...");
                }
                else
                {
                    System.Console.WriteLine("Se ha dado de baja correctamente la instancia...");

                }
            }
            public void clonarDB()
            {
                if (!base.Estado) { System.Console.WriteLine("No posees acceso a los datos..."); return; }
                System.Console.WriteLine("Clonando DB...");
            }
        }
        public class Application
        {

        }
    }
}