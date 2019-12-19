using System;
using System.Collections.Generic;
using System.Linq;
using OnlineStore.Models.Database;

namespace OnlineStore.Models.ViewModel
{
    public class AdminUsers
    {
        public List<User> Admins { get; set;}
        public List<User> Moderators { get; set; }
        public List<User> Users { get; set; }
    }
}
