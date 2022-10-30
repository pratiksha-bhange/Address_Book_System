﻿using System;
using System.Collections.Generic;

namespace Address_Book_System
{
    class Program
    {
        // for add,edit,delete,display contacts of person in both the adress book with the help of dictionary.
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book program");

            Dictionary<string, AddressBook> adressBookDictionary = new Dictionary<string, AddressBook>();
            Dictionary<string, List<string>> cityDisc = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> StateDisc = new Dictionary<string, List<string>>();

            while (true)
            {
                try
                {
                    Console.WriteLine("How many adress book you want = ");
                    int numOfAdressBook = Convert.ToInt32(Console.ReadLine());
                    for (int i = 1; i <= numOfAdressBook; i++)
                    {
                        Console.WriteLine("Enter the name of adress book = " + i + "=");
                        string adressBookName = Console.ReadLine();
                        AddressBook adressBook = new AddressBook();
                        adressBookDictionary.Add(adressBookName, adressBook);
                    }
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter integer number,\n string is not allowes \n enter unique name for book \n duplicate name not allowed");
                }
            }

            while (true)
            {
                try
                {
                    Console.WriteLine("You have created following adress book");
                    foreach (string k in adressBookDictionary.Keys)
                    {
                        Console.WriteLine(k);
                    }
                    Console.WriteLine("\n 1 for Add Contact \n 2 for Edit Existing Contact \n 3 for delete the person,\n 4 for display,\n 5 for Enter city or state ,\n 6 for Sort by first name,\n 7 for Sort by city,\n 8 for Sort by state, \n 9 for Sort by zip,\n 10 for write in Txt File,\n 11 for Read From Txt File, \n 12 for exit");
                    int choise = Convert.ToInt32(Console.ReadLine());
                    switch (choise)
                    {
                        case 1:
                            Console.WriteLine("Enter the Adress book name where you want to add contact");
                            string addContactInAdressBook = Console.ReadLine();
                            if (adressBookDictionary.ContainsKey(addContactInAdressBook))
                            {
                                Console.WriteLine("Enter how many contact you want to add");
                                int numOfContact = Convert.ToInt32(Console.ReadLine());
                                for (int i = 1; i <= numOfContact; i++)
                                {
                                    TakeInputAndAddToContact(adressBookDictionary[addContactInAdressBook]);
                                }
                                adressBookDictionary[addContactInAdressBook].displayContact();
                            }
                            else
                            {
                                Console.WriteLine("No adress book found ", addContactInAdressBook);
                            }
                            break;
                        case 2:
                            Console.WriteLine("Enter the Adress book name where you want to edit contact = ");
                            string editContactInAdressBook = Console.ReadLine();
                            if (adressBookDictionary.ContainsKey(editContactInAdressBook))
                            {
                                Console.WriteLine("Enter first name to edit contact =");
                                string firstNameForEditContact = Console.ReadLine();
                                adressBookDictionary[editContactInAdressBook].Edit(firstNameForEditContact);
                                adressBookDictionary[editContactInAdressBook].displayContact();
                            }
                            break;
                        case 3:
                            Console.WriteLine("Enter the Adress book name where you want to delete contact = ");
                            string deleteContactInAdressBook = Console.ReadLine();
                            if (adressBookDictionary.ContainsKey(deleteContactInAdressBook))
                            {
                                Console.WriteLine("Enter first name to delete contact =");
                                string firstNameForDeleteContact = Console.ReadLine();
                                adressBookDictionary[deleteContactInAdressBook].delete(firstNameForDeleteContact);
                                adressBookDictionary[deleteContactInAdressBook].displayContact();
                            }
                            break;
                        case 4:
                            Console.WriteLine("Enter the Adress book name to display contact = ");
                            string displayContactInAdressBook = Console.ReadLine();
                            adressBookDictionary[displayContactInAdressBook].displayContact();
                            break;
                        case 5:
                            Console.WriteLine("Enter 1 for city 2 for state ");
                            String area = Console.ReadLine();
                            if (area.Contains("1"))
                            {
                                cityDisc = FindByCityOrState(adressBookDictionary);
                                DisplayPersonDisc(cityDisc);
                            }
                            else
                            {
                                StateDisc = FindByCityOrState(adressBookDictionary);
                                DisplayPersonDisc(StateDisc);
                            }
                            break;
                        case 6:
                            Console.WriteLine("Enter Adress Book Name To Sort Contacts = ");
                            string sortByFirstNameInAddressBook = Console.ReadLine();
                            adressBookDictionary[sortByFirstNameInAddressBook].SortByFirstName();
                            break;
                        case 7:
                            Console.WriteLine("Enter Adress Book Name To Sort Contacts = ");
                            string sortByCityInAdressBook = Console.ReadLine();
                            adressBookDictionary[sortByCityInAdressBook].SortByCity();
                            break;
                        case 8:
                            Console.WriteLine("Enter Adress Book Name To Sort Contacts = ");
                            string sortByStateInAdressBook = Console.ReadLine();
                            adressBookDictionary[sortByStateInAdressBook].SortByState();
                            break;
                        case 9:
                            Console.WriteLine("Enter Adress Book Name To Sort Contacts = ");
                            string sortByZipInAdressBook = Console.ReadLine();
                            adressBookDictionary[sortByZipInAdressBook].SortByZip();
                            break;
                        case 10:

                            Console.WriteLine("Enter Adress Book Name To Store/write Contacts = ");
                            string writeInAddressBook = Console.ReadLine();
                            adressBookDictionary[writeInAddressBook].writeInTxtFile();
                            break;
                        case 11:
                            Console.WriteLine("Enter Adress Book Name To Store/write Contacts = ");
                            string ReadAddressBook = Console.ReadLine();
                            adressBookDictionary[ReadAddressBook].readFromTxtFile();
                            break;
                        case 12:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Enter The Valid Choise");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("please enter integer options only");
                }
            }
        }

        public static Dictionary<string, List<string>> FindByCityOrState(Dictionary<string, AddressBook> adressBookDictionary)
        {
            Dictionary<string, List<string>> areaDisc = new Dictionary<string, List<string>>();
            Console.WriteLine("Enter the city or state where you want to find that person = ");
            string findPlace = Console.ReadLine();
            foreach (var element in adressBookDictionary)
            {
                List<string> listOfPersonsInPlace = element.Value.FindPersons(findPlace);
                foreach (var name in listOfPersonsInPlace)
                {
                    if (!areaDisc.ContainsKey(findPlace))
                    {
                        List<string> personList = new List<string>();
                        personList.Add(name);
                        areaDisc.Add(findPlace, personList);
                    }
                    else
                    {
                        areaDisc[findPlace].Add(name);
                    }
                }
            }
            return areaDisc;

            // displayPersonDisc for displaying person with area and count the contact.
            public static void DisplayPersonDisc(Dictionary<string, List<string>> areaDisc)
            {
                int count = 0;
                foreach (var index in areaDisc)
                {
                    foreach (var personName in index.Value)
                    {
                        count++;
                        Console.WriteLine("personName:-" + personName + "display area:-" + index.Key);
                    }
                }
                Console.WriteLine("count:-" + count);
            }

            public static void TakeInputAndAddToContact(AddressBook adressBook)
            {
                Console.WriteLine("Enter firstName");
                string firstName = Console.ReadLine();

                Console.WriteLine("Enter lastName");
                string lastName = Console.ReadLine();

                Console.WriteLine("Enter email");
                string email = Console.ReadLine();

                Console.WriteLine("Enter phoneNumber");
                string phoneNumber = Console.ReadLine();

                Console.WriteLine("Enter address");
                string address = Console.ReadLine();

                Console.WriteLine("Enter zip");
                string zip = Console.ReadLine();

                Console.WriteLine("Enter city");
                string city = Console.ReadLine();

                Console.WriteLine("Enter state");
                string state = Console.ReadLine();

                if ((firstName != "") || (lastName != "") || (address != "") || (city != "") || (state != "") || (zip != "") || (email != "") || (phoneNumber != ""))
                {
                    adressBook.addContact(firstName, lastName, email, phoneNumber, address, zip, city, state);
                }
                else
                {
                    Console.WriteLine("Empty string not allowed \n for add contacts please give the input in string");
                }
            }
        }
    }
    