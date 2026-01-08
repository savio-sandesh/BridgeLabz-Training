namespace BridgeLabzTraining.csharp_linkedlist
{
	// Singly Linked List – Inventory Management System
	// This program manages inventory items using a singly linked list.
	// Each node stores Item ID, Item Name, Quantity, and Price.
	// The system supports insertion, deletion, searching, updating,
	// calculating total inventory value, sorting, and displaying items
	// using a menu-driven approach.

	internal class InventoryManagementSystem
	{
		public static void Main()
		{
			InventoryLinkedList inventory = new InventoryLinkedList();
			int choice;

			do
			{
				Console.WriteLine("1. Add Item at Beginning");
				Console.WriteLine("2. Add Item at End");
				Console.WriteLine("3. Add Item at Position");
				Console.WriteLine("4. Remove Item by Item ID");
				Console.WriteLine("5. Search Item by Item ID");
				Console.WriteLine("6. Update Item Quantity");
				Console.WriteLine("7. Display All Items");
				Console.WriteLine("8. Calculate Total Inventory Value");
				Console.WriteLine("9. Sort Inventory by Price");
				Console.WriteLine("0. Exit");
				Console.Write("Enter your choice: ");

				choice = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine();

				switch (choice)
				{
					case 1:
						Console.Write("Item ID: ");
						int id1 = Convert.ToInt32(Console.ReadLine());
						Console.Write("Item Name: ");
						string name1 = Console.ReadLine();
						Console.Write("Quantity: ");
						int qty1 = Convert.ToInt32(Console.ReadLine());
						Console.Write("Price: ");
						double price1 = Convert.ToDouble(Console.ReadLine());

						inventory.AddAtBeginning(id1, name1, qty1, price1);
						break;

					case 2:
						Console.Write("Item ID: ");
						int id2 = Convert.ToInt32(Console.ReadLine());
						Console.Write("Item Name: ");
						string name2 = Console.ReadLine();
						Console.Write("Quantity: ");
						int qty2 = Convert.ToInt32(Console.ReadLine());
						Console.Write("Price: ");
						double price2 = Convert.ToDouble(Console.ReadLine());

						inventory.AddAtEnd(id2, name2, qty2, price2);
						break;

					case 3:
						Console.Write("Position: ");
						int pos = Convert.ToInt32(Console.ReadLine());
						Console.Write("Item ID: ");
						int id3 = Convert.ToInt32(Console.ReadLine());
						Console.Write("Item Name: ");
						string name3 = Console.ReadLine();
						Console.Write("Quantity: ");
						int qty3 = Convert.ToInt32(Console.ReadLine());
						Console.Write("Price: ");
						double price3 = Convert.ToDouble(Console.ReadLine());

						inventory.AddAtPosition(pos, id3, name3, qty3, price3);
						break;

					case 4:
						Console.Write("Enter Item ID to remove: ");
						int rid = Convert.ToInt32(Console.ReadLine());
						inventory.RemoveByItemId(rid);
						break;

					case 5:
						Console.Write("Enter Item ID to search: ");
						int sid = Convert.ToInt32(Console.ReadLine());
						inventory.SearchByItemId(sid);
						break;

					case 6:
						Console.Write("Enter Item ID: ");
						int uid = Convert.ToInt32(Console.ReadLine());
						Console.Write("Enter New Quantity: ");
						int newQty = Convert.ToInt32(Console.ReadLine());

						inventory.UpdateQuantity(uid, newQty);
						break;

					case 7:
						inventory.Display();
						break;

					case 8:
						Console.WriteLine("Total Inventory Value: " + inventory.CalculateTotalValue());
						break;

					case 9:
						inventory.SortByPrice(true);
						Console.WriteLine("Inventory sorted by price (ascending).");
						break;

					case 0:
						Console.WriteLine("Exiting program...");
						break;

					default:
						Console.WriteLine("Invalid choice");
						break;
				}

				Console.WriteLine();
			} while (choice != 0);
		}
	}

	// Node class
	internal class ItemNode
	{
		public int ItemId;
		public string ItemName;
		public int Quantity;
		public double Price;
		public ItemNode Next;

		public ItemNode(int id, string name, int qty, double price)
		{
			ItemId = id;
			ItemName = name;
			Quantity = qty;
			Price = price;
			Next = null;
		}
	}

	// Singly Linked List implementation
	internal class InventoryLinkedList
	{
		private ItemNode head;

		public void AddAtBeginning(int id, string name, int qty, double price)
		{
			ItemNode newNode = new ItemNode(id, name, qty, price);
			newNode.Next = head;
			head = newNode;
		}

		public void AddAtEnd(int id, string name, int qty, double price)
		{
			ItemNode newNode = new ItemNode(id, name, qty, price);

			if (head == null)
			{
				head = newNode;
				return;
			}

			ItemNode temp = head;
			while (temp.Next != null)
				temp = temp.Next;

			temp.Next = newNode;
		}

		public void AddAtPosition(int position, int id, string name, int qty, double price)
		{
			if (position == 1)
			{
				AddAtBeginning(id, name, qty, price);
				return;
			}

			ItemNode temp = head;
			for (int i = 1; i < position - 1 && temp != null; i++)
				temp = temp.Next;

			if (temp == null)
			{
				Console.WriteLine("Invalid position");
				return;
			}

			ItemNode newNode = new ItemNode(id, name, qty, price);
			newNode.Next = temp.Next;
			temp.Next = newNode;
		}

		public void RemoveByItemId(int id)
		{
			if (head == null)
				return;

			if (head.ItemId == id)
			{
				head = head.Next;
				return;
			}

			ItemNode temp = head;
			while (temp.Next != null && temp.Next.ItemId != id)
				temp = temp.Next;

			if (temp.Next == null)
			{
				Console.WriteLine("Item not found");
				return;
			}

			temp.Next = temp.Next.Next;
		}

		public void UpdateQuantity(int id, int qty)
		{
			ItemNode temp = head;

			while (temp != null)
			{
				if (temp.ItemId == id)
				{
					temp.Quantity = qty;
					Console.WriteLine("Quantity updated successfully");
					return;
				}
				temp = temp.Next;
			}

			Console.WriteLine("Item not found");
		}

		public void SearchByItemId(int id)
		{
			ItemNode temp = head;

			while (temp != null)
			{
				if (temp.ItemId == id)
				{
					DisplayItem(temp);
					return;
				}
				temp = temp.Next;
			}

			Console.WriteLine("Item not found");
		}

		public double CalculateTotalValue()
		{
			double total = 0;
			ItemNode temp = head;

			while (temp != null)
			{
				total += temp.Price * temp.Quantity;
				temp = temp.Next;
			}

			return total;
		}

		public void SortByPrice(bool ascending)
		{
			for (ItemNode i = head; i != null; i = i.Next)
			{
				for (ItemNode j = i.Next; j != null; j = j.Next)
				{
					if ((ascending && i.Price > j.Price) ||
						(!ascending && i.Price < j.Price))
					{
						Swap(i, j);
					}
				}
			}
		}

		public void Display()
		{
			ItemNode temp = head;

			if (temp == null)
			{
				Console.WriteLine("Inventory is empty");
				return;
			}

			while (temp != null)
			{
				DisplayItem(temp);
				temp = temp.Next;
			}
		}

		private void Swap(ItemNode a, ItemNode b)
		{
			int tid = a.ItemId;
			string tname = a.ItemName;
			int tqty = a.Quantity;
			double tprice = a.Price;

			a.ItemId = b.ItemId;
			a.ItemName = b.ItemName;
			a.Quantity = b.Quantity;
			a.Price = b.Price;

			b.ItemId = tid;
			b.ItemName = tname;
			b.Quantity = tqty;
			b.Price = tprice;
		}

		private void DisplayItem(ItemNode item)
		{
			Console.WriteLine($"{item.ItemId} | {item.ItemName} | Qty: {item.Quantity} | Price: {item.Price}");
		}
	}
}