using System;

interface IPart
{
    string Name { get; }
    bool IsBuilt { get; set; }
}

interface IWorker
{
    void Build(IPart part);
}

class House : IPart
{
    public string Name => "House";
    public bool IsBuilt { get; set; }
}

class Basement : IPart
{
    public string Name => "Basement";
    public bool IsBuilt { get; set; }
}

class Walls : IPart
{
    public string Name => "Walls";
    public bool IsBuilt { get; set; }
}

class Door : IPart
{
    public string Name => "Door";
    public bool IsBuilt { get; set; }
}

class Window : IPart
{
    public string Name => "Window";
    public bool IsBuilt { get; set; }
}

class Roof : IPart
{
    public string Name => "Roof";
    public bool IsBuilt { get; set; }
}

class Worker : IWorker
{
    public void Build(IPart part)
    {
        Console.WriteLine($"Building {part.Name}");
        part.IsBuilt = true;
    }
}

class TeamLeader : IWorker
{
    public void Build(IPart part)
    {
        Console.WriteLine($"Checking {part.Name}");
    }

    public void Report(IPart part)
    {
        Console.WriteLine($"{part.Name} is built: {part.IsBuilt}");
    }
}

class Team
{
    private IWorker[] workers;

    public Team()
    {
        workers = new IWorker[] { new Worker(), new Worker(), new Worker(), new Worker(), new TeamLeader() };
    }

    public void BuildHouse(House house)
    {
        Console.WriteLine("Building a house...");
        foreach (var worker in workers)
        {
            worker.Build(house);
        }
        Console.WriteLine("House construction completed.");
    }

    public void ReportProgress(House house)
    {
        Console.WriteLine("Reporting construction progress...");
        var teamLeader = (TeamLeader)workers[workers.Length - 1];
        teamLeader.Report(house);
    }
}

interface IStudent
{
    string Name { get; set; }
    string FullName { get; set; }
    int[] Grades { get; set; }
    string GetName();
    string GetFullName();
    double GetAvgGrade();
}

class Student : IStudent
{
    public string Name { get; set; }
    public string FullName { get; set; }
    public int[] Grades { get; set; }

    public string GetName()
    {
        return Name;
    }

    public string GetFullName()
    {
        return FullName;
    }

    public double GetAvgGrade()
    {
        if (Grades.Length == 0) return 0;
        int sum = 0;
        foreach (var grade in Grades)
        {
            sum += grade;
        }
        return (double)sum / Grades.Length;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Team team = new Team();
        House house = new House();
        team.BuildHouse(house);
        team.ReportProgress(house);

        Student student = new Student
        {
            Name = "John",
            FullName = "John Smith",
            Grades = new int[] { 90, 85, 88, 92, 87 }
        };

        Console.WriteLine($"Student Name: {student.GetName()}");
        Console.WriteLine($"Student Full Name: {student.GetFullName()}");
        Console.WriteLine($"Average Grade: {student.GetAvgGrade()}");

        Console.ReadLine();
    }
}
