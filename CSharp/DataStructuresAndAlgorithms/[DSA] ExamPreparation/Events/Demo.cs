using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Wintellect.PowerCollections;
using System.Globalization;

public class Demo
{
    private static void TrimAll(string[] attribs)
    {
        for (int i = 0; i < attribs.Length; i++)
        {
            attribs[i] = attribs[i].Trim();
        }
    }

    private static void ProccesCommand(EventHandler mallSofia, string line)
    {
        int indexOfFirstWS = line.IndexOf(' ');
        string commandType = line.Substring(0, indexOfFirstWS);
        string[] attribs = line.Substring(indexOfFirstWS + 1).Split(
            new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
        TrimAll(attribs);

        if (commandType == "AddEvent")
        {
            Event ev = new Event(attribs[0], attribs[1]);
            if (attribs.Length == 3)
            {
                ev.Location = attribs[2];
            }

            mallSofia.AddEvent(ev);
        }

        if (commandType == "DeleteEvents")
        {
            mallSofia.DeleteEvents(attribs[0]);
        }

        if (commandType == "ListEvents")
        {
            mallSofia.ListEvents(attribs[0], attribs[1]);
        }
    }

    public static void Main()
    {
        EventHandler mallSofia = new EventHandler();
        while (true)
        {
            string line = Console.ReadLine();
            if (line == "End")
            {
                break;
            }

            ProccesCommand(mallSofia, line);
        }

        Console.WriteLine(mallSofia.Buffer.ToString());
    }
}

public class EventHandler
{
    private readonly MultiDictionary<string, Event> byTitle;
    private readonly OrderedBag<Event> byDate;

    public EventHandler()
    {
        this.byTitle = new MultiDictionary<string, Event>(true);
        this.byDate = new OrderedBag<Event>();
        this.Buffer = new StringBuilder();
    }

    public StringBuilder Buffer { get; set; }

    public void AddEvent(Event ev)
    {
        this.byTitle.Add(ev.Title.ToLower(), ev);
        this.byDate.Add(ev);
        this.Buffer.AppendLine("Event added");
    }

    public void DeleteEvents(string title)
    {
        string titleToLower = title.ToLower();
        if (this.byTitle.ContainsKey(titleToLower))
        {
            List<Event> eventsForDeletion = this.byTitle[titleToLower].ToList();
            this.byTitle.Remove(titleToLower);
            this.Buffer.AppendLine(eventsForDeletion.Count + " events deleted");

            foreach (var ev in eventsForDeletion)
            {
                this.byDate.Remove(ev);
            }
        }
        else
        {
            this.Buffer.AppendLine("No events found");
        }
    }

    public void ListEvents(string date, string count)
    {
        DateTime formattedDate = DateTime.Parse(date);
        int counts = int.Parse(count);
        List<Event> eventsToBeListed = this.byDate.RangeFrom(new Event() { Date = formattedDate }, true).
            Take(counts).ToList();

        if (eventsToBeListed.Count == 0)
        {
            this.Buffer.AppendLine("No events found");
        }
        else
        {
            this.AppendEvents(eventsToBeListed);
        }
    }

    private void AppendEvents(List<Event> events)
    {
        events.Sort();
        foreach (var ev in events)
        {
            this.Buffer.AppendLine(ev.ToString());
        }
    }
}

public class Event : IComparable<Event>
{
    public const string DateFormat = "{0:yyyy-MM-ddTHH:mm:ss}";

    public Event()
    {
    }

    public Event(string date, string title)
    {
        this.Date = DateTime.Parse(date);
        this.Title = title;
    }

    public Event(string date, string title, string location)
        : this(date, title)
    {
        this.Location = location;
    }

    public DateTime Date { get; set; }
    public string Title { get; set; }
    public string Location { get; set; }

    public int CompareTo(Event other)
    {
        int compareResult = DateTime.Compare(this.Date, other.Date);
        if (compareResult == 0)
        {
            compareResult = string.Compare(this.Title, other.Title);
        }

        if (compareResult == 0)
        {
            compareResult = string.Compare(this.Location, other.Location);
        }

        return compareResult;
    }

    public override int GetHashCode()
    {
        int prime = 17;
        int result = 1;
        unchecked
        {
            result = result * prime + this.Date.GetHashCode();
            result = result * prime + this.Title.GetHashCode();
            result = result * prime + this.Location.GetHashCode();
        }

        return result;
    }

    public override string ToString()
    {
        string formattedDate = string.Format(DateFormat, this.Date);
        string result = string.Empty;
        if (this.Location != null)
        {
            result = string.Format("{0} | {1} | {2}", formattedDate, this.Title, this.Location);
        }
        else
        {
            result = string.Format("{0} | {1}", formattedDate, this.Title);
        }

        return result;
    }
}
