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
                    if(seatNumber > refw.Chairs.Count)
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
                else if (Wagons.ElementAt(wagonNumber - 1).GetType() == typeof(BussinessWagon))
                {
                    BussinessWagon refw = Wagons.ElementAt(wagonNumber - 1) as BussinessWagon;
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
                else if (Wagons.ElementAt(wagonNumber - 1).GetType() == typeof(NightWagon))
                {
                    NightWagon refw = Wagons.ElementAt(wagonNumber - 1) as NightWagon;
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
    class Bed
    {


        public int Number { get; private set; }
        public bool Reserved { get; private set; }
        public Bed(int number, bool reserved)
        {
            Number = number;
            Reserved = reserved;
        }
    }
    public class Chair
    {


        public int Number { get; private set; }
        public bool Reserved { get; set; }
        public Chair(int number, bool reserved)
        {
            Number = number;
            Reserved = reserved;
        }
    }
    class Door
    {
        public double Height { get; private set; }
        public double Width { get; private set; }
    }
    abstract class PersonalWagon
    {
        private List<Door> doors = new List<Door>();
        public List<Door> Doors { get => doors; set => doors = value; }
        private List<Chair> chairs = new List<Chair>();

        public List<Chair> Chairs { get => chairs; set => chairs = value; }
        public int NumberOfChairs { get; private set; }
        public PersonalWagon(int numberOfChairs)
        {
            NumberOfChairs = numberOfChairs;

        }
        public abstract void CreateWagonSpace();

    }
    class EconomyWagon : PersonalWagon, ITrainConnectable
    {
        public EconomyWagon(int numberOfChairs) : base(numberOfChairs)
        {
        }

        public Train ConnectedToTrain { get; set; }

        public void ConnectWagon(Train connectTo)
        {
            connectTo.ConnectWagon(this);

        }

        public override void CreateWagonSpace()
        {
            for (int i = 0; i < NumberOfChairs; i++)
            {
                this.Chairs.Add(new Chair(i + 1, false));
            }
        }

        public void DisconnectWagon(Train disconnectFrom)
        {
            disconnectFrom.DisconnectWagon(this);
        }

        public override string ToString()
        {
            return $"Economy vuz, celkem {NumberOfChairs} sedadel z nichz je rezervovano {Chairs.Count(c => c.Reserved == true)}";
        }
    }
    class BussinessWagon : PersonalWagon, ITrainConnectable
    {
        public Person Stewart { get; private set; }
        public Train ConnectedToTrain { get; set; }

        public BussinessWagon(int numberOfChairs, Person stewart) : base(numberOfChairs)
        {
            this.Stewart = stewart;
            CreateWagonSpace();
        }

        public override void CreateWagonSpace()
        {
            for (int i = 0; i < NumberOfChairs; i++)
            {
                this.Chairs.Add(new Chair(i + 1, false));
            }
        }
        public override string ToString()
        {
            return $"Bussines vuz, cestujici obsluhuje {Stewart.FirstName} {Stewart.LastName}, celkem {NumberOfChairs} sedadel z nichz je rezervovano {Chairs.Count(c => c.Reserved == true)}";
        }

        public void ConnectWagon(Train connectTo)
        {
            connectTo.ConnectWagon(this);

        }

        public void DisconnectWagon(Train disconnectFrom)
        {
            disconnectFrom.DisconnectWagon(this);
        }
    }
    class NightWagon : PersonalWagon, ITrainConnectable
    {
        public int NumberOfBeds { get; private set; }
        private List<Bed> beds = new List<Bed>();
        public List<Bed> Beds { get => beds; set => beds = value; }
        public Train ConnectedToTrain { get; set; }

        public NightWagon(int numberOfChairs, int numberofbeds) : base(numberOfChairs)
        {
            NumberOfBeds = numberofbeds;
            CreateWagonSpace();
        }

        public override void CreateWagonSpace()
        {
            for (int i = 0; i < NumberOfChairs; i++)
            {
                this.Chairs.Add(new Chair(i + 1, false));
            }
            for (int i = 0; i < NumberOfBeds; i++)
            {
                this.Beds.Add(new Bed(i + 1, false));
            }
        }
        public override string ToString()
        {
            return $"Spaci vuz, maximální kapacita posteli {NumberOfBeds}, aktualne rezervovano {Beds.Count(b => b.Reserved == true)}, dale {NumberOfChairs} sedadel z nichz je obsazeno {Chairs.Count(c => c.Reserved == true)}";
        }

        public void ConnectWagon(Train connectTo)
        {
            connectTo.ConnectWagon(this);

        }

        public void DisconnectWagon(Train disconnectFrom)
        {
            disconnectFrom.DisconnectWagon(this);
        }
    }
    class Hopper : ITrainConnectable
    {
        public double LoadingCapacity { get; private set; }
        public Train ConnectedToTrain { get; set; }

        public Hopper(double loadingCapacity)
        {
            LoadingCapacity = loadingCapacity;
        }

        public override string ToString()
        {
            return $"Nákladní vagon, maximální kapacita {LoadingCapacity} kg.";
        }

        public void ConnectWagon(Train connectTo)
        {
            connectTo.ConnectWagon(this);

        }

        public void DisconnectWagon(Train disconnectFrom)
        {
            disconnectFrom.DisconnectWagon(this);
        }
    }

    interface ITrainConnectable
    {
        Train ConnectedToTrain { get; set; }
        void ConnectWagon(Train connectTo);
        void DisconnectWagon(Train disconnectFrom);
    }

}
