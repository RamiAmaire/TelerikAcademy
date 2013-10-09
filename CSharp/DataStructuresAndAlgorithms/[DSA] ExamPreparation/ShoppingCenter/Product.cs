//using System;

//public class Product : IComparable<Product>
//{
//    public Product(string name, double price, string producer)
//    {
//        this.Name = name;
//        this.Price = price;
//        this.Producer = producer;
//    }

//    public string Name { get; set; }
//    public double Price { get; set; }
//    public string Producer { get; set; }

//    public int CompareTo(Product other)
//    {
//        if (this.Name == other.Name)
//        {
//            if (this.Producer == other.Producer)
//            {
//                if (this.Price == other.Price)
//                {
//                    return 0;
//                }
//                else
//                {
//                    return this.Price.CompareTo(other.Price);
//                }
//            }
//            else
//            {
//                return string.Compare(this.Producer, other.Producer);
//            }
//        }
//        else
//        {
//            return this.Name.CompareTo(other.Name);
//        }
//    }

//    public override int GetHashCode()
//    {
//        int prime = 17;
//        int result = 1;
//        unchecked
//        {
//            result = result * prime + this.Name.GetHashCode();
//            result = result * prime + this.Price.GetHashCode();
//            result = result * prime + this.Producer.GetHashCode();
//        }

//        return result;
//    }

//    public override string ToString()
//    {
//        return "{" + this.Name + ";" + this.Producer + ";" +
//            string.Format("{0:0.00}", this.Price) + "}";
//    }
//}
