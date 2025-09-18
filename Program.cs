using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace Ejercicio05
{
    class Program
    {
        static void Main()
        {
            DataProcess dp1 = new("Analisis", 13.02F, "Linux", "LEntry", "LOut");
            DataProcess dp2 = new("Desarrollo", 3.12F, "Windows", "WEntry", "WOut");
            DataProcess dp3 = new("Deploy", 7.23F, "iOs", "iEntry", "iOut");


            dp1.TurnEstado("Entrando", "Saliendo"); /* Se solicita ejecutar el metodo TurnEstado() sin exito ya que no son correctos los parametros para la confirmacion */
            dp1.clonarDB(); /* Output Confirmacion denegada */

            DataProcess[] dpArray1 = new DataProcess[3];
            dpArray1[0] = dp1;
            dpArray1[1] = dp2;
            dpArray1[2] = dp3;

            DataProcess[] dpArray2 = new DataProcess[1];
            dpArray2[0] = new DataProcess("Proyecto", 1.0F, "Ubuntu", "uEntry", "uOut");
            dpArray2[0].TurnEstado("uEntry", "uOut"); /* Dando de Alta */
            dpArray2[0].TurnEstado("uEntry", "uOut"); /* Dando de Baja */

            dpArray1[1].TurnEstado("WEntry", "WOut");
            dpArray1[1].VerStado();

            Application app1 = new("Aion", 3.0F, "Windows", "C#", 19.1F, dpArray1);
            app1.TurnEstado(); /* Output Confirma tu acceso a la instancia */
            app1.TurnEstado("JavaScript", 9.10F, dpArray2); /* Introduzco falsas credenciales en los parametros para probar la negacion del acceso */
            app1.TurnEstado("C#", 19.1F, dpArray1); /* Pruebo Acceso con credenciales validos */
            app1.TurnEstado("C#", 19.1F, dpArray1); /* Doy de Baja la instancia a la App */

            //* ---- Finalizando este ejercico en codigo, por ahi se me hace mas facil hacer el diagrama xD ---- *//

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
                System.Console.WriteLine("Confirma tu acceso a la instancia...");
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
            public DataProcess(string nombre, float version, string sistemaOptvo, string datosOrigen, string datosFin) : base(nombre, version, sistemaOptvo)
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
                    System.Console.WriteLine($"Se ha levantado correctamente la instancia {base.Nombre}... \nPosee acceso a datos de Origen y Fin almacenados...");
                    return;
                }
                System.Console.WriteLine($"Se ha dado de baja correctamente la instancia {base.Nombre}...");
            }
            public void clonarDB()
            {
                if (!base.Estado) { System.Console.WriteLine("No posees acceso a los datos..."); return; }
                System.Console.WriteLine("Clonando DB...");
            }
        }
        public class Application : Servidor
        {
            private string Lenguaje;
            private float LenguajeV;
            private DataProcess[] DataBase;
            public Application(string nombre, float version, string sistemaOptvo, string lenguaje, float lenguajeV, DataProcess[] dataBase) : base(nombre, version, sistemaOptvo)
            {
                this.Lenguaje = lenguaje;
                this.LenguajeV = lenguajeV;
                this.DataBase = dataBase;
            }
            public void TurnEstado(string lgj, float ldjV, DataProcess[] dBase)
            {
                if (lgj != this.Lenguaje || ldjV != this.LenguajeV || dBase != this.DataBase)
                {
                    System.Console.WriteLine("Confirmacion denegada...");
                    return;
                }
                this.Estado = !this.Estado;
                if (this.Estado)
                {
                    System.Console.WriteLine($"Se ha levantado correctamente la instancia de la app {base.Nombre}... \nSe ha instalado correctamente el lenguaje {this.Lenguaje} en la version {this.LenguajeV}");
                    return;
                }
                System.Console.WriteLine($"Se ha dado de baja correctamente la instancia de la aplicacion {base.Nombre}...");
            }
        }
    }
}