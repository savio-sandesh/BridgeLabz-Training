using System;

namespace ParcelTracker
{
    // Contains the core business logic for parcel tracking.
    // Implements a singly linked list without using any collections.
    class ParcelUtility : IParcelTracker
    {
        // Head represents the first stage in the delivery chain.
        private ParcelNode head;

        public ParcelUtility()
        {
            head = null;
        }

        // Adds a new delivery stage at the end of the chain.
        public void AddStage(string stageName)
        {
            ParcelNode newNode = new ParcelNode(stageName);

            // If no stages exist, the new node becomes the starting stage.
            if (head == null)
            {
                head = newNode;
                return;
            }

            // Traverse to the last stage to maintain forward-only tracking.
            ParcelNode temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }

            temp.Next = newNode;
        }

        // Inserts a custom checkpoint after a specified stage.
        public void AddCheckpoint(string existingStage, string newStage)
        {
            ParcelNode temp = head;

            // Search for the specified stage in the delivery chain.
            while (temp != null && temp.StageName != existingStage)
            {
                temp = temp.Next;
            }

            // If stage is not found, insertion cannot be performed.
            if (temp == null)
            {
                Console.WriteLine("Stage not found. Checkpoint cannot be added.");
                return;
            }

            ParcelNode newNode = new ParcelNode(newStage);

            // Adjust pointers to insert the checkpoint.
            newNode.Next = temp.Next;
            temp.Next = newNode;
        }

        // Displays the parcel's journey through all available stages.
        public void TrackParcel()
        {
            // If no tracking data exists, inform the user.
            if (head == null)
            {
                Console.WriteLine("No parcel tracking data available.");
                return;
            }

            ParcelNode temp = head;

            // Forward traversal through the delivery stages.
            while (temp != null)
            {
                Console.Write(temp.StageName);

                if (temp.Next != null)
                {
                    Console.Write(" -> ");
                }

                temp = temp.Next;
            }

            Console.WriteLine();
        }

        // Marks the parcel as lost by breaking the chain at a given stage.
        public void MarkParcelLost(string stageName)
        {
            ParcelNode temp = head;

            // Locate the stage after which the parcel is lost.
            while (temp != null && temp.StageName != stageName)
            {
                temp = temp.Next;
            }

            if (temp == null)
            {
                Console.WriteLine("Stage not found. Parcel loss cannot be recorded.");
                return;
            }

            // Setting the next reference to null indicates loss of parcel.
            temp.Next = null;
            Console.WriteLine("Parcel marked as lost after stage: " + stageName);
        }
    }
}
