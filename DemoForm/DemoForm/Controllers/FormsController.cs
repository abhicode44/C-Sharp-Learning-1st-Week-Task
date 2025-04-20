using DemoForm.Data;
using DemoForm.Model;
using Microsoft.AspNetCore.Mvc;


namespace DemoForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : ControllerBase
    {
          MyContext _context;


        public FormsController(MyContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddForm([FromBody] Form form)
        {
            var newForm = new Form
            {
                name = form.name,
                email = form.email,
                password = form.password
            };

            _context.Add(newForm);
            _context.SaveChanges();

            return Ok(new { message = "Form submitted successfully." });
        }

        [HttpGet]

        public async Task<IActionResult> GetAllRecords()
        {
            return Ok(_context.Form.ToList());
        }

       
    }
}
