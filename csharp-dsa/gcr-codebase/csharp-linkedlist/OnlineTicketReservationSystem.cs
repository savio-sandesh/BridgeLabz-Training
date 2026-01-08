namespace BridgeLabzTraining.csharp_linkedlist
{
	// Circular Linked List – Online Ticket Reservation System
	// This program manages an online ticket reservation system using a circular linked list.
	// Each node stores Ticket ID, Customer Name, Movie Name, Seat Number, and Booking Time.
	// The system supports adding and removing tickets, searching by customer or movie name,
	// displaying all booked tickets, and counting total reservations using a menu-driven approach.

	internal class OnlineTicketReservationSystem
	{
		public static void Main()
		{
			CircularTicketList tickets = new CircularTicketList();
			int choice;

			do
			{
				Console.WriteLine("1. Add Ticket Reservation");
				Console.WriteLine("2. Remove Ticket by Ticket ID");
				Console.WriteLine("3. Display All Tickets");
				Console.WriteLine("4. Search Ticket by Customer Name");
				Console.WriteLine("5. Search Ticket by Movie Name");
				Console.WriteLine("6. Count Total Booked Tickets");
				Console.WriteLine("0. Exit");
				Console.Write("Enter your choice: ");

				choice = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine();

				switch (choice)
				{
					case 1:
						Console.Write("Ticket ID: ");
						int tid = Convert.ToInt32(Console.ReadLine());

						Console.Write("Customer Name: ");
						string cname = Console.ReadLine();

						Console.Write("Movie Name: ");
						string mname = Console.ReadLine();

						Console.Write("Seat Number: ");
						string seat = Console.ReadLine();

						Console.Write("Booking Time (24-hour format HH:mm): ");
						string time = Console.ReadLine();

						tickets.AddTicket(tid, cname, mname, seat, time);
						break;

					case 2:
						Console.Write("Enter Ticket ID to remove: ");
						int rid = Convert.ToInt32(Console.ReadLine());
						tickets.RemoveTicket(rid);
						break;

					case 3:
						tickets.DisplayTickets();
						break;

					case 4:
						Console.Write("Enter Customer Name: ");
						string scust = Console.ReadLine();
						tickets.SearchByCustomerName(scust);
						break;

					case 5:
						Console.Write("Enter Movie Name: ");
						string smovie = Console.ReadLine();
						tickets.SearchByMovieName(smovie);
						break;

					case 6:
						Console.WriteLine("Total Booked Tickets: " + tickets.CountTickets());
						break;

					case 0:
						Console.WriteLine("Exiting system...");
						break;

					default:
						Console.WriteLine("Invalid choice");
						break;
				}

				Console.WriteLine();
			} while (choice != 0);
		}
	}

	// Circular linked list node representing a ticket
	internal class TicketNode
	{
		public int TicketId;
		public string CustomerName;
		public string MovieName;
		public string SeatNumber;
		public string BookingTime;
		public TicketNode Next;

		public TicketNode(int id, string customer, string movie, string seat, string time)
		{
			TicketId = id;
			CustomerName = customer;
			MovieName = movie;
			SeatNumber = seat;
			BookingTime = time;
			Next = null;
		}
	}

	// Circular linked list implementation for ticket reservations
	internal class CircularTicketList
	{
		private TicketNode head;
		private TicketNode tail;

		// Add ticket at end
		public void AddTicket(int id, string customer, string movie, string seat, string time)
		{
			TicketNode newNode = new TicketNode(id, customer, movie, seat, time);

			if (head == null)
			{
				head = tail = newNode;
				newNode.Next = head;
				return;
			}

			tail.Next = newNode;
			newNode.Next = head;
			tail = newNode;
		}

		// Remove ticket by Ticket ID
		public void RemoveTicket(int id)
		{
			if (head == null)
			{
				Console.WriteLine("No tickets available");
				return;
			}

			TicketNode curr = head;
			TicketNode prev = tail;

			do
			{
				if (curr.TicketId == id)
				{
					if (curr == head)
						head = head.Next;

					if (curr == tail)
						tail = prev;

					prev.Next = curr.Next;

					if (curr == head && curr == tail)
						head = tail = null;

					Console.WriteLine("Ticket removed successfully");
					return;
				}

				prev = curr;
				curr = curr.Next;
			} while (curr != head);

			Console.WriteLine("Ticket not found");
		}

		// Display all tickets
		public void DisplayTickets()
		{
			if (head == null)
			{
				Console.WriteLine("No tickets booked");
				return;
			}

			TicketNode temp = head;

			do
			{
				DisplayTicket(temp);
				temp = temp.Next;
			} while (temp != head);
		}

		// Search by customer name
		public void SearchByCustomerName(string name)
		{
			if (head == null)
			{
				Console.WriteLine("No tickets booked");
				return;
			}

			TicketNode temp = head;
			bool found = false;

			do
			{
				if (temp.CustomerName.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					DisplayTicket(temp);
					found = true;
				}
				temp = temp.Next;
			} while (temp != head);

			if (!found)
				Console.WriteLine("No ticket found for this customer");
		}

		// Search by movie name
		public void SearchByMovieName(string movie)
		{
			if (head == null)
			{
				Console.WriteLine("No tickets booked");
				return;
			}

			TicketNode temp = head;
			bool found = false;

			do
			{
				if (temp.MovieName.Equals(movie, StringComparison.OrdinalIgnoreCase))
				{
					DisplayTicket(temp);
					found = true;
				}
				temp = temp.Next;
			} while (temp != head);

			if (!found)
				Console.WriteLine("No ticket found for this movie");
		}

		// Count total tickets
		public int CountTickets()
		{
			if (head == null)
				return 0;

			int count = 0;
			TicketNode temp = head;

			do
			{
				count++;
				temp = temp.Next;
			} while (temp != head);

			return count;
		}

		// Helper to display ticket details
		private void DisplayTicket(TicketNode t)
		{
			Console.WriteLine($"{t.TicketId} | {t.CustomerName} | {t.MovieName} | Seat: {t.SeatNumber} | Time: {t.BookingTime}");
		}
	}
}