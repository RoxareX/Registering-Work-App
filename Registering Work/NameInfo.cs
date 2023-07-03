using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registering_Work
{
    public class NameInfo
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Workflow { get; set; }
        public bool Checkmark { get; set; }

        public NameInfo(string name, string address, string phone, string email, string workflow, bool checkmark)
        {
            Name = name;
            Address = address;
            Phone = phone;
            Email = email;
            Workflow = workflow;
            Checkmark = checkmark;
        }
    }

}
