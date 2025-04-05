using DemoWebAPI.Data;
using DemoWebAPI.Exceptions;
using DemoWebAPI.Model.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly MyContext _myContext;
        public EmployeesController(MyContext _myContext)
        {
            this._myContext = _myContext;
        }


        [HttpGet]
        public IActionResult GetAllEmployees()
        {

            return Ok(_myContext.Employees.ToList());
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var newemployee = new Employee()
            {
                EmployeName = addEmployeeDto.EmployeName,
                Contact = addEmployeeDto.Contact,
                Salary = addEmployeeDto.Salary,
                IsActive = true,
            };

            _myContext.Employees.Add(newemployee);
            _myContext.SaveChanges();
            return Ok(newemployee);

        }


        [HttpGet]
        [Route("{EmployeeId}")]
        public IActionResult UpdateEmployee(int EmployeeId)
        {
            var employee = _myContext.Employees.Find(EmployeeId);

            _myContext.SaveChanges();

            return Ok(employee);
        }



        [HttpPut]
        [Route("{EmployeeId}")]
        public IActionResult UpdateEmployee(int EmployeeId, UpdateDto updateDto)
        {
            var employee = _myContext.Employees.Find(EmployeeId);

            if (employee == null)
            {
                throw new IdNotFoundException("ID NOT FOUND");
            }

            employee.EmployeName = updateDto.EmployeName;
            employee.Contact = updateDto.Contact;
            employee.Salary = updateDto.Salary;

            _myContext.SaveChanges();

            return Ok(employee);
        }

        

        [HttpPut("employee-name/{EmployeeId})")]
        //[Route("{EmployeeId}")]
        public IActionResult UpdateEmployeeName(int EmployeeId, UpdateNameDto updateNameDto)
        {
            var employee = _myContext.Employees.Find(EmployeeId);

            if (employee == null)
            {
                throw new IdNotFoundException("ID NOT FOUND");
            }

            employee.EmployeName = updateNameDto.EmployeName;
            

            _myContext.SaveChanges();

            return Ok(employee);
        }

        [HttpPut("employee-isactive/{EmployeeId})")]
        //[Route("{EmployeeId}")]
        public IActionResult UpdateEmployeeIsActive(int EmployeeId, UpdateIsActiveDto updateIsActiveDto)
        {
            var employee = _myContext.Employees.Find(EmployeeId);

            if (employee == null)
            {
                throw new IdNotFoundException("ID NOT FOUND");
            }

            employee.IsActive = updateIsActiveDto.IsActive;


            _myContext.SaveChanges();

            return Ok(employee);
        }


        [HttpPut("employee-contact/{EmployeeId})")]
        //[Route("{EmployeeId}")]
        public IActionResult UpdateEmployeeContact(int EmployeeId, UpdateContactDto updateContactDto)
        {
            var employee = _myContext.Employees.Find(EmployeeId);

            if (employee == null)
            {
                throw new IdNotFoundException("ID NOT FOUND");
            }

            
            employee.Contact = updateContactDto.Contact;
           

            _myContext.SaveChanges();

            return Ok(employee);
        }

        [HttpPut("employee-salary/{EmployeeId})")]
        //[Route("{EmployeeId}")]
        public IActionResult UpdateEmployeeSalary(int EmployeeId, UpdateSalaryDto updateSalaryDto)
        {
            var employee = _myContext.Employees.Find(EmployeeId);

            if (employee == null)
            {
                throw new IdNotFoundException("ID NOT FOUND");
            }

           
            employee.Salary = updateSalaryDto.Salary;

            _myContext.SaveChanges();

            return Ok(employee);
        }


        [HttpDelete]
        [Route("{EmployeeId}")]
        public IActionResult DeleteEmployee(int EmployeeId, UpdateDto updateDto)
        {
            var employee = _myContext.Employees.Find(EmployeeId);

            if (employee == null)
            {
                throw new IdNotFoundException("ID NOT FOUND");
            }

            employee.IsActive = false;
           

            _myContext.SaveChanges();

            return Ok(employee);
        }

        



    }
}
