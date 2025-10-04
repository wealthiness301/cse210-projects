using System;
using System.Threading;

// NOTE (creativity / extra credit):
// - This Program logs each completed activity to a local file "mindfulness_log.txt" (timestamp, activity, duration).
// - The Reflection activity is implemented so questions won't repeat until the full set has been used.
// - Listing uses a non-blocking read approach (Task) so the activity stops when the time limit is reached.
// (Describe these extras in your Canvas submission.)

class Program
{
    static void Main(string[] args)
    {
        bool done = false;
        while (!done)
        {
            Console.Clear();
            Console.WriteLine("CSE 210 - Mindfulness Program");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1) Breathing Activity");
            Console.WriteLine("2) Reflection Activity");
            Console.WriteLine("3) Listing Activity");
            Console.WriteLine("4) Quit");
            Console.Write("Choose an option (1-4): ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    new BreathingActivity().Execute();
                    PauseToReturn();
                    break;
                case "2":
                    new ReflectionActivity().Execute();
                    PauseToReturn();
                    break;
                case "3":
                    new ListingActivity().Execute();
                    PauseToReturn();
                    break;
                case "4":
                    done = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter 1-4.");
                    Thread.Sleep(1000);
                    break;
            }
        }

        Console.WriteLine("Thanks for using the Mindfulness Program. Goodbye!");
    }

    static void PauseToReturn()
    {
        Console.WriteLine();
        Console.WriteLine("Press Enter to return to the main menu...");
        Console.ReadLine();
    }
}
