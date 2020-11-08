﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace AddressBookUsingLinq
{
    class AddressBook
    {
        public List<Contact> contactList = new List<Contact>();
        /// <summary>
        /// UC1 New empty database for address book created;
        /// </summary>
        DataTable dataTable = new DataTable() { };
        /// <summary>
        /// UC2 Method to create table with person details as attribute in columns 
        /// </summary>
        public void CreateTableColumns()
        {
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("Address", typeof(string));
            dataTable.Columns.Add("City", typeof(string));
            dataTable.Columns.Add("State", typeof(string));
            dataTable.Columns.Add("ZipCode", typeof(int));
            dataTable.Columns.Add("PhoneNumber", typeof(long));
            dataTable.Columns.Add("EmailID", typeof(string));
        }
        /// <summary>
        /// UC3 Method to insert data into the address book contact table
        /// </summary>
        public void InsertContactToTable()
        {
            Console.Write("\nEnter the first name of the contact : ");
            string firstName = Console.ReadLine();
            Console.Write("\nEnter the last name of the contact : ");
            string lastName = Console.ReadLine();
            Console.Write("\nEnter the address of the contact : ");
            string address = Console.ReadLine();
            Console.Write("\nEnter the city of the contact : ");
            string city = Console.ReadLine();
            Console.Write("\nEnter the state of the contact : ");
            string state = Console.ReadLine();
            Console.Write("\nEnter the zip code of the contact : ");
            int zip = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the phone number of the contact : ");
            long phone = Convert.ToInt64(Console.ReadLine());
            Console.Write("\nEnter the email id of the contact : ");
            string email = Console.ReadLine();

            dataTable.Rows.Add(firstName, lastName, address, city, state, zip, phone, email);
            Contact contact = new Contact() { FirstName = firstName, LastName = lastName, Address = address, City = city, 
                State = state, ZipCode = zip, PhoneNumber = phone, EmailID = email };
            contactList.Add(contact);
            Console.WriteLine("Contact details added successfully!");
        }
        /// <summary>
        /// UC 4 Method to edit existing contact details
        /// </summary>
        /// <param name="contactList"></param>
        public void EditExistingContact(List<Contact> contactList)
        {
            Console.Write("\nEnter the first name of the contact : ");
            string firstName = Console.ReadLine();
            Console.Write("\nEnter the last name of the contact : ");
            string lastName = Console.ReadLine();
            var record = from details in contactList
                         where details.FirstName.ToLower().Equals(firstName.ToLower()) && details.LastName.ToLower().Equals(lastName.ToLower())
                         select details;
            foreach(var contact in record)
            {
                if(contact.FirstName.ToLower() == firstName.ToLower() && contact.LastName.ToLower() == lastName.ToLower())
                {
                    Console.WriteLine("Contact found! \nDetails are - ");
                    Console.WriteLine(firstName+","+lastName+","+contact.Address+","+contact.City+","
                        +contact.State+","+contact.ZipCode+","+contact.PhoneNumber+","+contact.EmailID);

                    Console.Write("\nEnter the new address of the contact : ");
                    contact.Address = Console.ReadLine();
                    Console.Write("\nEnter the new city of the contact : ");
                    contact.City = Console.ReadLine();
                    Console.Write("\nEnter the new state of the contact : ");
                    contact.State = Console.ReadLine();
                    Console.Write("\nEnter the new zip code of the contact : ");
                    contact.ZipCode = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\nEnter the new phone number of the contact : ");
                    contact.PhoneNumber = Convert.ToInt64(Console.ReadLine());
                    Console.Write("\nEnter the new email id of the contact : ");
                    contact.EmailID = Console.ReadLine();
                    
                    Console.WriteLine("Contact details updated successfully!\n New details are -");
                    Console.WriteLine(firstName + "," + lastName + "," + contact.Address + "," + contact.City + ","
                        + contact.State + "," + contact.ZipCode + "," + contact.PhoneNumber + "," + contact.EmailID);
                }
                else
                {
                    Console.WriteLine("No such contact found.");
                }
            }
        }
    }
}
