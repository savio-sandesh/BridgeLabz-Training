// Access Modifier -- Protected Internal 

// Accessible anywhere in the same project (assembly)
// OR accessible in child classes, even from another project

// Same project → accessible -- Yes

// Different project + inheritance → accessible -- Yes

// Different project + no inheritance -- No



using System;

class Parent
{
    protected internal int score = 90;

    protected internal void ShowScore()
    {
        Console.WriteLine("Score: " + score);
    }
}

class Child : Parent
{
    public void Access()
    {
        // Accessible because of inheritance
        Console.WriteLine(score);
        ShowScore();
    }
}

class Program
{
    static void Main()
    {
        Parent p = new Parent();

        // Accessible because it's in the SAME project
        Console.WriteLine(p.score);
        p.ShowScore();
    }
}
