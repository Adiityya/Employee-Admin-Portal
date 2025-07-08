using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAdminPortal.Models
{
	public class EmployeeSubStaff
	{
		[Key]
		public int SubStaffId { get; set; }
		public string SubStaffName { get; set; }


		// Foreignkey to staff

		[ForeignKey("EmployeeStaff")]
		public int StaffId { get; set; }
		public EmployeeStaff EmployeeStaff { get; set; }


		// Foreignkey to employee (Directly)

        [ForeignKey("Employee")]
		public int Emp_Id { get; set; }
		public Employee Employee { get; set; }
	}
}

