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

        // Adds the contact but contact is not be duplicated.
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

        // Equalses the specified first name for duplicate name.
        private bool equals(string name)
        {
            if (this.contactList.Any(e => e.firstName == name))
                return true;
            else
                return false;
        }

        // Edits the contact with the help of first name of person.
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

        // Deletes the contact of person with the help of first name.
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

        // Displays the contact of persons.
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

        // Find  the persons by place ie state or city.
        public List<string> FindPersons(string place)
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

        // Sort methode for sort entites in adress book.      
        public void SortByFirstName()
        {
            List<string> sortList = new List<string>();
            foreach (Contact contacts in contactList)
            {
                string sort = contacts.ToString();
                sortList.Add(sort);
            }
            sortList.Sort();
            foreach (string sort in sortList)
            {
                Console.WriteLine(sort);
            }
        }

        // Sort methode for sort entites in adress book by city.
        public void SortByCity()
        {
            contactList.Sort(new Comparison<Contact>((a, b) => string.Compare(a.city, b.city)));
            Console.WriteLine("Contacts after sorting By City = ");
            foreach (Contact contact in contactList)
            {
                Console.WriteLine("\n FirstName = " + contact.firstName + "\n Last Name = " + contact.lastName + "\n Address = " + contact.address + "\n City = " + contact.city + "\n State = " + contact.state + "\n Zip = " + contact.zip + "\n Phone Number = " + contact.phoneNumber + "\n Email = " + contact.email);
            }
        }

        // Sort methode for sort entites in adress book by state.
        public void SortByState()
        {
            contactList.Sort(new Comparison<Contact>((a, b) => string.Compare(a.state, b.state)));
            Console.WriteLine("Contacts after sorting By State = ");
            foreach (Contact contact in contactList)
            {
                Console.WriteLine("\n FirstName = " + contact.firstName + "\n Last Name = " + contact.lastName + "\n Address = " + contact.address + "\n City = " + contact.city + "\n State = " + contact.state + "\n Zip = " + contact.zip + "\n Phone Number = " + contact.phoneNumber + "\n Email = " + contact.email);
            }
        }

        // Sort methode for sort entites in adress book by zip.
        public void SortByZip()
        {
            contactList.Sort(new Comparison<Contact>((a, b) => string.Compare(a.zip, b.zip)));
            Console.WriteLine("Contacts after sorting By Zip = ");
            foreach (Contact contact in contactList)
            {
                Console.WriteLine("\n FirstName = " + contact.firstName + "\n Last Name = " + contact.lastName + "\n Address = " + contact.address + "\n City = " + contact.city + "\n State = " + contact.state + "\n Zip = " + contact.zip + "\n Phone Number = " + contact.phoneNumber + "\n Email = " + contact.email);
            }
        }
    }
}