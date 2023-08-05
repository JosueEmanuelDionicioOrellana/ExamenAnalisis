
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Auto auto = new Auto();
        Bicileta bicileta = new Bicileta();
        GestionVehiculos gestion = GestionVehiculos();

        gestion.AddVehiculo(auto);
        gestion.avanzarVehiculo();
        

        Thread thread1 = new Thread(gestion.AddVehiculo(auto));
        Thread thread2 = new Thread(gestion.AddVehiculo(bicileta));
        
        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        Console.WriteLine("Exiting...");

    }

    public class GestionVehiculos{

        private IVehiculos vehiculos1;

        public void AddVehiculo(IVehiculos vehiculos){
            vehiculos1 = vehiculos;
        } 
        public void avanzarVehiculo(){
            vehiculos1.avanzar();
        }
        public void detenerVehiculo(){
            vehiculos1.detener();
        }
    }

    
    public class Auto: IVehiculos
    {
        public void avanzar()
        {
            Console.WriteLine("Avanza el carro");
        }
        public void detener()
        {
            Console.WriteLine("Detiene el carro");
        }
    }

    public class Bicileta: IVehiculos
    {
        public void avanzar()
        {
            Console.WriteLine("Avanza la bicicleta");
        }
        public void detener()
        {
            Console.WriteLine("Detiene la bicicleta");
        }
    }

    public interface IVehiculos{
        void avanzar();
        void detener();
    }
}
