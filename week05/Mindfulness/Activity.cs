using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _durationSeconds;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Public entry point used by Program.cs
    public void Execute()
    {
        ShowStart();
        SetDurationFromUser();
        Console.WriteLine();
        Console.WriteLine("Get ready...");
        PauseWithSpinner(3);
        RunActivity();                 // implemented by derived classes
        ShowEnd();
        LogCompletion();
    }

    // Derived classes must implement the activity specifics
    protected abstract void RunActivity();

    private void ShowStart()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} ---");
        Console.WriteLine(_description);
        Console.WriteLine();
    }

    private void SetDurationFromUser()
    {
        while (true)
        {
            Console.Write("Enter the duration (seconds): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int seconds) && seconds > 0)
            {
                _durationSeconds = seconds;
                break;
            }
            Console.WriteLine("Please enter a positive integer.");
        }
    }

    protected int GetDuration()
    {
        return _durationSeconds;
    }

    // Spinner animation for a number of seconds (uses small frames)
    protected void PauseWithSpinner(int seconds)
    {
        string[] frames = { "|", "/", "-", "\\" };
        int totalFrames = seconds * 10; // 100ms per frame
        for (int i = 0; i < totalFrames; i++)
        {
            Console.Write(frames[i % frames.Length]);
            Thread.Sleep(100);
            Console.Write("\b \b"); // erase
        }
    }

    // Countdown (1..seconds). Clears multi-digit numbers correctly.
    protected void ShowCountdown(int seconds)
    {
        for (int s = seconds; s >= 1; s--)
        {
            string text = s.ToString();
            Console.Write(text);
            Thread.Sleep(1000);
            for (int i = 0; i < text.Length; i++)
                Console.Write("\b \b");
        }
    }

    private void ShowEnd()
    {
        Console.WriteLine();
        Console.WriteLine("Good job!");
        Thread.Sleep(500);
        Console.WriteLine($"You have completed the activity for {GetDuration()} seconds.");
        PauseWithSpinner(3);
        Console.WriteLine();
    }

    // Simple log to file (extra feature)
    private void LogCompletion()
    {
        try
        {
            string line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {_name} - {GetDuration()}s";
            File.AppendAllText("mindfulness_log.txt", line + Environment.NewLine);
        }
        catch
        {
            // don't crash if logging fails
        }
    }

    // Small helper to pick a random entry
    protected static T ChooseRandom<T>(T[] arr)
    {
        var rnd = new Random();
        return arr[rnd.Next(arr.Length)];
    }
}
