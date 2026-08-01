using System;
class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("C# Basics", "Jane Doe", 600);
        video1._comments.Add(new Comment("Alex", "Great explanation!"));
        video1._comments.Add(new Comment("Sam", "This helped a lot, thanks."));
        video1._comments.Add(new Comment("Priya", "Can you cover interfaces next?"));
        videos.Add(video1);

        Video video2 = new Video("Learning Python", "John Smith", 900);
        video2._comments.Add(new Comment("Maria", "Very clear tutorial."));
        video2._comments.Add(new Comment("Chris", "Subscribed!"));
        video2._comments.Add(new Comment("Dana", "Loved the examples."));
        videos.Add(video2);

        Video video3 = new Video("Guitar Tutorial", "Mike Lee", 450);
        video3._comments.Add(new Comment("Lena", "Finally I understand chords."));
        video3._comments.Add(new Comment("Omar", "Great pacing."));
        video3._comments.Add(new Comment("Tara", "More songs please!"));
        videos.Add(video3);

        Video video4 = new Video("Baking Bread", "Sara Kim", 720);
        video4._comments.Add(new Comment("Nina", "My bread turned out perfect."));
        video4._comments.Add(new Comment("Leo", "Thanks for the tips."));
        video4._comments.Add(new Comment("Ivy", "Can you do sourdough next?"));
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._length} seconds");
            Console.WriteLine($"Number of comments: {video.getCommentsCount()}");

            foreach (Comment comment in video._comments)
            {
                Console.WriteLine($"  - {comment._pname}: {comment._pcomment}");
            }

            Console.WriteLine();
        }
    }
}