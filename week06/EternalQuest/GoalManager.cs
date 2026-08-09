using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private double _score = 0;
    private int _currentLevel = 0;
    private double _scoreToLevelUp = 100;
    public GoalManager()
    {
        
    }
    public void Start()
    {
        int userInput = 0;

        while (userInput != 6)
        {
            Console.Write("""
            Menu Options:
                1. Create New Goal
                2. List Goals
                3. Save Goals
                4. Load Goals
                5. Record Goals
                6. Quit
            Select a choice from the menu: 
            """);

            string input = Console.ReadLine();

            if(int.TryParse(input, out userInput))
            {
                switch (userInput)
                {
                    case 1 :
                        CreateGoal();
                        break;
                    case 2 :
                        ListGoalDetails();
                        break;
                    case 3 : 
                        SaveGoals();
                        break;
                    case 4 : 
                        LoadGoals();
                        break;
                    case 5 : 
                        RecordEvent();
                        break;
                    case 6 :
                        Console.WriteLine("Great job, good bye!");
                        break;
                    default :
                        Console.WriteLine("You should write a number between (1-6)");
                        break;
                }
            }
            else
            {
                Console.WriteLine("You must enter a number.\n Have a great day!");
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You now have {_score} points!\n");

        Console.WriteLine($"Your current level is {_currentLevel}");
    }

    public void LevelSystem()
    {
        double experienceNeeded = 1.5;

        while (_score >= _scoreToLevelUp)
        {
            _currentLevel ++;
            _scoreToLevelUp += _scoreToLevelUp * experienceNeeded;
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("""

        The types of goals are:
            1. Simple Goal
            2. Eternal Goal
            3. Checklist Goal
        """);

        Console.Write("Which type of goal would you like to create? ");
        int selector;
        
        string goal = Console.ReadLine() + "\n";

        if (int.TryParse(goal, out selector))
        {
            switch (selector)
            {
                case 1 :
                    Console.Write("What is the name of your goal? ");
                    string name1 = Console.ReadLine();
                    
                    Console.Write("What is a description of it? ");
                    string description1 = Console.ReadLine();

                    Console.Write("What amount of points do you want to get from it? ");
                    string points1 = Console.ReadLine();

                    SimpleGoal g1 = new SimpleGoal(name1, description1, points1);
                    _goals.Add(g1);
                    break;
                case 2 :
                    Console.Write("What is the name of your goal? ");
                    string name2 = Console.ReadLine();
                    
                    Console.Write("What is a description of it? ");
                    string description2 = Console.ReadLine();

                    Console.Write("What amount of points do you want to get from it? ");
                    string points2 = Console.ReadLine();
                    
                    EternalGoal g2 = new EternalGoal(name2, description2, points2);
                    _goals.Add(g2);
                    break;
                case 3 :
                    Console.Write("What is the name of your goal? ");
                    string name3 = Console.ReadLine();
                    
                    Console.Write("What is a description of it? ");
                    string description3 = Console.ReadLine();

                    Console.Write("What amount of points do you want to get from it? ");
                    string points3 = Console.ReadLine();
                    
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    int target = int.Parse(Console.ReadLine());

                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    int bonus = int.Parse(Console.ReadLine());

                    CheckList g3 = new CheckList(name3, description3, points3, target, bonus);
                    _goals.Add(g3);
                    break;
                default :
                    Console.WriteLine("You should write a number between (1-3)");
                    break;
            }
        }
        else
        {
            Console.WriteLine("You must write a number.");
        }
    }

    public void ListGoalNames()
    {
        int index = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{index} - {goal.GetShortName()}");
            index++;
        }
        Console.WriteLine();
        DisplayPlayerInfo();
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are: ");
        int index = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{index}. {goal.GetDetailsString()}");
            index++;
        }
        Console.WriteLine();
        DisplayPlayerInfo();
    }

    public void RecordEvent()
    {
        Console.WriteLine("The goals are: ");
        ListGoalNames();

        Console.Write("Which one did you completed? ");
        int goal = int.Parse(Console.ReadLine()) - 1;

        if (_goals[goal] is SimpleGoal simpleGoal)
        {
            simpleGoal.SetChecking(true);

            simpleGoal.RecordEvent();

            _score += simpleGoal.GetPoints();
            LevelSystem();

            Console.WriteLine();
        }
        else if (_goals[goal] is CheckList checkList)
        {
            checkList.RecordEvent();

            _score += checkList.GetPoints();
            LevelSystem();

            if (checkList.IsComplete() == true)
            {
                _score += checkList.GetBonus();
            }

            Console.WriteLine();
        }
        else
        {
            _goals[goal].RecordEvent();

            _score += _goals[goal].GetPoints();
            LevelSystem();

            Console.WriteLine();
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the name of your file? ");
        string fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();

        string[] lines = System.IO.File.ReadAllLines(filename);

        _score = int.Parse(lines[0]);
        LevelSystem();

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];

            string[] parts = line.Split(":");
            string goalType = parts[0];
            string[] details = parts[1].Split(",");

            if (goalType == "SimpleGoal")
            {
                string name = details[0];
                string description = details[1];
                string points = details[2];
                bool isComplete = bool.Parse(details[3]);

                SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                simpleGoal.SetChecking(isComplete);
                _goals.Add(simpleGoal);
            }
            else if (goalType == "EternalGoal")
            {
                string name = details[0];
                string description = details[1];
                string points = details[2];

                EternalGoal eternalGoal = new EternalGoal(name, description, points);
                _goals.Add(eternalGoal);
            }
            else if (goalType == "CheckList")
            {
                string name = details[0];
                string description = details[1];
                string points = details[2];
                int bonus = int.Parse(details[3]);
                int target = int.Parse(details[5]);
                int amountCompleted = int.Parse(details[4]);

                CheckList CheckList = new CheckList(name, description, points, target, bonus);
                CheckList.SetAmountCompleted(amountCompleted);

                _goals.Add(CheckList);
            }
        }
    }
}