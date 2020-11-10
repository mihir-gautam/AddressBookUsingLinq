using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
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
            dataTable.Columns.Add("BookName", typeof(string));
            dataTable.Columns.Add("ContactType", typeof(string));
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
                    Console.WriteLine(contact.BookName + "," + contact.ContactType + "," + firstName + "," + lastName + "," + contact.Address + "," + contact.City + ","
                        + contact.State + "," + contact.ZipCode + "," + contact.PhoneNumber + "," + contact.EmailID);
                }
                else
                {
                    Console.WriteLine("No such contact found.");
                }
            }
        }
        /// <summary>
        /// UC5 Method to delete a contact from the address book
        /// </summary>
        public void DeleteContact()
        {
            Console.Write("\nEnter the first name of the contact : ");
            string firstName = Console.ReadLine();
            Console.Write("\nEnter the last name of the contact : ");
            string lastName = Console.ReadLine();
            var record = from details in contactList
                         where details.FirstName.ToLower().Equals(firstName.ToLower()) && details.LastName.ToLower().Equals(lastName.ToLower())
                         select details;
            if (record != null)
            {
                contactList.RemoveAll(item => item == record);
                Console.WriteLine("Contact successfully deleted!");
            }
            else
                Console.WriteLine("No such contact found.");
            }
        /// <summary>
        /// UC6 Ability to retrieve person details by state
        /// </summary>
        /// <param name="contactList"></param>
        /// <param name="state"></param>
        public void RetrievePersonBelongingToAState(List<Contact> contactList,string state)
        {
            var record = from details in contactList
                         where details.State.ToUpper() == state.ToUpper()
                         select details;
            foreach (var contact in record)
            {
                Console.WriteLine(contact.FirstName+" "+contact.LastName);
            }
        }
        /// <summary>
        /// UC6 Ability to retrieve person details by city
        /// </summary>
        /// <param name="contactList"></param>
        /// <param name="city"></param>
        public void RetrievePersonBelongingToACity(List<Contact> contactList,string city)
        {
            var record = from details in contactList
                         where details.City.ToLower() == city.ToLower()
                         select details;
            foreach (var contact in record)
            {
                Console.WriteLine(contact.FirstName + " " + contact.LastName);
            }
        }
        /// <summary>
        /// UC7 Method to retrieve number of contacts in particular city
        /// </summary>
        /// <param name="contactList"></param>
        /// <param name="city"></param>
        public void CountPersonByCity(List<Contact> contactList, string city)
        {
            var record = contactList.Where(x=>x.City.ToLower()==city.ToLower()).GroupBy(x => x.City).Select(x => new {city = x.Key, Count = x.Count() });
            foreach (var contact in record)
            {
                Console.WriteLine(city + "-->" + contact.Count);
            }
        }
        /// <summary>
        /// UC7 Method to retrieve number of contacts in particular state
        /// </summary>
        /// <param name="contactList"></param>
        /// <param name="state"></param>
        public void CountPersonByState(List<Contact> contactList, string state)
        {
            var record = contactList.Where(x => x.State.ToUpper() == state.ToUpper()).GroupBy(x => x.State).Select(x => new { state = x.Key, Count = x.Count() });
            foreach (var contact in record)
            {
                Console.WriteLine(state + "-->" + contact.Count);
            }
        }
        /// <summary>
        /// UC8 Method to sort contacts alphabetically by name for given city
        /// </summary>
        /// <param name="contactList"></param>
        /// <param name="city"></param>
        public void SortAlphabeticallyByName(List<Contact> contactList,string city)
        {
            var record = from contact in contactList
                         where contact.City.ToLower()==city.ToLower()
                         orderby contact.FirstName, contact.LastName
                         select contact;
            foreach (var contact in record)
            {
                Console.WriteLine(contact.BookName+","+contact.ContactType+","+contact.FirstName +"," + contact.LastName + "," + contact.Address + "," + contact.City + ","
                        + contact.State + "," + contact.ZipCode + "," + contact.PhoneNumber + "," + contact.EmailID);
            }
        }
    }
}
