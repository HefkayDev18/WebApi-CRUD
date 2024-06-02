using EMP_WebApiCRUD.Data;
using EMP_WebApiCRUD.Models.Entities;
using EMP_WebApiCRUD.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMP_WebApiCRUD.Controllers
{
    //localhost.../api/emp
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        //private readonly ApplicationDbContext dbContext;
        private readonly ApplicationDbContext _db;

        public EmpController(ApplicationDbContext db) 
        {
            //this.dbContext = dbContext;
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var EmpList = _db.Employees.ToList();

            return Ok(EmpList);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeVM employeeVM)
        {
            var newEmployee = new Employee()
            {
                Name = employeeVM.Name,
                Email = employeeVM.Email,
                Phone = employeeVM.Phone,
                Salary = employeeVM.Salary
            };

            _db.Employees.Add(newEmployee);
            _db.SaveChanges();

            return Ok(newEmployee);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetEmployeeById(int id)
        {
            var foundEmployee = _db.Employees.Find(id);

            if (foundEmployee == null)
            {
                return NotFound();
            }

            return Ok(foundEmployee);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateEmployee(int id, UpdateEmployeeVm updEmpVM)
        {
            var updatedEmployee = _db.Employees.Find(id);

            if(updatedEmployee is null)
            {
                return NotFound();
            }
            else
            {
                updatedEmployee.Name = updEmpVM.Name;
                updatedEmployee.Email = updEmpVM.Email;
                updatedEmployee.Phone = updEmpVM.Phone;
                updatedEmployee.Salary = updEmpVM.Salary;

                _db.SaveChanges();

                return Ok(updatedEmployee);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteEmployee(int id) 
        {
            var foundEmployee = _db.Employees.Find(id);

            if(foundEmployee is null)
            {
                return NotFound();
            }

            _db.Employees.Remove(foundEmployee);
            _db.SaveChanges();

            return Ok("Employee successfully deleted");
        }
    }
}
