using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSamostatneCviko
{
    class Train
    {

        public Locomotive Locomotive { get; private set; }
        public List<ITrainConnectable> Wagons { get; private set; } = new List<ITrainConnectable>();
        public Train()
        {
        }

        public Train(Locomotive locomotive)
        {
            Locomotive = locomotive;
        }

        public Train(Locomotive locomotive, List<ITrainConnectable> wagons)
        {
            Locomotive = locomotive;
            foreach (var wag in wagons)
            {
                ConnectWagon(wag);
            }
        }
        public void ConnectWagon(ITrainConnectable wagon)
        {
            if (Locomotive is null)
            {
                Console.WriteLine("Vlak nema prirazenou lokomotivu. Napred ji prirad.");
            }
            else
            {

                if (wagon.ConnectedToTrain == null)
                {


                    if (Locomotive.Engine.Type == EngineType.Steam)
                    {
                        if (this.Wagons.Count >= 5)
                        {
                            Console.WriteLine("Nelze uvezt vice nez 5 vagonu parni lokomotivou");
                        }
                        else
                        {
                            wagon.ConnectedToTrain = this;
                            Wagons.Add(wagon);
                            Console.WriteLine($"Vagon pripojen - {wagon.ToString()}");
                        }
                    }
                    else
                    {
                        wagon.ConnectedToTrain = this;
                        Wagons.Add(wagon);
                        Console.WriteLine($"Vagon pripojen - {wagon.ToString()}");
                    }
                }
                else
                {
                    Console.WriteLine("Vagon je aktualne pripojeny k jinemu vlaku");
                    
                }
            }

        }
        public void DisconnectWagon(ITrainConnectable wagon)
        {

            if (Wagons.Remove(wagon))
            {
                wagon.ConnectedToTrain = null;
            }
            else
            {
                Console.WriteLine("V tomto vlaku tento vagon nebyl zarazen");
            }
            
        }
        public void ReserveChair(int wagonNumber,int seatNumber)
        {
            if (Wagons.Count < wagonNumber)
            {
                Console.WriteLine("Vlak nema tolik vagonu");
            }
            else
            {
                Wagons.ElementAt(wagonNumber - 1).GetType();
                if (Wagons.ElementAt(wagonNumber - 1).GetType() == typeof(Hopper))
                {
                    Console.WriteLine("Nelze rezervovat misto v nakladnim voze");
                }
                else if (Wagons.ElementAt(wagonNumber - 1).GetType() == typeof(EconomyWagon))
                {
                    EconomyWagon refw = Wagons.ElementAt(wagonNumber - 1) as EconomyWagon;
                    HandleReservation(wagonNumber, seatNumber, refw);

                }
                else if (Wagons.ElementAt(wagonNumber - 1).GetType() == typeof(BussinessWagon))
                {
                    BussinessWagon refw = Wagons.ElementAt(wagonNumber - 1) as BussinessWagon;
                    HandleReservation(wagonNumber, seatNumber, refw);
                }
                else if (Wagons.ElementAt(wagonNumber - 1).GetType() == typeof(NightWagon))
                {
                    NightWagon refw = Wagons.ElementAt(wagonNumber - 1) as NightWagon;
                    HandleReservation(wagonNumber, seatNumber, refw);
                }
                
            }
            

        }

        private static void HandleReservation(int wagonNumber, int seatNumber, PersonalWagon refw)
        {
            if (seatNumber > refw.Chairs.Count)
            {
                Console.WriteLine($"vagon ma jen {refw.Chairs.Count} sedadel.");
            }
            else
            {
                if (refw.Chairs.Find(c => c.Number == seatNumber).Reserved == false)
                {
                    refw.Chairs.Find(c => c.Number == seatNumber).Reserved = true;
                    Console.WriteLine($"Uspesne reyervovano sedadlo cislo {seatNumber} ve vagone cislo {wagonNumber}");
                }
                else
                {
                    List<Chair> freechairs = refw.Chairs.FindAll(c => c.Reserved == false);
                    Console.WriteLine($"Sedadlo cislo {seatNumber} je bohuzel ve voze {wagonNumber} obsazeno. Zkuste rezervovat nektere z techto volnych mist:\n");
                    foreach (var item in freechairs)
                    {
                        Console.WriteLine($"{ item.Number}");
                    }
                    Console.WriteLine("\n");

                }

            }
        }

        public void ListReservedChairs()
        {
            int i = 0;
            foreach (var wagon in Wagons)
            {
                i++;
                if (wagon.GetType() == typeof(Hopper))
                {
                    
                    Console.WriteLine($"Vuz cislo {i}: Nakladni vagon, zadna mista k sezeni");
                    
                }
                else if (wagon.GetType() == typeof(EconomyWagon))
                {
                    EconomyWagon refw = wagon as EconomyWagon;
                    List<Chair> reserved = refw.Chairs.FindAll(c => c.Reserved == true);
                    
                    Console.WriteLine($"Vuz cislo {i}:{refw.ToString()}\n Rezervovana sedadla cislo:");
                    foreach (var item in reserved)
                    {
                        Console.WriteLine($"{ item.Number}");
                    }
                    Console.WriteLine("\n");
                }
                else if (wagon.GetType() == typeof(BussinessWagon))
                {
                    BussinessWagon refw = wagon as BussinessWagon;
                    List<Chair> reserved = refw.Chairs.FindAll(c => c.Reserved == true);

                    Console.WriteLine($"Vuz cislo {i}:{refw.ToString()}\n Rezervovana sedadla cislo:");
                    foreach (var item in reserved)
                    {
                        Console.WriteLine($"{ item.Number}");
                    }
                    Console.WriteLine("\n");
                }
                else if (wagon.GetType() == typeof(NightWagon))
                {
                    NightWagon refw = wagon as NightWagon;
                    List<Chair> reserved = refw.Chairs.FindAll(c => c.Reserved == true);

                    Console.WriteLine($"Vuz cislo {i}:{refw.ToString()}\n Rezervovana sedadla cislo:");
                    foreach (var item in reserved)
                    {
                        Console.WriteLine($"{ item.Number}");
                    }
                    Console.WriteLine("\n");
                }
            }
                

            


        }

        public override string ToString()
        {
            string ret = "Vlak, ";
            ret += Locomotive.ToString() + "\n";
            foreach (var wagon in Wagons)
            {
                ret += wagon.ToString() + "\n";
            }
            return ret;
        }
    }

}
