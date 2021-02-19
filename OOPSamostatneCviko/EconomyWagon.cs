using System.Linq;

namespace OOPSamostatneCviko
{
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

}
