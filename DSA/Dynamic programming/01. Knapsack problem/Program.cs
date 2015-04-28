using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    static void Main()
    {
        Item[] items = {
                           new Item(2,3,"beer"), 
                           new Item(12,8,"vodka"), 
                           new Item(5,4,"cheese"), 
                           new Item(4,1,"nuts"), 
                           new Item(3,2,"ham"), 
                           new Item(13,8,"whiskey") 
                       };

        int allowedWeight = 10;
        int totalItems = items.Length;

        

        int[,] matrix = new int[totalItems + 1, allowedWeight + 1];

        for (int row = 1; row <= totalItems; row++)
        {
            Item currentItem = items[row - 1];

            for (int col = 1; col <= allowedWeight; col++)
            {
                int currentWeight = col;

                if (currentItem.Weight > currentWeight)
                {
                    matrix[row, col] = matrix[row - 1, col];
                }
                else
                {
                    if (currentWeight - currentItem.Weight > 0)
                    {
                        if (currentItem.Price +
                        matrix[row - 1, col - currentItem.Weight] >
                        matrix[row - 1, col])
                        {
                            matrix[row, col] = currentItem.Price +
                            matrix[row - 1, col - currentItem.Weight];
                        }
                        else
                        {
                            matrix[row, col] = matrix[row - 1, col];
                        }
                    }
                    else
                    {
                        if (currentItem.Price > matrix[row - 1, col])
                        {
                            matrix[row, col] = currentItem.Price;
                        }
                        else
                        {
                            matrix[row, col] = matrix[row - 1, col];
                        }
                    }
                }

            }
        }

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }

            Console.WriteLine();
        }

        int currentX = totalItems;
        int currentY = allowedWeight;

        while (true)
        {
            if (!(currentX > 0) || !(currentY > 0))
            {
                Console.WriteLine("Break " + currentX + " " + currentY);
                break;
            }

            int currentCell = matrix[currentX, currentY];
            int cellToCompare = matrix[currentX - 1, currentY];



            if (currentCell == cellToCompare)
            {
                currentX--;
                Console.WriteLine(currentX + " " + currentY);
                continue;
            }

            Item currentItem = items[currentX - 1];

            Console.WriteLine(currentItem.Name + " => Price:" + currentItem.Price + "; Weight: " + currentItem.Weight + " Break" + currentX + " " + currentY);
            currentX--;
            currentY = currentY - currentItem.Weight;
        }

    }

    public class Item
    {
        private int price;
        private int weight;
        private string name;

        public Item(int price, int weight, string name)
        {
            this.price = price;
            this.weight = weight;
            this.name = name;
        }

        public int Price
        {
            get
            {
                return this.price;
            }
        }

        public int Weight
        {
            get
            {
                return this.weight;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }
    }
}

