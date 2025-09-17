using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int choice = 0;
        while (choice != 5)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");

            // ✅ Input validation
            Console.Write("Choose an option: ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out choice) || choice < 1 || choice > 5)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                choice = 0; // Keep loop going
                continue;
            }

            switch (choice)
            {
                case 1: // Write new entry
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    string response = Console.ReadLine();

                    Console.Write("What is your mood today? "); // Exceeding requirement
                    string mood = Console.ReadLine();

                    string date = DateTime.Now.ToShortDateString();

                    Entry entry = new Entry
                    {
                        _date = date,
                        _promptText = prompt,
                        _entryText = response,
                        _mood = mood
                    };

                    journal.AddEntry(entry);
                    Console.WriteLine("Entry added!");
                    break;

                case 2: // Display journal
                    journal.Display();
                    break;

                case 3: // Save to file
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    Console.WriteLine("Journal saved!");
                    break;

                case 4: // Load from file
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    Console.WriteLine("Journal loaded!");
                    break;

                case 5: // Quit
                    Console.WriteLine("Goodbye!");
                    break;
            }
        }
    }
}
// 📌 Exceeding requirement:
// Added a "Mood" field to each journal entry.
// Now users can record how they felt along with their response.
