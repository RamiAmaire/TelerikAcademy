namespace TradeCompanyStuff
{
    using System;
    using Wintellect.PowerCollections;

    public class Demo
    {
        private static void PrintAllArticlesFromGivenRange(OrderedMultiDictionary<int, Article> articles, int from, int to)
        {
            foreach (var article in articles.Range(from, true, to, true))
            {
                Console.WriteLine(article.Value.ToString());
            }
        }

        public static void Main()
        {
            OrderedMultiDictionary<int, Article> articles = new OrderedMultiDictionary<int, Article>(true);
            Random rnd = new Random();
            for (int i = 0; i < 50000; i++)
            {
                int num = rnd.Next(0, 50000);
                articles.Add(num, new Article("Uga Buga", num, "JungleSoft", num + num.GetHashCode()));
            }

            PrintAllArticlesFromGivenRange(articles, 100, 200);
        }
    }
}
