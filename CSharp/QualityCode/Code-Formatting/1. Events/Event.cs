using System;
using System.Text;

/// <summary>
/// This class creates an event who can
/// have date, title and location. The event can
/// also be comparable with other events.
/// </summary>
public class Event : IComparable
{
    #region Fields and constructors

    // Changing fields from public to private and initializing 
    // them with their default values
    private DateTime date = new DateTime();
    private string title = string.Empty;
    private string location = string.Empty;
    
    // Constructor
    public Event(DateTime date, string title, string location)
    {
        // Setting the properties (instead of fields) 
        // for better encapsulation
        this.Date = date;
        this.Title = title;
        this.Location = location;
    }

    #endregion

    #region Properties

    public DateTime Date
    {
        get
        {
            return this.date;
        }

        set
        {
            if (value == null)
            {
                throw new ArgumentNullException(
                    "Date value cannot be null.");
            }

            this.date = value;
        }
    }

    public string Title
    {
        get
        {
            return this.title;
        }

        set
        {
            if (value == null)
            {
                throw new ArgumentNullException(
                    "Title value cannot be null.");
            }

            this.title = value;
        }
    }

    public string Location
    {
        get
        {
            return this.location;
        }

        set
        {
            if (value == null)
            {
                throw new ArgumentNullException(
                    "Location value cannot be null.");
            }

            this.location = value;
        }
    }

    #endregion

    #region Methods

    public int CompareTo(object currentObject)
    {
        Event otherObject = currentObject as Event;

        int byDate = this.date.CompareTo(otherObject.date);
        int byTitle = this.title.CompareTo(otherObject.title);
        int byLocation = this.location.CompareTo(otherObject.location);

        if (byDate == 0)
        {
            if (byTitle == 0)
            {
                return byLocation;
            }
            else
            {
                return byTitle;
            }
        }
        else
        {
            return byDate;
        }
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result.Append(this.date.ToString(
            "yyyy-MM-ddTHH:mm:ss"));
        result.Append(" | " + this.title);

        if ((this.location != null) && (this.location != string.Empty))
        {
            result.Append(" | " + this.location);
        }

        return result.ToString();
    }

    #endregion
}
