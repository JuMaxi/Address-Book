using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class Email
    {
        public string EmailAddress;

        public Email(string Email) 
        { 
            EmailAddress= Email;

            ValidateEmail(EmailAddress);
        }

        public void ValidateEmail(string Email)
        {
            bool ValidEmail = false;

            if ((Email.Length > 0)
               && (Email.IndexOf(" ") < 0)
               && (Email.IndexOf("@") >= 0))
            {
                int Check = Email.IndexOf("@");

                for (int Position = Check + 2; Position < Email.Length; Position++)
                {
                    if (Email[Position] == 46)
                    {
                        if (Position != (Email.Length - 1))
                        {
                            ValidEmail = true;
                        }
                    }
                }
            }
            if (ValidEmail == false)
            {
                throw new Exception("This email is invalid. Put a valid email to continue this registry.");
            }
        }
    }
}
