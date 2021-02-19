namespace OOPSamostatneCviko
{
    class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
