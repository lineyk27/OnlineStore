using System;
using System.Collections.Generic;

namespace OnlineStore.Models.Database
{
    public class UserRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
