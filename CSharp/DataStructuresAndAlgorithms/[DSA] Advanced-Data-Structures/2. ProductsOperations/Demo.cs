namespace ProductsOperations
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Demo
    {
        public static OrderedBag<Product> AddProducts()
        {
            OrderedBag<Product> products = new OrderedBag<Product>();
            for (int i = 0; i < 500000; i++)
            {
                products.Add(new Product("Product" + i, i));
            }

            return products;
        }

        public static void PrintFirstTwentyProducts(OrderedBag<Product> products, int from, int to)
        {
            var firstTwentyProducts = products.Range(new Product("a", from), true, new Product("z", to), true).Take(20);
            foreach (var prod in firstTwentyProducts)
            {
                Console.WriteLine(prod.ToString());
            }
        }

        public static void FindFirstTenThousandProducts(OrderedBag<Product> products, int from, int to)
        {
            var firstTenThousandProducts = products.Range(new Product("a", from), true, new Product("z", to), true).Take(100000);
        }

        public static void Main()
        {
            OrderedBag<Product> products = AddProducts();
            PrintFirstTwentyProducts(products, 100, 200);
            FindFirstTenThousandProducts(products, 0, 20000);
        }
    }
}
