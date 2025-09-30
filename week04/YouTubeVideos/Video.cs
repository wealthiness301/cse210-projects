using System;
using System.Collections.Generic;
public class Video
{
    public string Title { get; }
    public string Author { get; }
    public int LengthSeconds { get; }
    private List<Comment> Comments { get; }
    public Video(string title, string author, int lengthSeconds)
    {
        Title = title;
        Author = author;
        LengthSeconds = lengthSeconds;
        Comments = new List<Comment>();
    }
    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }
    public int GetCommentCount()
    {
        return Comments.Count;
    }
    public void Display()
    {
        Console.WriteLine($"\nVideo: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthSeconds} seconds");
        Console.WriteLine($"Comments ({GetCommentCount()})");
        
        foreach (var comment in Comments)
        {
            comment.Display();
        }
    }
}