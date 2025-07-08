using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAdminPortal.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeFullDataController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeeFullDataController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetFullData")]
        public async Task<IActionResult> GetFullData()
        {
            var data = await _context.Employees
                .Include(e => e.EmployeeStaffs)
                    .ThenInclude(s => s.EmployeeSubStaffs)
                .ToListAsync();

            return Ok(data);
        }

    }
}