using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookADO
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to AddressBookADO.Net!");
            AddressBookRepository repository = new AddressBookRepository();
            repository.EnsureDataBaseConnection();
            repository.GetAllContact();
            AddNewContactDetails();
            Console.WriteLine(repository.EditContactUsingName("Neha", "Singh", "Friend") ? "Update done successfully\n" : "Update failed");
            Console.WriteLine(repository.DeleteContact("Neha", "Singh") ? "Deleted Contact successfully\n" : "Update failed");
            repository.RetrieveContactFromCityOrStateName();
        }

        public static void AddNewContactDetails()
        {
            AddressBookRepository repository = new AddressBookRepository();
            AddressBookModel model = new AddressBookModel();
            model.FirstName = "Daksha";
            model.LastName = "Neel";
            model.Address = "Sadashivanagar";
            model.City = "Bnagalore";
            model.State = "Karnataka";
            model.Zip = 788776;
            model.PhoneNumber = 887788779;
            model.EmailId = "daksh@gmail.com";
            model.AddressBookName = "neha";
            model.AddressBookType = "Friend";
            Console.WriteLine(repository.AddDataToTable(model) ? "Record inserted successfully\n" : "Failed");
        }
    }
}
