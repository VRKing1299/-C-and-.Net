using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public DateTime EnrolledDate { get; set; }
    }
}