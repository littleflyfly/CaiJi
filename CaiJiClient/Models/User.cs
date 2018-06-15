using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaiJiClient.Models
{
    public class User
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Password { get; set; }
        public virtual string AccessToken { get; set; }
    }
}
