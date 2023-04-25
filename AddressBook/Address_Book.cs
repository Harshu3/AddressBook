using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class AddressBook
    {
        List<Address> addresses;

        public AddressBook()
        {
            addresses = new List<Address>();
        }

        public bool add(string firstName, string lastName, string address, string city, string state, int zip, int phone, string email)
        {
            Address addr = new Address(firstName, lastName, address, city, state, zip, phone, email);
            Address result = find(firstName);

            if (result == null)
            {
                addresses.Add(addr);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Address find(string name)
        {
            Address addr = addresses.Find((a) => a.firstName == name);
            return addr;
        }
    }
}
