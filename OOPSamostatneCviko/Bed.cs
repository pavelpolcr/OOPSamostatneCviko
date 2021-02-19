namespace OOPSamostatneCviko
{
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

}
