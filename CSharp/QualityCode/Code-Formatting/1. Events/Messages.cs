using System;

/// <summary>
/// This class creates and controls the messages 
/// after executing specific commands.
/// </summary>
public static class Messages
{
    public static void EventAdded()
    {
        EventEngine.AddOutput("Event added");
    }

    public static void EventRemoved(int x)
    {
        if (x == 0)
        {
            NoEventsFound();
        }
        else
        {
            string formattedMessage = string.Format(
                "{0} events deleted\n", x);

            EventEngine.AddOutput(formattedMessage);
        }
    }

    public static void NoEventsFound() 
    {
        EventEngine.AddOutput("No events found");
    }

    public static void PrintEvent(Event eventToPrint)
    {
        if (eventToPrint != null)
        {
            EventEngine.AddOutput(eventToPrint.ToString());
        }
    }
}
