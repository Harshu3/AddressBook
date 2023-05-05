using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AddressBook
{
    class AddressPrompt
    {
        AddressBook book;

        public AddressPrompt()
        {
            book = new AddressBook();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program!");
            string selection = "";
            AddressPrompt prompt = new AddressPrompt();

            while (!selection.ToUpper().Equals("Q"))
            {
                prompt.displayMenu();
                Console.WriteLine("\nSelect from above options:");
                selection = Console.ReadLine();
                prompt.performAction(selection);
            }
        }
        void displayMenu()
        {
            Console.WriteLine("\n----ADDRESS BOOK----");
            Console.WriteLine("=========");
            Console.WriteLine("A - Add a Contact Details");
            Console.WriteLine("L - List All Contact Details");
            Console.WriteLine("E - Edit Contact Details");
            Console.WriteLine("D - Delete Contact Details");
            Console.WriteLine("Q - Quit");
        }
        void performAction(string selection)
        {
            string firstName = "";
            string lastName = "";
            string address = "";
            string city = "";
            string state = "";
            int zip;
            int phone;
            string email = "";

            switch (selection.ToUpper())
            {
                case "A":
                    Console.WriteLine("How many contacts you want to add?");
                    int num = Convert.ToInt32(Console.ReadLine());
                    for (int i = 1; i <= num; i++)
                    {
                        Console.WriteLine("To add a Contact");
                        Console.WriteLine("Enter First Name:");
                        firstName = Console.ReadLine();
                        Console.WriteLine("Enter Last Name:");
                        lastName = Console.ReadLine();
                        Console.WriteLine("Enter Address:");
                        address = Console.ReadLine();
                        Console.WriteLine("Enter City:");
                        city = Console.ReadLine();
                        Console.WriteLine("Enter State:");
                        state = Console.ReadLine();
                        Console.WriteLine("Enter Zip Code");
                        zip = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Phone Number:");
                        phone = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Email:");
                        email = Console.ReadLine();

                        if (book.add(firstName, lastName, address, city, state, zip, phone, email))
                        {
                            Console.WriteLine("Contact Successfully Added!");
                        }
                        else
                        {
                            Console.WriteLine("A address is already on file for {0}", firstName);
                        }
                    }
                    break;
                case "L":
                    if (book.isEmpty())
                    {
                        Console.WriteLine("There are no entries.");
                    }
                    else
                    {
                        Console.WriteLine("-------------");
                        Console.WriteLine("LIST OF CONTACT DETAILS:");
                        book.list((a) => Console.WriteLine("First Name: {0}\n Last Name: {1}\n Address: {2}\n City: {3}\n State: {4}\n Zip Code: {5}\n Phone Number: {6}\n Email: {7} \n-------------", a.firstName, a.lastName, a.address, a.city, a.state, a.zip, a.phone, a.email));
                    }
                    break;
                case "E":
                    Console.WriteLine("Enter contact name you want to Edit: ");
                    firstName = Console.ReadLine();
                    Address addr = book.find(firstName);
                    Console.WriteLine("Please choose what details you want to edit from below:");
                    Console.WriteLine("1.Address\n2.Phone Number");
                    int option = Convert.ToInt32(Console.ReadLine());
                    if (addr != null)
                    {
                        switch (option)
                        {
                            case 1:
                                Console.WriteLine("Enter new Address:");
                                addr.address = Console.ReadLine();
                                Console.WriteLine("Address updated for {0}", firstName);
                                break;
                            case 2:
                                Console.WriteLine("Enter new Phone Number:");
                                addr.phone = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Phone Number Updated for {0}", firstName);
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Details for {0} count not be found.", firstName);
                    }
                    break;
                case "D":
                    Console.WriteLine("-------------");
                    Console.WriteLine("Enter contact name to Delete: ");
                    firstName = Console.ReadLine();
                    if (book.remove(firstName))
                    {
                        Console.WriteLine("Contact successfully deleted");
                    }
                    else
                    {
                        Console.WriteLine("Details for {0} could not be found.", firstName);
                    }
                    break;
            }
        }
    }
}