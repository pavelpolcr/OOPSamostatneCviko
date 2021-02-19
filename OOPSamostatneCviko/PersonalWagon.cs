using System.Collections.Generic;

namespace OOPSamostatneCviko
{
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

}
