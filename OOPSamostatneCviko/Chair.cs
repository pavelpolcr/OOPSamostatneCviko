﻿namespace OOPSamostatneCviko
{
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

}
