using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTMK_TEST.Entity
{
    public class EmployeeDto
    {
        public EmployeeDto(int id, string fullname, DateTime birthdaydate, string gender, int age)
        {
            Id = id;
            FullName = fullname;
            BirthdayDate = birthdaydate;
            Gender = gender;
            Age = age;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public DateTime BirthdayDate { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
