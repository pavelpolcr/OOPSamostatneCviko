using System.Collections.Generic;
using System.Linq;

namespace OOPSamostatneCviko
{
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

}
