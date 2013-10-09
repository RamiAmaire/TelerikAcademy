using System;
using System.Collections.Generic;
using System.Text;
using Wintellect.PowerCollections;

public class Demo
{
    public static void Main()
    {
        QueueHandler tMarket = new QueueHandler();
        while (true)
        {
            string[] attribs = Console.ReadLine().Split(new string[] {" ", "\t", "/t" },
                StringSplitOptions.RemoveEmptyEntries);

            switch (attribs[0])
            {
                case "Append":
                    tMarket.Append(attribs[1]);
                    break;
                case "Insert":
                    tMarket.Insert(int.Parse(attribs[1]), attribs[2]);
                    break;
                case "Find":
                    tMarket.Find(attribs[1]);
                    break;
                case "Serve":
                    tMarket.Serve(int.Parse(attribs[1]));
                    break;
                case "End":
                    Console.WriteLine(tMarket.Buffer.ToString());
                    return;
                default: break;
            }
        }
    }
}

public class QueueHandler
{
    private readonly BigList<string> list;
    private readonly Dictionary<string, int> dict;

    public QueueHandler()
    {
        this.list = new BigList<string>();
        this.dict = new Dictionary<string,int>();
        this.Buffer = new StringBuilder();
    }

    public StringBuilder Buffer { get; set; }

    public void Append(string name)
    {
        this.list.Add(name);
        if (!this.dict.ContainsKey(name))
        {
            this.dict[name] = 1;
        }
        else
        {
            this.dict[name]++;
        }

        this.Buffer.AppendLine("OK");
    }

    public void Insert(int position, string name)
    {
        if (position < 0 || position > this.list.Count)
        {
            this.Buffer.AppendLine("Error");
        }
        else
        {
            this.list.Insert(position, name);
            if (!this.dict.ContainsKey(name))
            {
                this.dict[name] = 1;
            }
            else
            {
                this.dict[name]++;
            }

            this.Buffer.AppendLine("OK");
        }
    }

    public void Find(string name)
    {
        if (!this.dict.ContainsKey(name))
        {
            this.Buffer.AppendLine("0");
        }
        else
        {
            this.Buffer.AppendLine(this.dict[name].ToString());
        }
    }

    public void Serve(int count)
    {
        if (count > this.list.Count)
        {
            this.Buffer.AppendLine("Error");
        }
        else
        {
            while (count > 0)
            {
                if (count == 1)
                {
                    this.Buffer.AppendLine(this.list[0]);
                }
                else
                {
                    this.Buffer.Append(this.list[0] + " ");
                }

                this.dict.Remove(this.list[0]);
                this.list.Remove(this.list[0]);
                count--;
            }
        }
    }
}

