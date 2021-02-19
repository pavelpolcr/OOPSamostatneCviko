using System.Linq;

namespace OOPSamostatneCviko
{
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

}
