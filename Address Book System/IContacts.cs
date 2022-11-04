using System;
using System.Collections.Generic;
using System.Text;

using System;

namespace Address_Book_System
{
    interface IContacts
    {
        // Interface with addContact,editContact,deleteContact,displayContact methods without body.
        public void addContact(string firstName, string lastName, string email, string phoneNumber, string address, string zip, string city, string state);
        public void Edit(string firstName);
        public void delete(string name);
        public void displayContact();
    }
}