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
        Dictionary<string, string> cities;
        Dictionary<string, string> states;

        public Address_Book(string addressBook_Name)
        {
            addresses = new List<Address>();
            AddressBook_Name = addressBook_Name;
            cities = new Dictionary<string, string>();
            states = new Dictionary<string, string>();
        }

        public Address AddToContact()
        {
            Address address = new Address();
            Console.WriteLine("\nEnter First Name:");
            var fName = Console.ReadLine();
            address.firstName = fName;
            Console.WriteLine("Enter Last Name:");
            var lName = Console.ReadLine();
            address.lastName = lName;
            Console.WriteLine("Enter Address:");
            var adr = Console.ReadLine();
            address.address = adr;
            Console.WriteLine("Enter City:");
            var city = Console.ReadLine();
            address.city = city;
            Console.WriteLine("Enter State:");
            var state = Console.ReadLine();
            address.state = state;
            Console.WriteLine("Enter Zip Code");
            address.zip = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Phone Number:");
            address.phone = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Email:");
            var mail = Console.ReadLine();
            address.email = mail;
            addresses.Add(address);
            cities.Add(city, fName);
            states.Add(state, fName);
            Console.WriteLine("Contact added successfully!\n------------------");
            return address;
        }

        public void Display()
        {
            Console.WriteLine("\nEnter 1 to print all data\nEnter 2 to view persons by state or city\nEnter 3 to get number of persons by state or city\nEnter 4 to print entries in alphabetical order\nEnter 5 to sort entries by city, state and zipcode");
            int input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
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
                    break;
                case 2:
                    Console.WriteLine("Enter 1 to view person by city\nEnter 2 to view persons by state");
                    int option = int.Parse(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            if (cities.Count <= 0)
                            {
                                Console.WriteLine("No contacts available");
                            }
                            else
                            {
                                foreach (var c in cities)
                                {
                                    Console.WriteLine(c);
                                }
                            }
                            break;
                        case 2:
                            if (states.Count <= 0)
                            {
                                Console.WriteLine("No contacts available");
                            }
                            else
                            {
                                foreach (var s in states)
                                {
                                    Console.WriteLine(s);
                                }
                            }
                            break;
                    }
                    break;
                case 3:
                    Console.WriteLine("Enter 1 to get number of persons by city\nEnter 2 to get number of persons by state");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter the city name");
                            var city = Console.ReadLine();
                            int count = 0;
                            foreach (var c in cities)
                            {
                                if (c.Key.Equals(city))
                                {
                                    count++;
                                }
                            }
                            if (count == 0)
                            {
                                Console.WriteLine($"No person of city {city} is present");
                            }
                            else
                            {
                                Console.WriteLine($"{count} person of city is present in contact");
                            }
                            break;
                        case 2:
                            Console.WriteLine("Enter the state name");
                            var state = Console.ReadLine();
                            int count2 = 0;
                            foreach (var s in states)
                            {
                                if (s.Key.Equals(state))
                                {
                                    count2++;
                                }
                            }
                            if (count2 == 0)
                            {
                                Console.WriteLine($"No person of state {state} is present");
                            }
                            else
                            {
                                Console.WriteLine($"{count2} person of state is present in contact");
                                return;
                            }
                            break;
                    }
                    break;
                case 4:
                    if (addresses.Count <= 0)
                    {
                        Console.WriteLine("No contacts available");
                    }
                    else
                    {
                        addresses.Sort((x, y) => x.firstName.CompareTo(y.firstName));
                        foreach (var contact in addresses)
                        {
                            Console.WriteLine("AddressBook Name: " + AddressBook_Name + "\n FirstName: " + contact.firstName + "\n LastName: " + contact.lastName + "\n Address: " + contact.address + "\n City: " + contact.city + "\n State: " + contact.state + "\n Zip: " + contact.zip + "\n Phone: " + contact.phone + "\n Email: " + contact.email + "\n------------------");
                        }
                    }
                    break;
                case 5:
                    if (addresses.Count <= 0)
                    {
                        Console.WriteLine("No contacts available");
                        return;
                    }
                    Console.WriteLine("Enter 1 to sort by city\nEnter 2 to sort by state\nEnter 3 to sort by zipcode");
                    int choose = int.Parse(Console.ReadLine());
                    switch (choose)
                    {
                        case 1:
                            Console.WriteLine("Enter city name");
                            var Citys = Console.ReadLine();
                            foreach (var contact in addresses)
                            {
                                if (Citys == contact.city)
                                {
                                    Console.WriteLine("\nAddressBook Name: " + AddressBook_Name + "\n FirstName: " + contact.firstName + "\n LastName:" + contact.lastName + "\n Address: " + contact.address + "\n City: " + contact.city + "\n State: " + contact.state + "\n Zip: " + contact.zip + "\n Phone: " + contact.phone + "\n Email: " + contact.email + "\n------------------");
                                }
                                else
                                    Console.WriteLine("No contacts having entered city");
                            }
                            break;
                        case 2:
                            Console.WriteLine("Enter state name");
                            var States = Console.ReadLine();
                            foreach (var contact in addresses)
                            {
                                if (States == contact.state)
                                {
                                    Console.WriteLine("\nAddressBook Name: " + AddressBook_Name + "\n FirstName: " + contact.firstName + "\n LastName:" + contact.lastName + "\n Address: " + contact.address + "\n City: " + contact.city + "\n State: " + contact.state + "\n Zip: " + contact.zip + "\n Phone: " + contact.phone + "\n Email: " + contact.email + "\n------------------");
                                }
                                else
                                    Console.WriteLine("No contacts having entered state");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Enter Zipcode name");
                            var Zipcodes = int.Parse(Console.ReadLine());
                            foreach (var contact in addresses)
                            {
                                if (Zipcodes == contact.zip)
                                {
                                    Console.WriteLine("\nAddressBook Name: " + AddressBook_Name + "\n FirstName: " + contact.firstName + "\n LastName:" + contact.lastName + "\n Address: " + contact.address + "\n City: " + contact.city + "\n State: " + contact.state + "\n Zip: " + contact.zip + "\n Phone: " + contact.phone + "\n Email: " + contact.email + "\n------------------");
                                }
                                else
                                    Console.WriteLine("No contacts having entered zipcode");
                            }
                            break;
                    }
                    break;
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
