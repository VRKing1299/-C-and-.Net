using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public string UserRole { get; set; } // Student / Instructor / Admin
        public DateTime CreatedAt { get; set; }
    }
}