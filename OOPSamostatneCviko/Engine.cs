namespace OOPSamostatneCviko
{
    class Engine
    {
        public EngineType Type { get; private set; }
        public Engine(EngineType type)
        {
            Type = type;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
    enum EngineType { Diesel,Electric,Steam}
}
