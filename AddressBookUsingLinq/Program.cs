using System;
using System.Collections.Generic;
using System.Data;

namespace AddressBookUsingLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to address book problem using Linq!");
            AddressBook addressBook = new AddressBook();
            List<Contact> contactList = addressBook.contactList;
            addressBook.CreateTableColumns();
            Contact contact1 = new Contact() {FirstName="Mihir",LastName="Gautam",Address="Kanpur",City="Kanpur",State="UP",ZipCode=202042,PhoneNumber=8686453524, EmailID="mihir@example.com" };
            Contact contact2 = new Contact() { FirstName = "Tushar", LastName = "Gautam", Address = "Kanpur", City = "Lucknow", State = "UP", ZipCode = 202042, PhoneNumber = 463463462, EmailID = "tushar@example.com" };
            Contact contact3 = new Contact() { FirstName = "Ankit", LastName = "Tomar", Address = "Kanpur", City = "ALD", State = "MP", ZipCode = 202042, PhoneNumber = 586668876, EmailID = "ankit@example.com" };
            Contact contact4 = new Contact() { FirstName = "Sharad", LastName = "Pal", Address = "Kanpur", City = "DEL", State = "Delhi", ZipCode = 202042, PhoneNumber = 857565643, EmailID = "sharad@example.com" };
            contactList.Add(contact1);
            contactList.Add(contact2);
            contactList.Add(contact3);
            contactList.Add(contact4);
            int loop = 1;
            while (loop == 1)
            {
                Console.WriteLine("Enter your choice: \n1.Insert a new contact \n2.Edit existing contact \n3.Delete existing contact \n4.View contacts by state \n5.View contacts by city \n6.Exit.");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        addressBook.InsertContactToTable();
                        Console.WriteLine("Addressbook updated!");
                        break;
                    case 2:
                        addressBook.EditExistingContact(contactList);
                        Console.WriteLine("Addressbook updated!");
                        break;
                    case 3:
                        addressBook.DeleteContact();
                        Console.WriteLine("Addressbook updated!");
                        break;
                    case 4:
                        Console.Write("Enter the state: ");
                        string state = Console.ReadLine();
                        addressBook.RetrievePersonBelongingToAState(contactList, state);
                        break;
                    case 5:
                        Console.Write("Enter the city: ");
                        string city = Console.ReadLine();
                        addressBook.RetrievePersonBelongingToACity(contactList, city);
                        break;
                    case 6:
                        loop = 0;
                        break;
                }
            }
        }
    }
}
