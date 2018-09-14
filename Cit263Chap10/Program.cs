using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cit263Chap10
{
    class Program
    {
        static void Main(string[] args)
        {
            //string test = "Hello";
            SimpleTime test1 = new SimpleTime(12, 3, 12);
            SimpleTime test2 = new SimpleTime(11, 5, 2);
            Console.WriteLine(test2.ToString());


            Vendor myMachine = new Vendor();
            myMachine.SetupItem(0, 3.5, "Candy", 2);
            myMachine.SetupItem(1, 4.5, "Communist manifesto", 23);
            myMachine.SetupItem(2, 5, "Mismatch patty cake: the cake for kids", 4);
            myMachine.SetupItem(3, 0.25, "Nintendo Switch", 1);
            myMachine.SetupItem(4, 1, "Dollar bill", 5);
            myMachine.SetupItem(5, 300, "Souls of the Damnned", 10);

            myMachine.DisplayInventory();
        }


       
       
    }

    public class SimpleTime
    {

        private int hour;
        private int minute;
        private int second;
        
        public SimpleTime(int hour =0, int minute = 0, int second = 0)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }

        public string ToString()
        {
            string result = this.hour + " " + this.minute + " " + this.second;
            return result;
        }
    }

    public class Employee
    {
        string name;
        string email;
        SimpleTime hiredate;

    }

    public class Item
    {
        private double price;
        private string name;
        private int quantity;

        public double Price
        {
            get { return price; }
            set { price = value; }//We want to allow the item to be changed after creation.
        }
        public string Name
        {
            get { return name; }
            set { name = value; }//We want to allow the item to be changed after creation.
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }//We want to allow the item to be changed after creation.
        }

    }

    public class Vendor
    {

        private Item[] inventory;
        public Vendor()
        {
                inventory = new Item[5];
                //At the moment in addition to inializing the array in the constructor, we need to initalize the items as well.
                //There should be a faster, less hard coded way to do this
                inventory[0] = new Item();
                inventory[1] = new Item();
                inventory[2] = new Item();
                inventory[3] = new Item();
                inventory[4] = new Item();
        }        

        public void DisplayInventory()
        {
            int i=0;
            foreach(Item item in inventory)
            {
                ++i;
                Console.WriteLine(i + "] " + item.Name + " : " + item.Price);
            }
        }

        public void SetupItem(int position, double inPrice, string inName, int inQuantity)
        {
            if (inventory.Length > position)
            {
                inventory[position].Name = inName;
                inventory[position].Price = inPrice;
                inventory[position].Quantity = inQuantity;
                Console.WriteLine("Item: " + inventory[position].Name + " Added to machine");
            }
            else
            {
                Console.WriteLine("Too large of an index");
            }
        }

        public void Shop()
        {
            int i = 0;
            foreach (Item item in inventory)
            {
                ++i;
                Console.WriteLine(i + "] " + item.Name + " : " + item.Price);
            }
        }
    }
}
