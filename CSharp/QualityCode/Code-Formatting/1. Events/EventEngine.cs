using System;
using System.Text;

/// <summary>
/// This class implements the main logic in 
/// our project. First we read commands from
/// the console, then we execute them according
/// to the information given. The commands consist 
/// of adding, removing, listing events and also
/// getting their parameters.
/// </summary>
public class EventEngine
{
    // Fields
	private static StringBuilder output = new StringBuilder();
    private static EventHolder events = new EventHolder();

    #region Methods

    // Creating add output method in order to
    // encapsulate the output field
    public static void AddOutput(string message)
    {
        output.AppendLine(message);
    }

    private static bool ExecuteNextCommand()
    {
        string command = Console.ReadLine();

        if (command[0] == 'A')
        {
            AddEvent(command);
            return true;
        }

        if (command[0] == 'D')
        {
            RemoveEvents(command);
            return true;
        }

        if (command[0] == 'L')
        {
            ListEvents(command);
            return true;
        }

        if (command[0] == 'E')
        {
            return false;
        }

        return false;
    }

    private static void AddEvent(string command)
    {
        DateTime date = new DateTime();
        string title = string.Empty;
        string location = string.Empty;

        GetParameters(
            command,
            "AddEvent",
            out date,
            out title,
            out location);

        events.AddEvent(date, title, location);
    }

    private static void RemoveEvents(string command)
    {
        string title = command.Substring(
            "RemoveEvents".Length + 1);

        events.RemoveEvents(title);
    }

    private static void ListEvents(string command)
    {
        int pipeIndex = command.IndexOf('|');
        string countString = command.Substring(pipeIndex + 1);
        int count = int.Parse(countString);

        DateTime date = GetDate(command, "ListEvents");

        events.ListEvents(date, count);
    }

    private static void GetParameters(
        string commandForExecution,
        string commandType,
        out DateTime dateAndTime,
        out string eventTitle,
        out string eventLocation)
    {
        dateAndTime = GetDate(commandForExecution, commandType);

        int firstPipeIndex = commandForExecution.IndexOf('|');
        int lastPipeIndex = commandForExecution.LastIndexOf('|');

        // Checking if there is only one "|",
        // if so, the command has value only for title and
        // location is set to empty.
        if (firstPipeIndex == lastPipeIndex)
        {
            eventTitle = commandForExecution.Substring(
                firstPipeIndex + 1).Trim();

            eventLocation = string.Empty;
        }
        else
        {
            eventTitle = commandForExecution.Substring(
                firstPipeIndex + 1,
                lastPipeIndex - firstPipeIndex - 1).Trim();
                         
            eventLocation = commandForExecution.Substring(
                lastPipeIndex + 1).Trim();
        }
    }

    private static DateTime GetDate(string command, string commandType)
    {
        DateTime date = DateTime.Parse(
            command.Substring(commandType.Length + 1, 19));
            
        return date;
    }

	private static void Main() 
    {
		while (ExecuteNextCommand()) 
        { 
        }

		Console.WriteLine(output);
	}

    #endregion
}