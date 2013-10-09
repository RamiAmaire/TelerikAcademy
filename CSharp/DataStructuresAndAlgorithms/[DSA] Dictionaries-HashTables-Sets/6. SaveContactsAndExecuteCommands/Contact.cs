using System;

public class Contact: IComparable
{
    public Contact(string name, string city, string number)
    {
        this.Name = name;
        this.City = city;
        this.Number = number;
    }

    public string Name { get; set; }
    public string City { get; set; }
    public string Number { get; set; }

    public override bool Equals(object obj)
    {
        if (obj.GetType() != this.GetType() || obj == null)
        {
            throw new ArgumentException("Invalid object or null");
        }
        else
        {
            Contact otherContact = obj as Contact;
            if (!this.Name.Equals(otherContact.Name))
            {
                return false;
            }

            if (!this.City.Equals(otherContact.City))
            {
                return false;
            }

            if (!this.Number.Equals(otherContact.Number))
            {
                return false;
            }

            return true;
        }
    }

    public override int GetHashCode()
    {
        int prime = 17;
        int result = 1;
        unchecked
        {
            result = result * prime + this.Name.GetHashCode();
            result = result * prime + this.City.GetHashCode();
            result = result * prime + this.Number.GetHashCode();
        }

        return result;
    }

    public int CompareTo(object obj)
    {
        if (obj.GetType() != this.GetType() || obj == null)
        {
            throw new ArgumentException("Invalid object");
        }
        else
        {
            Contact otherContact = obj as Contact;
            if (this.Name == otherContact.Name)
            {
                if (this.City == otherContact.City)
                {
                    if (this.Number == otherContact.Number)
                    {
                        return 0;
                    }
                    else
                    {
                        return this.Number.CompareTo(otherContact.Number);
                    }
                }
                else
                {
                    return string.Compare(this.City, otherContact.City);
                }
            }
            else
            {
                return this.Name.CompareTo(otherContact.Name);
            }
        }
    }

    public override string ToString()
    {
        return string.Format("Name: {0}; City: {1}; Number: {2}", this.Name, this.City, this.Number);
    }
}

