﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kinetic.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ViewName { get; set; }
        
        public ICollection<Space.Space> Spaces { get; set; }
        public ICollection<User> Friends { get; set; }
    }
}
