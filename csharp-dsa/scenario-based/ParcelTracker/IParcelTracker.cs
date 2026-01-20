namespace ParcelTracker
{
    // Defines the contract for parcel tracking operations.
    // Ensures consistent implementation of delivery chain functionality.
    interface IParcelTracker
    {
        void AddStage(string stageName);
        void AddCheckpoint(string existingStage, string newStage);
        void TrackParcel();
        void MarkParcelLost(string stageName);
    }
}
