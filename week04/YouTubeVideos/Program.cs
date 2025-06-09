using System;
using System.Collections.Generic;

// Represents a comment on a video.
public class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

// Represents a YouTube video, with title, author, length, and a list of comments.
public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthSeconds { get; set; }
    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int lengthSeconds)
    {
        Title = title;
        Author = author;
        LengthSeconds = lengthSeconds;
    }

    // Adds a comment to this video.
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Returns the number of comments on this video.
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    // Returns all comments for this video.
    public List<Comment> GetComments()
    {
        return _comments;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("How to Train Your Cat", "PetExpert", 330);
        video1.AddComment(new Comment("Alice", "This worked for my cat!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "I love your videos!"));

        Video video2 = new Video("Unboxing Smart Watch", "TechGuy", 480);
        video2.AddComment(new Comment("Dana", "Is it waterproof?"));
        video2.AddComment(new Comment("Eli", "Can you review the battery life?"));
        video2.AddComment(new Comment("Fay", "Looks stylish!"));

        Video video3 = new Video("Morning Yoga Routine", "YogaWithSam", 600);
        video3.AddComment(new Comment("Grace", "Feeling refreshed!"));
        video3.AddComment(new Comment("Hank", "Can beginners do this?"));
        video3.AddComment(new Comment("Ivy", "Great instructions."));

        // Store all videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display information about each video and its comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.Name}: {comment.Text}");
            }
            Console.WriteLine(new string('-', 40));
        }
    }
}
