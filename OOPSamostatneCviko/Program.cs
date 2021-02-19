using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSamostatneCviko
{
    class Program
    {
        static void Main(string[] args)
        {
            EconomyWagon ec1 = new EconomyWagon(100);
            BussinessWagon bus1 = new BussinessWagon(30, new Person("Lenka", "Kozakova"));
            NightWagon nt1 = new NightWagon(10, 30);
            Hopper nakl1 = new Hopper(3600);
            Hopper nakl2 = new Hopper(3600);
            Hopper nakl3 = new Hopper(3600);
            Hopper nakl4 = new Hopper(3600);
            Locomotive disl = new Locomotive(new Person("Karel", "Novak"), new Engine(EngineType.Diesel));
            Locomotive stml = new Locomotive(new Person("Standa", "Ksanda"), new Engine(EngineType.Steam));
            Train train1 = new Train(disl, new List<ITrainConnectable> { ec1, bus1, nt1, nakl1, nakl2 });
            Train steamtrain = new Train(stml, new List<ITrainConnectable> { new Hopper(1000), new Hopper(1000), new Hopper(1000), new Hopper(1000), new Hopper(1000) });
            Console.WriteLine(train1.ToString());
            Console.WriteLine(steamtrain.ToString());
            train1.ConnectWagon(nakl4);
            steamtrain.ConnectWagon(nakl3);
            train1.ReserveChair(3, 3);
            train1.ReserveChair(3, 3);
            train1.ListReservedChairs();


        }
    }
}
