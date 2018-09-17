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
            //Console.WriteLine(test2.ToString());


            Vendor myMachine = new Vendor();
            myMachine.SetupItem(0, 3.5, "Candy", 2);
            myMachine.SetupItem(1, 4.5, "Communist manifesto", 23);
            myMachine.SetupItem(2, 5, "Mismatch patty cake: the cake for kids", 4);
            myMachine.SetupItem(3, 0.25, "Nintendo Switch", 1);
            myMachine.SetupItem(4, 1, "Dollar bill", 5);
            myMachine.SetupItem(5, 300, "Souls of the Damnned", 10);

           // myMachine.DisplayInventory();

            myMachine.Shop();
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
            int userIn = -1;
            int currentSelection = -1;
            bool getNum = false;
            //double currentTotal = 0;
            //Instead of double use Item array
            int[] totalQty = new int[5];

            foreach (Item item in inventory)
            {
                ++i;
                Console.WriteLine(i + "] " + item.Name + " : " + item.Price);
            }
            Console.WriteLine("Please use the number keys to select your item. 1-5 for items, 6 to exit, 7 to check inventory.");
            while(userIn != 5)
            {
                //userIn = int.Parse(Console.ReadLine());
                getNum = Int32.TryParse(Console.ReadLine(), out userIn);
                userIn = userIn -1;
                if(userIn >= 0 && userIn <= 4)
                {
                    Console.WriteLine(inventory[userIn].Name + " costs: " + inventory[userIn].Price + ". There are: " + inventory[userIn].Quantity + " within this machine. Would you like to buy some? 1 for yes, preses any other number to see the menu.");
                    currentSelection = userIn;
                    //userIn = int.Parse(Console.ReadLine());
                    getNum = Int32.TryParse(Console.ReadLine(), out userIn);
                    if (userIn == 1)
                    {
                        Console.WriteLine("How many of this item do you want?");
                        //userIn = int.Parse(Console.ReadLine());
                        getNum = Int32.TryParse(Console.ReadLine(), out userIn);
                        if (userIn > 0 && userIn <= inventory[currentSelection].Quantity)
                        {
                            Console.WriteLine("Okay, adding: " + userIn + " to your total.");                  
                            totalQty[currentSelection] = userIn;
                        }
                        else
                        {
                            Console.WriteLine("Not a correct number");
                        }
                    }
                 
                    Console.WriteLine("Returning to main menu...");
                    i = 0;
                    foreach (Item item in inventory)
                    {
                        ++i;
                        Console.WriteLine(i + "] " + item.Name + " : " + item.Price);
                    }
                    Console.WriteLine("Please use the number keys to select your item. 1-5 for items, 6 to exit.");
                 
                }
                else if(userIn == 5)
                {
                    Console.WriteLine("Goodbye!");
                }
                else
                {
                    Console.WriteLine("Not a valid item number silly!");
                }
            
            }
        }

    }
}
