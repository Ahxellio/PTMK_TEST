using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTMK_TEST.Entity
{
    public class Employee
    {
        public Employee() { }
        public Employee(int id, string fullname, DateTime birthdaydate, string gender)
        {
            Id = id;
            FullName = fullname;
            BirthdayDate = birthdaydate;
            Gender = gender;
        }
        public Employee(string fullname, DateTime birthdaydate, string gender)
        {
            FullName = fullname;
            BirthdayDate = birthdaydate;
            Gender = gender;
        }
        [Key] 
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public DateTime BirthdayDate { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}
