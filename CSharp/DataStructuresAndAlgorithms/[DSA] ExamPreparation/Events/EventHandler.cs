//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Linq;
//using Wintellect.PowerCollections;
//using System.Globalization;

//public class EventHandler
//{
//    private readonly MultiDictionary<string, Event> byTitle;
//    private readonly OrderedBag<Event> byDate;

//    public EventHandler()
//    {
//        this.byTitle = new MultiDictionary<string, Event>(true);
//        this.byDate = new OrderedBag<Event>();
//        this.Buffer = new StringBuilder();
//    }

//    public StringBuilder Buffer { get; set; }

//    public void AddEvent(Event ev)
//    {
//        this.byTitle.Add(ev.Title.ToLower(), ev);
//        this.byDate.Add(ev);
//        this.Buffer.AppendLine("Event added");
//    }

//    public void DeleteEvents(string title)
//    {
//        string titleToLower = title.ToLower();
//        if (this.byTitle.ContainsKey(titleToLower))
//        {
//            List<Event> eventsForDeletion = this.byTitle[titleToLower].ToList();
//            this.byTitle.Remove(titleToLower);
//            this.Buffer.AppendLine(eventsForDeletion.Count + " events deleted");

//            foreach (var ev in eventsForDeletion)
//            {
//                this.byDate.Remove(ev);
//            }
//        }
//        else
//        {
//            this.Buffer.AppendLine("No events found");
//        }
//    }

//    public void ListEvents(string date, string count)
//    {
//        DateTime formattedDate = DateTime.Parse(date);
//        int counts = int.Parse(count);
//        List<Event> eventsToBeListed = this.byDate.RangeFrom(new Event() { Date = formattedDate }, true).
//            Take(counts).ToList();

//        if (eventsToBeListed.Count == 0)
//        {
//            this.Buffer.AppendLine("No events found");
//        }
//        else
//        {
//            this.AppendEvents(eventsToBeListed);
//        }
//    }

//    private void AppendEvents(List<Event> events)
//    {
//        events.Sort();
//        foreach (var ev in events)
//        {
//            this.Buffer.AppendLine(ev.ToString());
//        }
//    }
//}

