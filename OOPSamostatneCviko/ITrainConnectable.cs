namespace OOPSamostatneCviko
{
    interface ITrainConnectable
    {
        Train ConnectedToTrain { get; set; }
        void ConnectWagon(Train connectTo);
        void DisconnectWagon(Train disconnectFrom);
    }

}
