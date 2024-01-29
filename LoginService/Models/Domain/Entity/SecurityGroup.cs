using System;
using System.Collections.Generic;
using System.Text;

namespace LoginService.Models.Domain.Entity
{
    public enum Priority
    {
        User = 0,
        Admin = 1
    }

    public class SecurityGroup
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public Priority Priority { get; set; }
    }
}
