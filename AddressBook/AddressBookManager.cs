using AddressBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class AddressBookManager
    {
        List<Address_Book> addresses;

        public AddressBookManager()
        {
            addresses = new List<Address_Book>();
        }

        public void Open_AddressBook()
        {
            Console.WriteLine("Enter AddressBook Name:");
            string book_name = Console.ReadLine();
            Address_Book address_Book = null;
            
            foreach (var res in  addresses)
            {
                if (res.AddressBook_Name == book_name)
                {
                    address_Book = res;
                    AddressBook_operation(address_Book);
                    return;
                }
            }
            Console.WriteLine("There is no such AddressBook with enterrd name\n----------------------");
        }

        public void Create_AddressBook()
        {
            Console.WriteLine("Enter AddressBook Name:");
            string name = Console.ReadLine();
            addresses.Add(new Address_Book(name));
            Console.WriteLine("AddressBook created successfully\n----------------------");
            return;
        }

        public void AddressBook_operation(Address_Book addressBook)
        {
            bool flag = true;

            while (flag)
            {
                Console.WriteLine("\nEnter A to Add new contact\nEnter E to edit contact\nEnter D to delete contact\nEnter P to print the contacts\nEnter S to search contacts");
                char ch = Console.ReadLine().ToUpper()[0];

                switch (ch)
                {
                    case 'A':
                        if (addressBook.addresses.Count == 0)
                        {
                            addressBook.AddToContact();
                        }
                        else
                        {
                            foreach (Address c in addressBook.addresses)
                            {
                                Console.WriteLine("Enter Name of the person");
                                var name = Console.ReadLine();
                                while (c.firstName.Equals(name))
                                {
                                    Console.WriteLine($"Entered {name} is already present");
                                    Console.WriteLine($"Entered different name to add contact");
                                    break;
                                }
                            }
                            addressBook.AddToContact();
                        }
                        break;
                    case 'E':
                        addressBook.EditContact();
                        break;
                    case 'D':
                        addressBook.DeleteContact();
                        break;
                    case 'P':
                        addressBook.Display();
                        break;
                    case 'S':
                        addressBook.Search();
                        break;
                    default:
                        break;
                }
                Console.WriteLine("\nEnter 'BACK' to go back to AddressBook Management\nEnter 'NO' to stay in current AddressBook:");
                string input = Console.ReadLine().ToUpper();

                if (input.Equals("BACK"))
                {
                    flag = false;
                    Console.Clear();
                }
                Thread.Sleep(1000);
            }
        }
    }
}
