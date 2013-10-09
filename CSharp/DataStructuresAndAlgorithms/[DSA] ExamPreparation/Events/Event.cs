//using System;
//using System.Globalization;

//public class Event : IComparable<Event>
//{
//    public const string DateFormat = "{0:yyyy-MM-ddTHH:mm:ss}";

//    public Event()
//    {
//    }

//    public Event(string date, string title)
//    {
//        this.Date = DateTime.Parse(date);
//        this.Title = title;
//    }

//    public Event(string date, string title, string location)
//        : this(date, title)
//    {
//        this.Location = location;
//    }

//    public DateTime Date { get; set; }
//    public string Title { get; set; }
//    public string Location { get; set; }

//    public int CompareTo(Event other)
//    {
//        int compareResult = DateTime.Compare(this.Date, other.Date);
//        if (compareResult == 0)
//        {
//            compareResult = string.Compare(this.Title, other.Title);
//        }

//        if (compareResult == 0)
//        {
//            compareResult = string.Compare(this.Location, other.Location);
//        }

//        return compareResult;
//    }

//    public override int GetHashCode()
//    {
//        int prime = 17;
//        int result = 1;
//        unchecked
//        {
//            result = result * prime + this.Date.GetHashCode();
//            result = result * prime + this.Title.GetHashCode();
//            result = result * prime + this.Location.GetHashCode();
//        }

//        return result;
//    }

//    public override string ToString()
//    {
//        string formattedDate = string.Format(DateFormat, this.Date);
//        string result = string.Empty;
//        if (this.Location != null)
//        {
//            result = string.Format("{0} | {1} | {2}", formattedDate, this.Title, this.Location);
//        }
//        else
//        {
//            result = string.Format("{0} | {1}", formattedDate, this.Title);
//        }

//        return result;
//    }
//}
