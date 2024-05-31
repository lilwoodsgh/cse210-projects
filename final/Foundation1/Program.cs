using System;
using System.Collections.Generic;

namespace YouTubeVideoTracker
{
    public class Comment
    {
        public string CommenterName { get; set; }
        public string Text { get; set; }

        public Comment(string commenterName, string text)
        {
            CommenterName = commenterName;
            Text = text;
        }
    }

    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Length { get; set; } // Length in seconds
        private List<Comment> comments;

        public Video(string title, string author, int length)
        {
            Title = title;
            Author = author;
            Length = length;
            comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            comments.Add(comment);
        }

        public int GetCommentCount()
        {
            return comments.Count;
        }

        public List<Comment> GetComments()
        {
            return comments;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create 3-4 videos
            Video video1 = new Video("Drawing shapes in photoshop", "Kweku Menu", 800);
            Video video2 = new Video("Understanding programming with classes", "Godwin Elorm", 900);
            Video video3 = new Video("csharp for beginners", "Comfort Woods", 900);

            // Add comments to each video
            video1.AddComment(new Comment("Kweku", "Great video! Thanks for the tips."));
            video1.AddComment(new Comment("Kofi", "thank you making it soo easy to understand!"));
            video1.AddComment(new Comment("Attah", "Very helpful, I gt it all figured out now. See you soon with my works!"));

            video2.AddComment(new Comment("Ama", "This helped me a lot in completing my assignments."));
            video2.AddComment(new Comment("Billy", "Could you explain more about classes in your next video?"));
            video2.AddComment(new Comment("Serwaa", "Amazing explanation, kindly add the link to the files in the comment section"));

            video3.AddComment(new Comment("Afia", "great video, its actually my first time learning c#, but i think i like it!"));
            video3.AddComment(new Comment("Fosuaa", "Perfect for beginners, thanks!"));
            video3.AddComment(new Comment("Maame", "Kindly rop the link to the other resources so i can practice them"));

            // Put videos in a list
            List<Video> videos = new List<Video> { video1, video2, video3 };

            // Iterate through the list of videos and display details
            foreach (Video video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.Length} seconds");
                Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
                Console.WriteLine("Comments:");

                foreach (Comment comment in video.GetComments())
                {
                    Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
                }

                Console.WriteLine(); // Add a blank line between videos for readability
            }
        }
    }
}
