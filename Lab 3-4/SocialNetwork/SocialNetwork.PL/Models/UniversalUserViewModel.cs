using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.PL.Models
{
    public class UniversalUserViewModel
    {
        public UsersViewModel usersView { get; set; }
        public IEnumerable<UsersViewModel> ienumToUsersView { get; set; }
        public IEnumerable<UsersViewModel> ienumFromUsersView { get; set; }
    }
}

