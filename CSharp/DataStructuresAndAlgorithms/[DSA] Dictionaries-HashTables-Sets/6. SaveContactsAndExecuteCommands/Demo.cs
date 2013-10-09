using System;
using System.Collections.Generic;
using System.IO;
using Wintellect.PowerCollections;
using System.Linq;

public class Demo
{
    private static void Trim(string[] data)
    {
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = data[i].Trim();
        }
    }

    private static Bag<Contact> SaveContacts()
    {
        string line = string.Empty;
        string path = @"TextFiles\phones.txt";
        string fullPath = System.IO.Path.GetFullPath(path);
        Bag<Contact> contacts = new Bag<Contact>();

        using (StreamReader reader = new StreamReader(fullPath))
        {
            line = reader.ReadLine();
            while (line != null)
            {
                string[] contactData = ParseInput(line);
                contacts.Add(ParseContact(contactData));
                line = reader.ReadLine();
            }
        }

        return contacts;
    }

    private static string[] ParseInput(string line)
    {
        string[] data = line.Split(new string[] {"|" }, StringSplitOptions.RemoveEmptyEntries);
        Trim(data);
        return data;
    }

    private static Contact ParseContact(string[] contactData)
    {
        Contact contact = new Contact(contactData[0], contactData[1], contactData[2]);
        return contact;
    }

    private static List<string> SaveCommands()
    {
        string line = string.Empty;
        string path = @"TextFiles\commands.txt";
        string fullPath = System.IO.Path.GetFullPath(path);
        List<string> commands = new List<string>();

        using (StreamReader reader = new StreamReader(fullPath))
        {
            line = reader.ReadLine();
            while (line != null)
            {
                line = line.Trim();
                commands.Add(line);
                line = reader.ReadLine();
            }
        }

        return commands;
    }

    private static List<Contact> ProccesCommand(string command, Bag<Contact> contacts)
    {
        string[] commandParams = command.Split(new string[] { "(", ")", "," }, StringSplitOptions.RemoveEmptyEntries);
        Trim(commandParams);

        string name = commandParams[1];
        string city = string.Empty;
        List<Contact> wantedContacts = new List<Contact>();
        if (commandParams.Length > 2)
        {
            city = commandParams[2];
            wantedContacts = contacts.FindAll(x => x.Name == name && x.City == city).ToList();
        }
        else
        {
            wantedContacts = contacts.FindAll(x => x.Name == name).ToList();
        }
        
        return wantedContacts;
    }

    private static void PrintContacts(List<Contact> contacts)
    {
        if (contacts.Count == 0)
        {
            Console.WriteLine("No contacts found.");
        }
        else
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact.ToString());
            }
        }
    }

    public static void Main()
    {
        Bag<Contact> contacts = SaveContacts();
        List<string> commands = SaveCommands();
        List<Contact> wantedContacts = new List<Contact>();

        foreach (var command in commands)
        {
            wantedContacts = ProccesCommand(command, contacts);
            PrintContacts(wantedContacts);
        }
    }
}
