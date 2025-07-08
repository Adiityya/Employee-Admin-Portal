using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAdminPortal.Models
{
	public class EmployeeStaff
	{

		[Key]
		public int StaffId { get; set; }

		[Required]
		public string StaffName { get; set; }


		// Foreign key to Employee

        [ForeignKey("Employee")]
		public int Emp_Id { get; set; }
		public Employee Employee { get; set; }

        // staffs collection (One to many)
        public ICollection<EmployeeSubStaff> EmployeeSubStaffs { get; set; }
	}
}

