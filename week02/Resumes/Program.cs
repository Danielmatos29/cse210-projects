using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Resumes Project.");

        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2015;
        job1._endYear = 2030;

        Job job2 = new Job();
        job2._jobTitle = "Ai Engineer";
        job2._company = "Domicem";
        job2._startYear = 2020;
        job2._endYear = 2024;

        Console.WriteLine(job1._company);
        Console.WriteLine(job2._company);

        Resume MyResume = new Resume();
        MyResume._name = "Daniel Matos";
        MyResume._jobs.Add(job1);
        MyResume._jobs.Add(job2);

        MyResume.Display();
    }
}