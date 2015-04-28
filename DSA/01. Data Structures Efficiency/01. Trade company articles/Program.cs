using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Trade_company_articles
{
    class Program
    {
        public class Article:IComparable<Article>
        {
            private string barcode;
            private string vendor;
            private string title;
            private int price;

            public Article(string barcode, string vendor, string title, int price)
            {
                this.barcode = barcode;
                this.vendor = vendor;
                this.title = title;
                this.price = price;
            }

            public string Barcode
            {
                get
                {
                    return this.barcode;
                }
                set
                {
                    this.barcode = value;
                }
            }

            public string Vendor
            {
                get
                {
                    return this.vendor;
                }
                set
                {
                    this.vendor = value;
                }
            }

            public string Title
            {
                get
                {
                    return this.title;
                }
                set
                {
                    this.title = value;
                }
            }

            public int Price
            {
                get
                {
                    return this.price;
                }
                set
                {
                    this.price = value;
                }
            }

            public int CompareTo(Article articleToCompare)
            {
                return this.price.CompareTo(articleToCompare.price);
            }
        }
        static void Main()
        {
            Random rand = new Random();
            OrderedMultiDictionary<int, Article> articles = new OrderedMultiDictionary<int, Article>(true);

            for(int i = 0; i<100000;i++)
            {
                Article article = new Article("barcode" + i, "vendor" + i, "title" + i, rand.Next(1, 10000));
                articles.Add(article.Price, article);
            }

            List<ICollection<Article>> articlesInRange = articles.Range(70, true, 90, true).Select(x => x.Value).ToList();

            foreach (var articleCollection in articlesInRange)
            {
                foreach (var article in articleCollection)
                {
                    Console.WriteLine(article.Title + " Price " + article.Price);
                }
            }
        }
    }
}
