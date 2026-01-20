namespace ParcelTracker
{
    // Represents a single delivery stage in the parcel tracking system.
    // Each node contains stage information and a reference to the next stage.
    class ParcelNode
    {
        public string StageName { get; set; }
        public ParcelNode Next { get; set; }

        // Initializes a delivery stage with no next reference.
        public ParcelNode(string stageName)
        {
            StageName = stageName;
            Next = null;
        }
    }
}
