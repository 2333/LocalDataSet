using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocalEntity.Entities
{
    public class User
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Password { get; set; }
        public virtual string Email { get; set; }
    }
}
