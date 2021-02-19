namespace OOPSamostatneCviko
{
    class Locomotive
    {
        public Person Driver { get; private set; }
        public Engine Engine { get; private set; }
        public Locomotive()
        {
        }

        public Locomotive(Person driver, Engine engine)
        {
            Driver = driver;
            Engine = engine;
        }

        public override string ToString()
        {
            return $"Lokomotiva, Strojvudce je {Driver.FirstName} {Driver.LastName}, pohon {Engine.Type.ToString()}";
        }
    }



}
