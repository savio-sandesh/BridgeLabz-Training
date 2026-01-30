using System;

// -------------------- STACK IMPLEMENTATION --------------------

class StackNode
{
    public int QuestionId;
    public StackNode Next;

    public StackNode(int questionId)
    {
        QuestionId = questionId;
        Next = null;
    }
}

class QuestionStack
{
    private StackNode top;

    public void Push(int questionId)
    {
        StackNode node = new StackNode(questionId);
        node.Next = top;
        top = node;
        Console.WriteLine("Moved to Question " + questionId);
    }

    public int Pop()
    {
        if (top == null)
        {
            Console.WriteLine("No previous question.");
            return -1;
        }

        int id = top.QuestionId;
        top = top.Next;
        return id;
    }

    public int Peek()
    {
        return top == null ? -1 : top.QuestionId;
    }

    public void Display()
    {
        Console.Write("Navigation History: ");
        StackNode current = top;
        while (current != null)
        {
            Console.Write(current.QuestionId + " -> ");
            current = current.Next;
        }
        Console.WriteLine("START");
    }
}

// -------------------- HASH MAP IMPLEMENTATION --------------------

class AnswerNode
{
    public int QuestionId;
    public string Answer;
    public AnswerNode Next;

    public AnswerNode(int questionId, string answer)
    {
        QuestionId = questionId;
        Answer = answer;
        Next = null;
    }
}

class AnswerMap
{
    private const int SIZE = 10;
    private AnswerNode[] table = new AnswerNode[SIZE];

    private int Hash(int key)
    {
        return key % SIZE;
    }

    public void Put(int questionId, string answer)
    {
        int index = Hash(questionId);
        AnswerNode node = table[index];

        while (node != null)
        {
            if (node.QuestionId == questionId)
            {
                node.Answer = answer;
                return;
            }
            node = node.Next;
        }

        AnswerNode newNode = new AnswerNode(questionId, answer);
        newNode.Next = table[index];
        table[index] = newNode;
    }

    public string Get(int questionId)
    {
        int index = Hash(questionId);
        AnswerNode node = table[index];

        while (node != null)
        {
            if (node.QuestionId == questionId)
                return node.Answer;
            node = node.Next;
        }
        return null;
    }
}

// -------------------- EXAM PROCTOR LOGIC --------------------

class ExamProctor
{
    private QuestionStack navigation = new QuestionStack();
    private AnswerMap answers = new AnswerMap();
    private bool submitted = false;

    private static readonly string[] CORRECT_ANSWERS =
    {
        null, "A", "C", "B", "D", "A"
    };

    public void Navigate(int questionId)
    {
        if (submitted) return;
        navigation.Push(questionId);
    }

    public void GoBack()
    {
        if (submitted) return;
        navigation.Pop();
    }

    public void SubmitAnswer(int questionId, string answer)
    {
        if (submitted) return;
        answers.Put(questionId, answer);
    }

    public void SubmitExam()
    {
        submitted = true;
        Console.WriteLine("\nExam Submitted");
        navigation.Display();
        Console.WriteLine("Final Score: " + CalculateScore());
    }

    private int CalculateScore()
    {
        int score = 0;
        for (int i = 1; i < CORRECT_ANSWERS.Length; i++)
        {
            string ans = answers.Get(i);
            if (ans != null && ans == CORRECT_ANSWERS[i])
            {
                score += 4;
            }
        }
        return score;
    }
}

// -------------------- MAIN --------------------

public class ExamProctorDemo
{
    public static void Main()
    {
        ExamProctor exam = new ExamProctor();

        exam.Navigate(1);
        exam.SubmitAnswer(1, "A");

        exam.Navigate(2);
        exam.SubmitAnswer(2, "C");

        exam.Navigate(3);
        exam.SubmitAnswer(3, "B");

        exam.GoBack();
        exam.SubmitAnswer(3, "C");

        exam.Navigate(4);
        exam.SubmitAnswer(4, "D");

        exam.Navigate(5);
        exam.SubmitAnswer(5, "A");

        exam.SubmitExam();
    }
}
