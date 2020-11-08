using System;
using System.Data;

namespace AddressBookUsingLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to address book problem using Linq!");
            AddressBook addressBook = new AddressBook();
            addressBook.CreateTableColumns();
        }
    }
}
