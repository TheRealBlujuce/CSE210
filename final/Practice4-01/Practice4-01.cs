using System;
using System.Collections.Generic;




class Program
{

    static void Main(string[] args)
    {

        List<Video> videoList = new List<Video>();
        Video vidOne = new Video("Urshifu OP in Pokemon Unite!", "Blujuce", 12.45f);
        Video vidTwo = new Video("Dragonflight is actually..fun?", "Blujuce", 14.75f);
        Video vidThree = new Video("New Pokemon Scarlet and Violet DLC Leaks!", "Blujuce", 20.25f);
        Video vidFour = new Video("How to survive 2023 as a college student", "Blujuce", 8.69f);

        videoList.Add(vidOne);
        videoList.Add(vidTwo);
        videoList.Add(vidThree);
        videoList.Add(vidFour);

        foreach (Video video in videoList)
        {
            for (var i = 0; i < 4; i++)
            {
                // constructor creates new comment
                Comment newComment = new Comment("Will", "This is my comment. I think the video is great!");

                // comment is then added to list
                video.AddToComments(newComment);
            }
        }

        foreach(Video video in videoList) 
        {
            Console.WriteLine("Video Title: " + video.GetTitle());
            Console.WriteLine("Video Author: " + video.GetAuthor());
            Console.WriteLine("Video Length: " + video.GetVidLength());
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            Console.WriteLine(comment.GetComment());
            Console.WriteLine("----------------------------------");
            Console.WriteLine("");
        }


    }


}



// this is to store videos
class Video
{
    private string vidTitle;
    private string vidAuthor;
    private float vidLength;
    private List<Comment> vidComments = new List<Comment>();

    public Video(string newVideoTitle, string newVideoAuthor, float newVideoLength)
    {
        vidTitle = newVideoTitle;
        vidAuthor = newVideoAuthor;
        vidLength = newVideoLength;
    }


    public void AddToComments(Comment newComment)
    {   
        vidComments.Add(newComment);
    }

    public string GetTitle()
    {
        return vidTitle;
    }
    public string GetAuthor()
    {
        return vidAuthor;
    }
    public float GetVidLength()
    {
        return vidLength;
    }

    public List<Comment> GetComments()
    {
        return vidComments;
    }

}

// this is to store comments
class Comment
{
    private string name;
    private string comment;

    public Comment(string newName, string newComment)
    {
        name = newName;
        comment = newComment;
    }

    // getter and setter for name
    public string GetName()
    {
        return name;
    }

    public void SetName(string newName)
    {
        name = newName;
    }
    // getter and setter for comment
    public string GetComment()
    {
        return comment;
    }

    public void SetComment(string newComment)
    {
        comment = newComment;
    }


}