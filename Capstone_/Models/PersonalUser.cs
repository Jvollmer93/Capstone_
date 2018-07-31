using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone_.Models
{
    public class PersonalUser
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool AcceptsTextNotifications { get; set; }
        public bool AcceptsEmailNotifications { get; set; }
        public List<PersonalUser> PersonalFollowwers { get; set; }
        public List<PersonalUser> PersonalFollowing { get; set; }
        public List<Company> CompanyFollowwers { get; set; }
        public List<Company> CompanyFollowing { get; set; }
    }
}