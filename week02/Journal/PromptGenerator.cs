using System;
public class PromptGenerator
{
    List<string> _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today",
            "What was the best part in my day",
            "How did I see the hand of the lord ",
            "What was the strongest emotion I felt today",
            "If I had one thing I could do over today, what would it be"
        };
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int count = _prompts.Count;
        int index = random.Next(0, count);
        return _prompts[index];
    }
}