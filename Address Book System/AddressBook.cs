using System;
using System.Collections.Generic;
using System.Linq;

namespace Address_Book_System
{
    class AddressBook : IContacts
    {
        public List<Contact> contactList;

        public AddressBook()
        {
            this.contactList = new List<Contact>();
        }

        public void addContact(string firstName, string lastName, string email, string phoneNumber, string address, string zip, string city, string state)
        {
            bool duplicate = equals(firstName);
            if (!duplicate)
            {
                Contact contact = new Contact(firstName, lastName, email, phoneNumber, address, zip, city, state);
                contactList.Add(contact);
            }
            else
            {
                Console.WriteLine("Cannot add duplicate contacts first name");
            }
        }

        private bool equals(string name)
        {
            if (this.contactList.Any(e => e.firstName == name))
                return true;
            else
                return false;
        }

        public void Edit(string firstName)
        {
            Contact editContact = null;

            foreach (Contact contact in contactList)
            {
                if (firstName.Equals(contact.firstName))
                {
                    editContact = contact;
                }
            }
            Console.WriteLine("Plz provide new firstName");
            editContact.firstName = Console.ReadLine();
            Console.WriteLine("Plz provide new lastName");
            editContact.lastName = Console.ReadLine();
            Console.WriteLine("Plz provide new email");
            editContact.email = Console.ReadLine();
            Console.WriteLine("Plz provide new phoneNumber");
            editContact.phoneNumber = Console.ReadLine();
            Console.WriteLine("Plz provide new address");
            editContact.address = Console.ReadLine();
            Console.WriteLine("Plz provide new zip");
            editContact.zip = Console.ReadLine();
            Console.WriteLine("Plz provide new city");
            editContact.city = Console.ReadLine();
            Console.WriteLine("Plz provide new state");
            editContact.state = Console.ReadLine();

            contactList.Add(editContact);
            Console.WriteLine($"Contact of {firstName} has been edited");
        }

        public void delete(string name)
        {
            Contact RemoveContact = null;
            foreach (Contact contact in contactList)
            {
                if (contact.firstName.Contains(name))
                {
                    RemoveContact = contact;
                }
            }
            contactList.Remove(RemoveContact);
            Console.WriteLine($"Contact of {name} has been deleted");
        }

        public void displayContact()
        {
            foreach (Contact contact in contactList)
            {
                Console.WriteLine("\nFirst name = " + contact.firstName);
                Console.WriteLine("Last name = " + contact.lastName);
                Console.WriteLine("email = " + contact.email);
                Console.WriteLine("phoneNumber = " + contact.phoneNumber);
                Console.WriteLine("Address = " + contact.address);
                Console.WriteLine("zip = " + contact.zip);
                Console.WriteLine("city = " + contact.city);
                Console.WriteLine("state = " + contact.state);
            }
        }

        public List<string> findPersons(string place)
        {
            List<string> personFounded = new List<string>();
            foreach (Contact contacts in contactList.FindAll(e => (e.city.Equals(place))).ToList())
            {
                string name = contacts.firstName + " " + contacts.lastName;
                personFounded.Add(name);
            }
            if (personFounded.Count == 0)
            {
                foreach (Contact contacts in contactList.FindAll(e => (e.state.Equals(place))).ToList())
                {
                    string name = contacts.firstName + " " + contacts.lastName;
                    personFounded.Add(name);
                }
            }
            return personFounded;
        }
    }
}