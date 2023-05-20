using TestTestServer.Data;
using Microsoft.AspNetCore.Mvc;
using TestTestServer.Models;
using Microsoft.EntityFrameworkCore;

namespace TestTestServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly APIData dbContext;

        public CustomerController(APIData dbContext)
        {
            this.dbContext = dbContext;
        }
        // get: lấy dữ liệu
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await dbContext.Customer.ToListAsync());
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetOne([FromRoute] int id)
        {
            var customer = await dbContext.Customer.FindAsync(id);
            if (customer == null) { return NotFound(); }
            return Ok(customer);
        }
        // post: tạo  mới
        [HttpPost]
        public async Task<IActionResult> Add(CustomerRequest addd)
        {
            var customer = new Customer()
            {
                // CusID = addd.CusID,
                CusName = addd.CusName,
                CusAddress = addd.CusAddress,
                CusPhone = addd.CusPhone,
                CusBirth = addd.CusBirth,
                CusDateRegister = addd.CusDateRegister,
                CusAccount = addd.CusAccount,
                CusPassword = addd.CusPassword,
            };
            await dbContext.Customer.AddAsync(customer);
            await dbContext.SaveChangesAsync();
            return Ok(customer);
        }
        // put: chỉnh sửa dữ liệu
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, CustomerRequest Update)
        {
            var customer = await dbContext.Customer.FindAsync(id);
            if (customer != null)
            {
                customer.CusName = Update.CusName;
                customer.CusAddress = Update.CusAddress;
                customer.CusPhone = Update.CusPhone;
                customer.CusBirth = Update.CusBirth;
                customer.CusDateRegister = Update.CusDateRegister;
                customer.CusAccount = Update.CusAccount;
                customer.CusPassword = Update.CusPassword;
               
                await dbContext.SaveChangesAsync();

                return Ok(customer);
            }
            return NotFound();
        }
        // delete: xóa dữ liệu
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var customer = await dbContext.Customer.FindAsync(id);
            if (customer != null)
            {
                dbContext.Remove(customer);
                await dbContext.SaveChangesAsync();
                return Ok(customer);
            }
            return NotFound();
        }
    }
}
