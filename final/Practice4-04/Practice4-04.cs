using System;
using System.Collections.Generic;




class Program
{

    static void Main(string[] args)
    {
        Console.Clear();
        List<Activity> newActivityList = new List<Activity>();
        
        Running newRun = new Running(30, 3.0);
        Swimming newSwim = new Swimming(newTime: 30, newLaps: 10);
        Cycling newCycling= new Cycling(30, 12.0);

        newActivityList.Add(newRun);
        newActivityList.Add(item: newSwim);
        newActivityList.Add(newCycling);

        foreach (Activity activity in newActivityList)
        {
            activity.GetDistance();
            activity.GetSpeed();
            activity.GetPace();
            activity.GetSummary();
        }
        
    }


}

class Activity
{
    public double distance;
    public double speed;
    public double pace;
    public string date;
    public double minutes;
    public string activityType;


    public void GetSummary()
    {
        Console.WriteLine(date + " " + activityType + "(" + minutes + ")- " + "Distance: " + distance.ToString("0.00") + " miles" + ", Speed: " + speed.ToString("0.00") + " mph" + ", Pace: " + pace.ToString("0.00") + " min per mile");
    }

    public virtual void GetSpeed()
    {
    }
    public virtual void GetDistance()
    {
    }
    public virtual void GetPace()
    {
    }

}

class Running : Activity
{

    public Running(double newTime, double newDistance)
    {
        minutes = newTime;
        distance = newDistance;
        activityType = "Running";
        date = "10/25/2022";
    }

    public override void GetSpeed()
    {
        speed = (distance / minutes) * 60;
    }

    public override void GetDistance()
    {
        // distance = lap * 50 / 1000 * 0.62f;
    }

    public override void GetPace()
    {
        pace = minutes / distance;
    }

    
}

class Swimming : Activity
{

    public int laps;
    public Swimming(int newTime, int newLaps)
    {
        minutes = newTime;
        laps = newLaps;
        activityType = "Swimming";
        date = "10/25/2022";
    }

    public override void GetSpeed()
    {
        speed = (distance / minutes) * 60;
    }

    public override void GetDistance()
    {
        distance = (double)(laps * 50.0 / 1000.0 * 0.62);
    }

    public override void GetPace()
    {
        pace = minutes / distance;
    }
}

class Cycling : Activity
{   
    public Cycling(double newTime, double newDistance)
    {
        minutes = newTime;
        distance = newDistance;
        activityType = "Cycling";
        date = "10/25/2022";
    }

    public override void GetSpeed()
    {
        speed = (distance / minutes) * 60;
    }

    public override void GetDistance()
    {
        // distance = distance;
    }

    public override void GetPace()
    {
        pace = minutes / distance;
    }
}