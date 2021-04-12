using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Contact:IEntity
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Subject { get; set; }

    }
}
