using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace Ejercicio05;

class Program
{
    static void Main()
    {
        DataProcess dp1 = new("Analisis", 13.02F, "Linux", "LEntry", "LOut");
        DataProcess dp2 = new("Desarrollo", 3.12F, "Windows", "WEntry", "WOut");
        DataProcess dp3 = new("Deploy", 7.23F, "iOs", "iEntry", "iOut");

        dp1.TurnEstado("Entrando", "Saliendo"); /* Se solicita ejecutar el metodo TurnEstado() sin exito ya que no son correctos los parametros para la confirmacion */
        dp1.clonarDB(); /* Output Confirmacion denegada */

        DataProcess[] dpArray1 = [dp1, dp2, dp3];
        DataProcess[] dpArray2 = [new DataProcess("Proyecto", 1.0F, "Ubuntu", "uEntry", "uOut")];
        dpArray2[0].TurnEstado("uEntry", "uOut"); /* Dando de Alta */
        dpArray2[0].TurnEstado("uEntry", "uOut"); /* Dando de Baja */

        dpArray1[1].TurnEstado("WEntry", "WOut");
        dpArray1[1].VerStado();

        Application app1 = new("Aion", 3.0F, "Windows", "C#", 19.1F, dpArray1);
        app1.TurnEstado(); /* Output Confirma tu acceso a la instancia */
        app1.TurnEstado("JavaScript", 9.10F, dpArray2); /* Introduzco falsas credenciales en los parametros para probar la negacion del acceso */
        app1.TurnEstado("C#", 19.1F, dpArray1); /* Pruebo Acceso con credenciales validos */
        app1.TurnEstado("C#", 19.1F, dpArray1); /* Doy de Baja la instancia a la App */
    }
}
