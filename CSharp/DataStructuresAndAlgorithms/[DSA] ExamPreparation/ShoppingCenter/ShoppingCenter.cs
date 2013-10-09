//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Linq;
//using Wintellect.PowerCollections;

//public class ShoppingCenter
//{
//    private readonly MultiDictionary<string, Product> productsByName;
//    private readonly MultiDictionary<string, Product> productsByProducer;
//    private readonly MultiDictionary<string, Product> productsByNameAndProducer;
//    private readonly OrderedMultiDictionary<double, Product> productsByPriceRange;
//    public StringBuilder Buffer { get; set; }

//    public ShoppingCenter()
//    {
//        this.productsByName = new MultiDictionary<string, Product>(true);
//        this.productsByProducer = new MultiDictionary<string, Product>(true);
//        this.productsByNameAndProducer = new MultiDictionary<string, Product>(true);
//        this.productsByPriceRange = new OrderedMultiDictionary<double, Product>(true);
//        this.Buffer = new StringBuilder();
//    }

//    public void AddProduct(string name, double price, string producer)
//    {
//        Product prod = new Product(name, price, producer);
//        this.productsByName.Add(name, prod);
//        this.productsByProducer.Add(producer, prod);
//        this.productsByNameAndProducer.Add(name + producer, prod);
//        this.productsByPriceRange.Add(price, prod);

//        this.Buffer.AppendLine("Product added");
//    }

//    public void DeleteProducts(string name, string producer)
//    {
//        string nameAndProducer = name + producer;
//        if (this.productsByNameAndProducer.ContainsKey(nameAndProducer))
//        {
//            List<Product> productsForDeletion = productsByNameAndProducer[nameAndProducer].ToList();
//            this.Buffer.AppendLine(productsForDeletion.Count + " products deleted");

//            foreach (var product in productsForDeletion)
//            {
//                this.productsByName.Remove(product.Name, product);
//                this.productsByProducer.Remove(product.Producer, product);
//                this.productsByNameAndProducer.Remove(product.Name + product.Producer, product);
//                this.productsByPriceRange.Remove(product.Price, product);
//            }
//        }
//        else
//        {
//            this.Buffer.AppendLine("No products found");
//        }
//    }

//    public void DeleteProducts(string producer)
//    {
//        if (this.productsByProducer.ContainsKey(producer))
//        {
//            List<Product> productsForDeletion = productsByProducer[producer].ToList();
//            this.Buffer.AppendLine(productsForDeletion.Count + " products deleted");

//            foreach (var product in productsForDeletion)
//            {
//                this.productsByName.Remove(product.Name, product);
//                this.productsByProducer.Remove(product.Producer, product);
//                this.productsByNameAndProducer.Remove(product.Name + product.Producer, product);
//                this.productsByPriceRange.Remove(product.Price, product);
//            }
//        }
//        else
//        {
//            this.Buffer.AppendLine("No products found");
//        }
//    }

//    public void FindProductsByName(string name)
//    {
//        if (productsByName.ContainsKey(name))
//        {
//            List<Product> foundProducts = productsByName[name].ToList();
//            this.AppendProducts(foundProducts);
//        }
//        else
//        {
//            this.Buffer.AppendLine("No products found");
//        }
//    }

//    public void FindProductsByPriceRange(double from, double to)
//    {
//        List<Product> foundProducts = productsByPriceRange.Range(from, true, to, true).Values.ToList();
//        if (foundProducts.Count == 0)
//        {
//            this.Buffer.AppendLine("No products found");
//        }
//        else
//        {
//            this.AppendProducts(foundProducts);
//        }
//    }

//    public void FindProductsByProducer(string producer)
//    {
//        if (productsByProducer.ContainsKey(producer))
//        {
//            List<Product> foundProducts = productsByProducer[producer].ToList();
//            this.AppendProducts(foundProducts);
//        }
//        else
//        {
//            this.Buffer.AppendLine("No products found");
//        }
//    }

//    private void AppendProducts(List<Product> foundProducts)
//    {
//        foundProducts.Sort();
//        foreach (var product in foundProducts)
//        {
//            this.Buffer.AppendLine(product.ToString());
//        }
//    }
//}
