using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("Cat Tricks Compilation", "PetWorld", 320);
        Video video2 = new Video("2025 Tech Unboxing", "GadgetGuy", 610);
        Video video3 = new Video("Beginner Yoga Flow", "YogaWithAnna", 475);

        // Add comments to each video
        video1.AddComment(new Comment("Alice", "My cat does this too!"));
        video1.AddComment(new Comment("Ben", "So funny!"));
        video1.AddComment(new Comment("Cara", "Great editing."));

        video2.AddComment(new Comment("Dan", "Thanks for the review!"));
        video2.AddComment(new Comment("Eli", "Which phone do you like best?"));
        video2.AddComment(new Comment("Faye", "Can you test the battery next time?"));

        video3.AddComment(new Comment("Grace", "Loved this routine."));
        video3.AddComment(new Comment("Henry", "Very calming."));
        video3.AddComment(new Comment("Ivy", "Please do more videos like this."));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display all video info and comments
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
