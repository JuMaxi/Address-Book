using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class Contacts
    {
        public string Name;
        public string Address;
        public Email Email;
        public string CellPhoneNumber;
        public string HomePhoneNumber;
        public string CompanyPhoneNumber;
        public int ID;

        public Contacts(int NumberID, string NamePerson, string AddressPerson, string EmailPerson, string MPhonePerson, string HPhonePerson, string CPhonePerson)
        {
            Email EmailValidate = new Email(EmailPerson);

            ID = NumberID;
            Name = NamePerson;
            Address = AddressPerson;
            Email = EmailValidate;
            CellPhoneNumber = MPhonePerson;
            HomePhoneNumber = HPhonePerson;
            CompanyPhoneNumber = CPhonePerson;

            ValidateContacts();
        }

        public void ValidateContacts()
        {
            string NameTrim = Name.Trim();
            Name = NameTrim;

            if (Name.IndexOf(" ") < 0)
            {
                throw new Exception("In this field you need to put the Name + Last Name.");
            }
            if (Name == " ")
            {
                throw new Exception("This field is Mandatory. You need to put the Name + Last Name for to complet this registration.");
            }
            if ((Address.Length == 0)
                && (CellPhoneNumber.Length == 0)
                && (HomePhoneNumber.Length == 0)
                && (CompanyPhoneNumber.Length == 0)
                && (Email.EmailAddress.Length == 0))
            {
                Console.WriteLine(" ");
                throw new Exception("You need to put at least one field more to complet this registration");
            }
        }
    }
}

