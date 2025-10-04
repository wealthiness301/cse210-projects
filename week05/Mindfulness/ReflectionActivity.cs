using System;
using System.Collections.Generic;
using System.Linq;

public class ReflectionActivity : Activity
{
    private readonly string[] _prompts = new[]
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private readonly string[] _questions = new[]
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private Random _rand = new Random();

    public ReflectionActivity()
        : base("Reflection Activity",
               "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    { }

    protected override void RunActivity()
    {
        int duration = GetDuration();
        Console.WriteLine();

        // Choose a prompt and wait for the user to be ready
        var prompt = ChooseRandom(_prompts);
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"> {prompt}");
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        DateTime endTime = DateTime.Now.AddSeconds(duration);

        // Extra credit feature: ensure no question repeats until all are used (shuffle)
        List<string> pool = _questions.OrderBy(x => _rand.Next()).ToList();
        int idx = 0;

        while (DateTime.Now < endTime)
        {
            if (idx >= pool.Count)
            {
                // reshuffle when pool exhausted
                pool = _questions.OrderBy(x => _rand.Next()).ToList();
                idx = 0;
            }

            Console.WriteLine();
            Console.WriteLine(pool[idx]);
            idx++;

            // spinner while user reflects
            PauseWithSpinner(5);

            // If time remains continue to next question
        }
    }
}
