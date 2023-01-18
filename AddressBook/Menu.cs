using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class Menu
    {
        public void WriteNameCompany()
        {
            Console.WriteLine("|-----------------------|");
            Console.WriteLine("|   Happy Address Book  |");
            Console.WriteLine("|-----------------------|");
            Console.WriteLine(" ");

        }
        public void WriteText()
        {
            WriteNameCompany();

            Console.WriteLine("Please choose the Option you want: ");
            Console.WriteLine("1) Add new contact:");
            Console.WriteLine("2) Show contacts list:");
            Console.WriteLine("3) Remove contact:");
            Console.WriteLine("4) Exit: ");
            Console.Write("-->");
        }
        public void ExitMessage()
        {
            Console.WriteLine(" ");
            Console.Write("Type any key to return");
            Console.ReadKey();
            Console.Clear();
        }
        public int CalculateID(ManagementContacts Access)
        {
            int LastID =  Access.AddContacts.Count + 1;

            return LastID;
        }

        public void ReadFile(ManagementContacts AccessMC)
        {
            string Path = @"C:\Dev\AddressBook\AddressBook\database.csv";

            if (File.Exists(Path))
            {
                string[] ReadTxt = File.ReadAllLines(Path);

                foreach (string Line in ReadTxt)
                {
                    Contacts AccessContacts = new Contacts();

                    string[] BreakTxt = Line.Split(";");
                    int NumberID = Convert.ToInt32(BreakTxt[0]);

                    AccessContacts.Initialize(NumberID, BreakTxt[1], BreakTxt[2], BreakTxt[3], BreakTxt[4], BreakTxt[5],BreakTxt[6]);

                    AccessMC.AddNewContact(AccessContacts);
                }
            }
        }
            
        public void WriteFile(List<Contacts> WriteContact)
        {
            string Path = @"C:\Dev\AddressBook\AddressBook\database.csv";
            List<string> WriteFile = new List<string>();

            foreach(Contacts Line in WriteContact)
            {
                string LineActual = (Line.ID + ";" + Line.Name + ";" + Line.Address + ";" + Line.Email + ";" + Line.CellPhoneNumber + ";" + Line.HomePhoneNumber + ";" + Line.CompanyPhoneNumber);
                WriteFile.Add(LineActual);
            }

           File.WriteAllLines(Path, WriteFile);
        }

        bool ExitContacts = false;
        string Choose = "0";
        public void OptionsContacts(ManagementContacts AccessMC)
        {
            ReadFile(AccessMC);

            while (ExitContacts == false)
            {
                WriteText();

                Choose = Console.ReadLine();

                Console.Clear();

                if(Choose == "1")
                {
                    WriteNameCompany();

                    Contacts AccessContacts = new Contacts();

                    Console.Write("Please type the Name + Last Name: ");
                    AccessContacts.Name = (Console.ReadLine());

                    Console.Write("Please type the Address: ");
                    AccessContacts.Address= Console.ReadLine();

                    Console.Write("Please type the Email: ");
                    AccessContacts.Email= Console.ReadLine();

                    Console.Write("Please type the Mobile Phone Number: ");
                    AccessContacts.CellPhoneNumber= Console.ReadLine();

                    Console.Write("Please type the Home Phone Number: ");
                    AccessContacts.HomePhoneNumber = Console.ReadLine();

                    Console.Write("Please type the Company Phone Number: ");
                    AccessContacts.CompanyPhoneNumber = Console.ReadLine();

                    int NumberID = CalculateID(AccessMC);

                    try
                    {
                        AccessContacts.Initialize(NumberID, AccessContacts.Name, AccessContacts.Address, AccessContacts.Email, AccessContacts.CellPhoneNumber, AccessContacts.HomePhoneNumber, AccessContacts.CompanyPhoneNumber);
                        AccessMC.AddNewContact(AccessContacts);
                    }
                    catch(Exception ex) 
                    {
                        Console.WriteLine("Something is wrong. Check the error message: " + ex.Message);
                    }

                    ExitMessage();
                }
                if(Choose == "2")
                {
                    AccessMC.ShowContacts();
                    ExitMessage();
                }
                if(Choose == "3")
                {
                    Console.Write("Please, type the ID: ");
                    string Email = Console.ReadLine();
                    int EmailInt = Convert.ToInt32(Email);

                    AccessMC.RemoveContacts(EmailInt);
                    ExitMessage();
                }
                if(Choose == "4")
                {
                    WriteFile(AccessMC.AddContacts);
                    ExitContacts = true;
                }
            }
        }




    }
}
