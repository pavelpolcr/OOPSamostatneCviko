namespace OOPSamostatneCviko
{
    class Chair
    {
        public int Number { get; private set; }
        public bool NearWindow { get; private set; }
        public bool Reserved { get; private set; }
        public Chair()
        {
        }

        public Chair(int number, bool reserved)
        {
            Number = number;
            Reserved = reserved;
        }

        

    }
}
