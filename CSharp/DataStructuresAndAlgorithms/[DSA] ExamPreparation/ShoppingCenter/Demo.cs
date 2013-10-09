using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Wintellect.PowerCollections;

public class Demo
{
    public static void Main()
    {
        ShoppingCenter mallSofia = new ShoppingCenter();
        int numberOfCommands = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfCommands; i++)
        {
            string line = Console.ReadLine();
            int indexOfFirstWhiteSpace = line.IndexOf(' ');
            string commandType = line.Substring(0, indexOfFirstWhiteSpace);
            string[] parameters = line.Substring(indexOfFirstWhiteSpace + 1).Split(';');

            if (commandType == "AddProduct")
            {
                mallSofia.AddProduct(parameters[0], double.Parse(parameters[1]), parameters[2]);
            }

            if (commandType == "DeleteProducts")
            {
                if (parameters.Length == 2)
                {
                    mallSofia.DeleteProducts(parameters[0], parameters[1]);
                }
                else
                {
                    mallSofia.DeleteProducts(parameters[0]);
                }
            }

            if (commandType == "FindProductsByName")
            {
                mallSofia.FindProductsByName(parameters[0]);
            }

            if (commandType == "FindProductsByPriceRange")
            {
                mallSofia.FindProductsByPriceRange(double.Parse(parameters[0]), double.Parse(parameters[1]));
            }

            if (commandType == "FindProductsByProducer")
            {
                mallSofia.FindProductsByProducer(parameters[0]);
            }
        }

        Console.WriteLine(mallSofia.Buffer.ToString());
    }
}

public class Product : IComparable<Product>
{
    public Product(string name, double price, string producer)
    {
        this.Name = name;
        this.Price = price;
        this.Producer = producer;
    }

    public string Name { get; set; }
    public double Price { get; set; }
    public string Producer { get; set; }

    public int CompareTo(Product other)
    {
        if (this.Name == other.Name)
        {
            if (this.Producer == other.Producer)
            {
                if (this.Price == other.Price)
                {
                    return 0;
                }
                else
                {
                    return this.Price.CompareTo(other.Price);
                }
            }
            else
            {
                return string.Compare(this.Producer, other.Producer);
            }
        }
        else
        {
            return this.Name.CompareTo(other.Name);
        }
    }

    public override int GetHashCode()
    {
        int prime = 17;
        int result = 1;
        unchecked
        {
            result = result * prime + this.Name.GetHashCode();
            result = result * prime + this.Price.GetHashCode();
            result = result * prime + this.Producer.GetHashCode();
        }

        return result;
    }

    public override string ToString()
    {
        return "{" + this.Name + ";" + this.Producer + ";" +
            string.Format("{0:0.00}", this.Price) + "}";
    }
}

public class ShoppingCenter
{
    private readonly MultiDictionary<string, Product> productsByName;
    private readonly MultiDictionary<string, Product> productsByProducer;
    private readonly MultiDictionary<string, Product> productsByNameAndProducer;
    private readonly OrderedMultiDictionary<double, Product> productsByPriceRange;
    public StringBuilder Buffer { get; set; }

    public ShoppingCenter()
    {
        this.productsByName = new MultiDictionary<string, Product>(true);
        this.productsByProducer = new MultiDictionary<string, Product>(true);
        this.productsByNameAndProducer = new MultiDictionary<string, Product>(true);
        this.productsByPriceRange = new OrderedMultiDictionary<double, Product>(true);
        this.Buffer = new StringBuilder();
    }

    public void AddProduct(string name, double price, string producer)
    {
        Product prod = new Product(name, price, producer);
        this.productsByName.Add(name, prod);
        this.productsByProducer.Add(producer, prod);
        this.productsByNameAndProducer.Add(name + producer, prod);
        this.productsByPriceRange.Add(price, prod);

        this.Buffer.AppendLine("Product added");
    }

    public void DeleteProducts(string name, string producer)
    {
        string nameAndProducer = name + producer;
        if (this.productsByNameAndProducer.ContainsKey(nameAndProducer))
        {
            List<Product> productsForDeletion = productsByNameAndProducer[nameAndProducer].ToList();
            this.Buffer.AppendLine(productsForDeletion.Count + " products deleted");
            this.productsByNameAndProducer.Remove(nameAndProducer);

            foreach (var product in productsForDeletion)
            {
                this.productsByName.Remove(product.Name, product);
                this.productsByProducer.Remove(product.Producer, product);
                this.productsByPriceRange.Remove(product.Price, product);
            }
        }
        else
        {
            this.Buffer.AppendLine("No products found");
        }
    }

    public void DeleteProducts(string producer)
    {
        if (this.productsByProducer.ContainsKey(producer))
        {
            List<Product> productsForDeletion = productsByProducer[producer].ToList();
            this.Buffer.AppendLine(productsForDeletion.Count + " products deleted");
            this.productsByProducer.Remove(producer);

            foreach (var product in productsForDeletion)
            {
                this.productsByName.Remove(product.Name, product);
                this.productsByNameAndProducer.Remove(product.Name + product.Producer, product);
                this.productsByPriceRange.Remove(product.Price, product);
            }
        }
        else
        {
            this.Buffer.AppendLine("No products found");
        }
    }

    public void FindProductsByName(string name)
    {
        if (productsByName.ContainsKey(name))
        {
            List<Product> foundProducts = productsByName[name].ToList();
            this.AppendProducts(foundProducts);
        }
        else
        {
            this.Buffer.AppendLine("No products found");
        }
    }

    public void FindProductsByPriceRange(double from, double to)
    {
        List<Product> foundProducts = productsByPriceRange.Range(from, true, to, true).Values.ToList();
        if (foundProducts.Count == 0)
        {
            this.Buffer.AppendLine("No products found");
        }
        else
        {
            this.AppendProducts(foundProducts);
        }
    }

    public void FindProductsByProducer(string producer)
    {
        if (productsByProducer.ContainsKey(producer))
        {
            List<Product> foundProducts = productsByProducer[producer].ToList();
            this.AppendProducts(foundProducts);
        }
        else
        {
            this.Buffer.AppendLine("No products found");
        }
    }

    private void AppendProducts(List<Product> foundProducts)
    {
        foundProducts.Sort();
        foreach (var product in foundProducts)
        {
            this.Buffer.AppendLine(product.ToString());
        }
    }
}


