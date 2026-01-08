namespace BridgeLabzTraining.csharp_linkedlist
{
	// Singly Linked List – Social Media Friend Connections
	// This program manages social media users and their friend connections
	// using a singly linked list. Each user node stores User ID, Name, Age,
	// and a list of Friend IDs. The system supports adding and removing
	// friend connections, finding mutual friends, displaying friends of a user,
	// searching users, and counting total friends using a menu-driven approach.

	internal class SocialMediaFriendSystem
	{
		public static void Main()
		{
			UserLinkedList users = new UserLinkedList();
			int choice;

			do
			{
				Console.WriteLine("1. Add User");
				Console.WriteLine("2. Add Friend Connection");
				Console.WriteLine("3. Remove Friend Connection");
				Console.WriteLine("4. Find Mutual Friends");
				Console.WriteLine("5. Display Friends of User");
				Console.WriteLine("6. Search User by ID");
				Console.WriteLine("7. Search User by Name");
				Console.WriteLine("8. Count Friends for Each User");
				Console.WriteLine("0. Exit");
				Console.Write("Enter your choice: ");

				choice = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine();

				switch (choice)
				{
					case 1:
						Console.Write("User ID: ");
						int uid = Convert.ToInt32(Console.ReadLine());
						Console.Write("Name: ");
						string name = Console.ReadLine();
						Console.Write("Age: ");
						int age = Convert.ToInt32(Console.ReadLine());

						users.AddUser(uid, name, age);
						break;

					case 2:
						Console.Write("Enter First User ID: ");
						int u1 = Convert.ToInt32(Console.ReadLine());
						Console.Write("Enter Second User ID: ");
						int u2 = Convert.ToInt32(Console.ReadLine());

						users.AddFriendConnection(u1, u2);
						break;

					case 3:
						Console.Write("Enter First User ID: ");
						int r1 = Convert.ToInt32(Console.ReadLine());
						Console.Write("Enter Second User ID: ");
						int r2 = Convert.ToInt32(Console.ReadLine());

						users.RemoveFriendConnection(r1, r2);
						break;

					case 4:
						Console.Write("Enter First User ID: ");
						int m1 = Convert.ToInt32(Console.ReadLine());
						Console.Write("Enter Second User ID: ");
						int m2 = Convert.ToInt32(Console.ReadLine());

						users.FindMutualFriends(m1, m2);
						break;

					case 5:
						Console.Write("Enter User ID: ");
						int fid = Convert.ToInt32(Console.ReadLine());

						users.DisplayFriends(fid);
						break;

					case 6:
						Console.Write("Enter User ID: ");
						int sid = Convert.ToInt32(Console.ReadLine());

						users.SearchById(sid);
						break;

					case 7:
						Console.Write("Enter User Name: ");
						string sname = Console.ReadLine();

						users.SearchByName(sname);
						break;

					case 8:
						users.CountFriendsForEachUser();
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

	// User node
	internal class UserNode
	{
		public int UserId;
		public string Name;
		public int Age;
		public List<int> FriendIds;
		public UserNode Next;

		public UserNode(int id, string name, int age)
		{
			UserId = id;
			Name = name;
			Age = age;
			FriendIds = new List<int>();
			Next = null;
		}
	}

	// Singly linked list implementation
	internal class UserLinkedList
	{
		private UserNode head;

		public void AddUser(int id, string name, int age)
		{
			UserNode newNode = new UserNode(id, name, age);
			newNode.Next = head;
			head = newNode;
		}

		public void AddFriendConnection(int id1, int id2)
		{
			UserNode user1 = GetUser(id1);
			UserNode user2 = GetUser(id2);

			if (user1 == null || user2 == null)
			{
				Console.WriteLine("User not found");
				return;
			}

			if (!user1.FriendIds.Contains(id2))
				user1.FriendIds.Add(id2);

			if (!user2.FriendIds.Contains(id1))
				user2.FriendIds.Add(id1);

			Console.WriteLine("Friend connection added");
		}

		public void RemoveFriendConnection(int id1, int id2)
		{
			UserNode user1 = GetUser(id1);
			UserNode user2 = GetUser(id2);

			if (user1 == null || user2 == null)
			{
				Console.WriteLine("User not found");
				return;
			}

			user1.FriendIds.Remove(id2);
			user2.FriendIds.Remove(id1);

			Console.WriteLine("Friend connection removed");
		}

		public void FindMutualFriends(int id1, int id2)
		{
			UserNode user1 = GetUser(id1);
			UserNode user2 = GetUser(id2);

			if (user1 == null || user2 == null)
			{
				Console.WriteLine("User not found");
				return;
			}

			Console.WriteLine("Mutual Friends:");
			foreach (int f in user1.FriendIds)
			{
				if (user2.FriendIds.Contains(f))
					Console.WriteLine("User ID: " + f);
			}
		}

		public void DisplayFriends(int id)
		{
			UserNode user = GetUser(id);

			if (user == null)
			{
				Console.WriteLine("User not found");
				return;
			}

			Console.WriteLine($"Friends of {user.Name}:");
			foreach (int f in user.FriendIds)
				Console.WriteLine("User ID: " + f);
		}

		public void SearchById(int id)
		{
			UserNode user = GetUser(id);

			if (user == null)
			{
				Console.WriteLine("User not found");
				return;
			}

			DisplayUser(user);
		}

		public void SearchByName(string name)
		{
			UserNode temp = head;

			while (temp != null)
			{
				if (temp.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					DisplayUser(temp);
					return;
				}
				temp = temp.Next;
			}

			Console.WriteLine("User not found");
		}

		public void CountFriendsForEachUser()
		{
			UserNode temp = head;

			while (temp != null)
			{
				Console.WriteLine($"{temp.Name} has {temp.FriendIds.Count} friends");
				temp = temp.Next;
			}
		}

		private UserNode GetUser(int id)
		{
			UserNode temp = head;

			while (temp != null)
			{
				if (temp.UserId == id)
					return temp;

				temp = temp.Next;
			}

			return null;
		}

		private void DisplayUser(UserNode user)
		{
			Console.WriteLine($"{user.UserId} | {user.Name} | Age: {user.Age}");
		}
	}
}