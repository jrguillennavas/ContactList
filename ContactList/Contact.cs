using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList
{
    internal class Contact
    {
        public string Fullname { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }

        public Contact(string fullname, string mobile, string email, string note)
        {
            Fullname = fullname;
            Mobile = mobile;
            Email = email;
            Note = note;
        }
    }
}
