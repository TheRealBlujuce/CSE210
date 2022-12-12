using System;
using System.Collections.Generic;




class Program
{

    static void Main(string[] args)
    {

        Address newAddress = new Address("1300 Home Street", "Centerville", "Utah", "United States", Address.Country.USA);

        string newLectureDescription = "What makes making a game so difficult as a solo indie developer? Will Marda explains the challenges and difficluties of the subject based on his own experience.";
        Lecture newLecture = new Lecture("New Game+", "Will Marda", newLectureDescription, 1500, "10/16/2023", "4pm MDT", newAddress.GetFullAdress());

        string newReceptionDescription = "Will Marda's non-existant marriage";
        Reception newReception = new Reception("Will Marda and non-existant fiance's Reception", true, newReceptionDescription, "7/21/2023", "2pm MDT", newAddress.GetFullAdress());
        
        string newOutdoorGatheringDescription = "Just eating a picnic outside";
        OutdoorGathering newGathering = new OutdoorGathering("Outdoor Picnic", "Clear Skies", newOutdoorGatheringDescription, "4/12/2023", "12pm MDT", newAddress.GetFullAdress());
        
        Console.WriteLine("Lecture");
        Console.WriteLine(value: "");
        newLecture.StandardDetails();
        Console.WriteLine(value: "");
        newLecture.FullDetails();
        Console.WriteLine(value: "");
        newLecture.ShortDetails();
        Console.WriteLine(value: "---------------------------------");

        Console.WriteLine("Reception");
        Console.WriteLine(value: "");
        newReception.StandardDetails();
        Console.WriteLine(value: "");
        newReception.FullDetails();
        Console.WriteLine(value: "");
        newReception.ShortDetails();
        Console.WriteLine(value: "---------------------------------");

        Console.WriteLine("Outdoor Gathering");
        Console.WriteLine(value: "");
        newGathering.StandardDetails();
        Console.WriteLine(value: "");
        newGathering.FullDetails();
        Console.WriteLine(value: "");
        newGathering.ShortDetails();
        Console.WriteLine(value: "---------------------------------");
        
    }


}


class Event
{
    public string title;
    public string description;
    public string date;
    public string time;
    public string adress;

    public virtual void StandardDetails()
    {
        Console.WriteLine("Name of Event: " + title);
        Console.WriteLine("Event Description: \n" + description);
        Console.WriteLine(date + ", " + time);
        Console.WriteLine(adress);
    }

    public virtual void FullDetails()
    {
        Console.WriteLine("Name of Event: " + title);
        Console.WriteLine("Event Description: \n" + description);
        Console.WriteLine(date + ", " + time);
        Console.WriteLine(adress);
    }

    public virtual void ShortDetails()
    {
        // event type
        Console.WriteLine("Name of Event: " + title);
        Console.WriteLine(date + ", " + time);
    }


}

class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string newTitle, string newSpeaker, string newDescription, int newCapacity, string newDate, string newTime, string newAddress)
    {
        title = newTitle;
        speaker = newSpeaker;
        description = newDescription;
        capacity = newCapacity;
        date = newDate;
        time = newTime;
        adress = newAddress;
    }

    
    public override void FullDetails()
    {
        Console.WriteLine("Name of Event: " + title);
        Console.WriteLine("Name of Speaker: " + speaker);
        Console.WriteLine("Event Description: \n" + description);
        Console.WriteLine("Guest Capacity: " + capacity);
        Console.WriteLine(date + ", " + time);
        Console.WriteLine(adress);
    }

    public override void ShortDetails()
    {
        Console.WriteLine("Event Type: Lecture");
        base.ShortDetails();
    }

}

class Reception : Event
{
    bool didRSVP;
    string hasRSVP;

    public Reception(string newTitle, bool newRSVP, string newDescription, string newDate, string newTime, string newAddress)
    {
        title = newTitle;
        didRSVP = newRSVP;
        description = newDescription;
        date = newDate;
        time = newTime;
        adress = newAddress;
    }

   private void CheckRSVP()
   {
        if (didRSVP == true){ hasRSVP = "Has RSVP'd";} else { hasRSVP = "Not RSVP'd";}
   }

    public override void FullDetails()
    {
        Console.WriteLine("Name of Event: " + title);
        Console.WriteLine("Event Description: \n" + description);
        Console.WriteLine("Is RSVP'd?: " + hasRSVP);
        Console.WriteLine(date + ", " + time);
        Console.WriteLine(adress);
    }

    public override void ShortDetails()
    {
        Console.WriteLine("Event Type: Reception");
        base.ShortDetails();
    }

}

class OutdoorGathering : Event
{
    string weatherForecast;

    public OutdoorGathering(string newTitle, string newForecast, string newDescription, string newDate, string newTime, string newAddress)
    {
        title = newTitle;
        weatherForecast = newForecast;
        description = newDescription;
        date = newDate;
        time = newTime;
        adress = newAddress;
    }

    public override void FullDetails()
    {
        Console.WriteLine("Name of Event: " + title);
        Console.WriteLine("Event Description: \n" + description);
        Console.WriteLine(date + ", " + time);
        Console.WriteLine(adress);
        Console.WriteLine("Weather Forecast?: " + weatherForecast);
    }

    public override void ShortDetails()
    {
        Console.WriteLine("Event Type: Reception");
        base.ShortDetails();
    }


}

class Address
{
    private string street = "";
    private string city = "";
    private string state = "";
    private string countryName = "";
    private Country country = Country.USA;

    public enum Country
    {
        USA,
        OTHER
    }

    public Address(string streetName, string cityName, string stateName, string newCountryName, Country currentCountry)
    {
        street = streetName;
        city = cityName;
        state = stateName;
        countryName = newCountryName;
        country = currentCountry;
    }   

    public string GetStreetName()
    {
        return street;
    }
    public string GetCityName()
    {
        return city;
    }
    public string GetStateName()
    {
        return state;
    }
    public string GetCountryName()
    {
        return countryName;
    }
    public Country GetCountry()
    {
        return country;
    }

    public string GetFullAdress()
    {
        return GetStreetName() + ", " + GetCityName() + ", " + GetStateName() + ", " + GetCountryName();
    }

}