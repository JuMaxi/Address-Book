using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class Phones
    {
        public string MobilePhone;
        public string HomePhone;
        public string BusinessPhone;

        public Phones(string PhoneA, string PhoneB, string PhoneC)
        {
            MobilePhone = PhoneA;
            HomePhone = PhoneB;
            BusinessPhone = PhoneC;

            Dictionary<char, string> ListPhones= new Dictionary<char, string>();
            string Keys = "ABC";
            for(int Position = 0; Position < 1; Position++)
            {
                ListPhones.Add(Keys[Position], MobilePhone);
                ListPhones.Add(Keys[Position+1], HomePhone);
                ListPhones.Add(Keys[Position+2], BusinessPhone);
            }
        }


        Menu Access = new Menu();
        public void WriteOptionsPhone()
        {
            Access.WriteNameCompany();

            Console.WriteLine("What Kind of Phone do you want to insert? ");
            Console.WriteLine("A) Mobile Phone: ");
            Console.WriteLine("B) Home Phone: ");
            Console.WriteLine("C) Business Phone: ");
            Console.WriteLine("D) Exit: ");
            Console.Write("--> ");
        }
        public Dictionary<char, string> ReadOptionsPhone(char KindPhone, Dictionary<char, string> OptionsPhone)
        {
            if (KindPhone == 'A' || KindPhone == 'B' || KindPhone == 'C')
            {
                if (OptionsPhone.ContainsKey(KindPhone))
                {
                    Console.WriteLine(" ");
                    Console.Write("Please, type the number phone: ");
                    string Phone = Console.ReadLine();
                    string OldPhone = OptionsPhone[KindPhone];

                    OptionsPhone[KindPhone] = Phone + " or " + OldPhone;

                }
                else
                {
                    Console.WriteLine(" ");
                    Console.Write("Please, type the number phone: ");
                    string Phone = Console.ReadLine();
                    OptionsPhone.Add(KindPhone, Phone);
                }
                Access.ExitMessage();
            }

            return OptionsPhone;
        }
        public Dictionary<char, string> ReturnCompletCount(Dictionary<char, string> OptionsPhone)
        {
            if (OptionsPhone.Count < 3)
            {
                string teste1 = "ABC";

                for (int Position = 0; Position < teste1.Length; Position++)
                {
                    if (OptionsPhone.ContainsKey(teste1[Position]) == false)
                    {
                        OptionsPhone.Add(teste1[Position], "Null");
                    }
                }
            }
            return OptionsPhone;
        }
    }
}
