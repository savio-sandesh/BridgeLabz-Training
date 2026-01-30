using System;

// -------------------- LINKED LIST NODE --------------------

public class StudentNode
{
    public int Marks;
    public string Name;
    public StudentNode Next;

    public StudentNode(string name, int marks)
    {
        Name = name;
        Marks = marks;
        Next = null;
    }
}

// -------------------- MERGE SORT LOGIC --------------------

public class RankSheetGenerator
{
    public static StudentNode Merge(StudentNode a, StudentNode b)
    {
        StudentNode dummy = new StudentNode("", 0);
        StudentNode tail = dummy;

        while (a != null && b != null)
        {
            if (a.Marks >= b.Marks)
            {
                tail.Next = a;
                a = a.Next;
            }
            else
            {
                tail.Next = b;
                b = b.Next;
            }
            tail = tail.Next;
        }

        tail.Next = a ?? b;
        return dummy.Next;
    }

    public static StudentNode MergeSort(StudentNode head)
    {
        if (head == null || head.Next == null)
            return head;

        StudentNode slow = head, fast = head, prev = null;

        while (fast != null && fast.Next != null)
        {
            prev = slow;
            slow = slow.Next;
            fast = fast.Next.Next;
        }

        prev.Next = null;

        StudentNode left = MergeSort(head);
        StudentNode right = MergeSort(slow);

        return Merge(left, right);
    }

    public static void PrintRankList(StudentNode head)
    {
        int rank = 1;
        Console.WriteLine("\nFinal State-Wise Rank List:");
        while (head != null)
        {
            Console.WriteLine($"Rank {rank} : {head.Name} - {head.Marks}");
            head = head.Next;
            rank++;
        }
    }
}

// -------------------- MAIN PROGRAM --------------------

public class EduResultsDemo
{
    public static void Main()
    {
        Console.Write("Enter number of districts: ");
        int districts = int.Parse(Console.ReadLine());

        StudentNode finalList = null;

        for (int d = 1; d <= districts; d++)
        {
            Console.Write($"\nEnter number of students in district {d}: ");
            int students = int.Parse(Console.ReadLine());

            StudentNode districtHead = null;
            StudentNode current = null;

            for (int i = 1; i <= students; i++)
            {
                Console.Write($"Student {i} name: ");
                string name = Console.ReadLine();

                Console.Write("Marks: ");
                int marks = int.Parse(Console.ReadLine());

                StudentNode node = new StudentNode(name, marks);

                if (districtHead == null)
                {
                    districtHead = node;
                    current = node;
                }
                else
                {
                    current.Next = node;
                    current = node;
                }
            }

            finalList = RankSheetGenerator.Merge(finalList, districtHead);
        }

        finalList = RankSheetGenerator.MergeSort(finalList);
        RankSheetGenerator.PrintRankList(finalList);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
