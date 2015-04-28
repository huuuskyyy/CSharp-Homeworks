using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Range_search
{
    public class Product:IComparable<Product>
    {
        private string name;
        private int price;

        public Product(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
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

        public int CompareTo(Product productToCompare)
        {
            return this.price.CompareTo(productToCompare.Price);
        }
    }
    class Program
    {
        static void Main()
        {
            OrderedBag<Product> bag = new OrderedBag<Product>();
            int productsNumber = 500000;
            Random rand = new Random();

            for (int i = 0; i < productsNumber; i++)
            {
                bag.Add(new Product("item"+i, rand.Next(1, 100000)));
            }

            Product min = new Product("itemCompare",17);
            Product max = new Product("itemCompare",100);

            List<Product> itemsInRange = bag.Range(min, true, max, true).ToList();

            if(itemsInRange.Count > 20)
            {
                itemsInRange = itemsInRange.GetRange(0, 20);
            }

            foreach (var item in itemsInRange)
            {
                Console.WriteLine(" Name: "+item.Name+" Price: "+item.Price);
            }
        }
    }
}
