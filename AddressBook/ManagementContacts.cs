using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class ManagementContacts
    {
        public List<Contacts> AddContacts = new List<Contacts>();
        public void AddNewContact(Contacts NewContact)
        {
            AddContacts.Add(NewContact);
        }

        public void ShowContacts()
        {
            Menu Access = new Menu();
            Access.WriteNameCompany();

            foreach (Contacts Line in AddContacts)
            {
                Console.WriteLine("ID Number: " + Line.ID);
                Console.WriteLine("Name: " + Line.Name);
                Console.WriteLine("Address: " + Line.Address);
                Console.WriteLine("Email: " + Line.Email.EmailAddress);
                Console.WriteLine("Mobile Phone: " + Line.CellPhoneNumber);
                Console.WriteLine("Home Phone: " + Line.HomePhoneNumber);
                Console.WriteLine("Company Phone: " + Line.CompanyPhoneNumber);
                Console.WriteLine(" ");
            }
        }

        public void RemoveContacts(int NumberID)
        {
            for (int Position = 0; Position < AddContacts.Count; Position++)
            {
                if (AddContacts[Position].ID == NumberID)
                {
                    Console.WriteLine("The contact, ID Number " + NumberID + " was deleted with success.");

                    AddContacts.Remove(AddContacts[Position]);

                    Position = AddContacts.Count;
                }
            }
        }
    }
}