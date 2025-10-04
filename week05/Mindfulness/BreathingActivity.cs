using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity",
               "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void RunActivity()
    {
        int duration = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        // Alternate "Breathe in..." and "Breathe out..." until time is up.
        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.WriteLine("Breathe in...");
            int secondsLeft = (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds);
            int inhale = Math.Min(4, Math.Max(1, secondsLeft)); // 4s inhale (or remainder)
            ShowCountdown(inhale);

            if (DateTime.Now >= endTime) break;

            Console.WriteLine();
            Console.WriteLine("Breathe out...");
            secondsLeft = (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds);
            int exhale = Math.Min(6, Math.Max(1, secondsLeft)); // 6s exhale (or remainder)
            ShowCountdown(exhale);
        }
    }
}
