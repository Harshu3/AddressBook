using AddressBookSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class Program
    {
        AddressBookManager manager1;

        public Program()
        {
            manager1 = new AddressBookManager();
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program!");
            Console.WriteLine("Program for creating multiple AddressBook!");
            string selection = "";
            Program pro = new Program();

            while (!selection.Equals("Q"))
            {
                pro.DisplayMenu();
                Console.WriteLine("\nSelect from above options:");
                selection = Console.ReadLine();
                pro.Action(selection);
            }
            
        }
        void DisplayMenu()
        {
            Console.WriteLine("\nEnter O to open an AddressBook\nEnter C to create an AddressBook\nEnter Q to quit");
        }

        void Action(string selection)
        {
            switch (selection)
            {
                case "O":
                    manager1.Open_AddressBook();
                    break;
                case "C":
                    manager1.Create_AddressBook();
                    break;
            }
        }
    }
}