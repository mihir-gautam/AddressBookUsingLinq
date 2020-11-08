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
            int loop = 1;
            while (loop == 1)
            {
                Console.WriteLine("Enter your choice: \n1.Insert a new contact \n2.Edit existing contact \n3.Delete existing contact  \n4.Exit.");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        addressBook.InsertContactToTable();
                        break;
                    case 2:
                        addressBook.EditExistingContact(contactList);
                        break;
                    case 3:
                        addressBook.DeleteContact();
                        break;
                    case 4:
                        loop = 0;
                        break;
                }
                Console.WriteLine("Addressbook updated!");
            }
        }
    }
}
