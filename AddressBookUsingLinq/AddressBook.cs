using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AddressBookUsingLinq
{
    class AddressBook
    {
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
            dataTable.Columns.Add("PhoneNumber", typeof(int));
            dataTable.Columns.Add("EmailID", typeof(string));
        }
    }
}
