using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Learn C# in 10 minutes", "CodeWithWealth", 600);
        Video video2 = new Video("The future of AI", "TechWorld", 1200);
        Video video3 = new Video("Top 10 Travel Destinations", "ExploreWithUs", 900);

        video1.AddComment(new Comment("Alice", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Bob", "Could you do one for Python?"));
        video1.AddComment(new Comment("Charlie", "This was clear and concise."));

        video2.AddComment(new Comment("Diana", "AI is so exciting!"));
        video2.AddComment(new Comment("Ethan", "I'm worried about jobs..."));
        video2.AddComment(new Comment("Faith", "Great explanations."));

        video3.AddComment(new Comment("George", "I want to visit Japan now."));
        video3.AddComment(new Comment("Hannah", "Italy should be number one!"));
        video3.AddComment(new Comment("Ian", "Thanks for the travel ideas."));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (var video in videos)
        {
            video.Display();
        }
    }
}