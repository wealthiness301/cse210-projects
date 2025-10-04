using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ListingActivity : Activity
{
    private readonly string[] _prompts = new[]
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
        : base("Listing Activity",
               "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    { }

    protected override void RunActivity()
    {
        int duration = GetDuration();
        Console.WriteLine();

        var prompt = ChooseRandom(_prompts);
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"> {prompt}");
        Console.WriteLine();
        Console.WriteLine("You have 5 seconds to think...");
        ShowCountdown(5);
        Console.WriteLine("Start listing. Press Enter after each item:");

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        var items = new List<string>();

        // We'll read lines asynchronously so we can stop when the time is up.
        while (DateTime.Now < endTime)
        {
            int msLeft = (int)(endTime - DateTime.Now).TotalMilliseconds;
            if (msLeft <= 0) break;

            var readTask = Task.Run(() => Console.ReadLine());
            bool completed = readTask.Wait(msLeft);
            if (!completed)
            {
                // Time's up, the read didn't complete in the remaining time.
                break;
            }

            string entry = readTask.Result;
            if (!string.IsNullOrWhiteSpace(entry))
            {
                items.Add(entry.Trim());
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {items.Count} items.");
        if (items.Count > 0)
        {
            Console.WriteLine("Here are the items you entered:");
            foreach (var i in items)
                Console.WriteLine($"- {i}");
        }
    }
}
