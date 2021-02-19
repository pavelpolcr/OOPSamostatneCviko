namespace OOPSamostatneCviko
{
    class Hopper : ITrainConnectable
    {
        public double LoadingCapacity { get; private set; }
        public Train ConnectedToTrain { get; set; }

        public Hopper(double loadingCapacity)
        {
            LoadingCapacity = loadingCapacity;
        }

        public override string ToString()
        {
            return $"Nákladní vagon, maximální kapacita {LoadingCapacity} kg.";
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
