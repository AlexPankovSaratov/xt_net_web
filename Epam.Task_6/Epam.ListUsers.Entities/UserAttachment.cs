using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ListUsers.Entities
{
    public class UserAttachment
    {
        public string Password { get; set; }
        public string Login { get; set; }
        public HashSet<string> Roles { get; set; } = new HashSet<string>();
    }
}
