using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class Address_Book
    {
        public List<Address> addresses;
        public string AddressBook_Name;

        public Address_Book(string addressBook_Name)
        {
            addresses = new List<Address>();
            AddressBook_Name = addressBook_Name;
        }

        public Address AddToContact()
        {
            Address address = new Address();
            Console.WriteLine("Enter First Name:");
            address.firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name:");
            address.lastName = Console.ReadLine();
            Console.WriteLine("Enter Address:");
            address.address = Console.ReadLine();
            Console.WriteLine("Enter City:");
            address.city = Console.ReadLine();
            Console.WriteLine("Enter State:");
            address.state = Console.ReadLine();
            Console.WriteLine("Enter Zip Code");
            address.zip = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Phone Number:");
            address.phone = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Email:");
            address.email = Console.ReadLine();
            addresses.Add(address);
            Console.WriteLine("Contact added successfully!\n------------------");
            return address;
        }

        public void Display()
        {
            if (addresses.Count <= 0)
            {
                Console.WriteLine("No contacts available");
            }
            else
            {
                foreach (var contact in addresses)
                {
                    Console.WriteLine("AddressBook Name: " + AddressBook_Name + "\n FirstName: " + contact.firstName + "\n LastName: " + contact.lastName + "\n Address: " + contact.address + "\n City: " + contact.city + "\n State: " + contact.state + "\n Zip: " + contact.zip + "\n Phone: " + contact.phone + "\n Email: " + contact.email + "\n------------------");
                }
            }
        }

        public void EditContact()
        {
            Console.WriteLine("\nEnter First Name of contact to edit that contact");
            string name = Console.ReadLine();
            Address address = null;
            
            foreach (var res in addresses)
            {
                if (res.firstName == name)
                {
                    address = res;
                }
            }
            if (address == null)
            {
                Console.WriteLine("No contact present with given name");
            }
            address = AddToContact();
            for (int i = 0; i < addresses.Count; i++)
            {
                if (addresses[i].firstName == name)
                {
                    addresses[i] = address;
                    break;
                }
            }
            Console.WriteLine("Contact Edited successfully");
        }

        public void Search()
        {
            Console.WriteLine("Enter 1 to search by City\nEnter 2 to search by State");
            int input = int.Parse(Console.ReadLine());
            string res = "";

            switch (input)
            {
                case 1:
                    Console.WriteLine("Enter City Name");
                    var city = Console.ReadLine();
                    res = city;
                    break;
                case 2:
                    Console.WriteLine("Enter State Name");
                    var state = Console.ReadLine();
                    res = state;
                    break;
            }
            foreach (var contact in addresses)
            {
                if (contact.city.Equals(res) || contact.state.Equals(res))
                {
                    Console.WriteLine("\nAddressBook Name: " + AddressBook_Name + "\nFirst Name: " + contact.firstName + "\nLast Name: " + contact.lastName + "\nAddress: " + contact.address + "\nCity: " + contact.city + "\nState: " + contact.state + "\nZipCode: " + contact.zip + "\nPhone: " + contact.phone + "\nEmail: " + contact.email);
                    break;
                }
                else
                    Console.WriteLine("Person search by City or State is not present in Contact");
            }
        }

        public void DeleteContact()
        {
            Console.WriteLine("\nEnter First Name of contact to Delete");
            string dname = Console.ReadLine();
            bool flag = true;

            for (int i = 0; i < addresses.Count; i++)
            {
                if (addresses[i].firstName == dname)
                {
                    addresses.RemoveAt(i);
                    Console.WriteLine("Contact deleted successfully");
                    flag = false;
                }
            }
            if (flag)
            {
                Console.WriteLine($"No contact present of {dname} name");
            }
        }
    }
}
