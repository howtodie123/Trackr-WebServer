using TestTestServer.Data;
using Microsoft.AspNetCore.Mvc;
using TestTestServer.Models;
using Microsoft.EntityFrameworkCore;

namespace TestTestServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : Controller 
    {
        private readonly APIData dbContext;

        public AdminController(APIData dbContext)
        {
          this.dbContext = dbContext;
        }
        // get: lấy dữ liệu
        [HttpGet]
        public async Task<IActionResult> Get() 
        {
          return Ok(await dbContext.Admins.ToListAsync());    
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetOne([FromRoute] int id)
        {
            var admin = await dbContext.Admins.FindAsync(id);
            if (admin == null) { return NotFound(); }
            return Ok(admin);   
        }
        // post: tạo admin mới
        [HttpPost]
        public async Task<IActionResult> Add(AdminRequest addd)
        {
            var admin = new Ad()
            {
               // AdID = addd.AdID,
                AdName = addd.AdName,
                AdAccount = addd.AdAccount,
                AdPassword = addd.AdPassword,
            };
            await dbContext.Admins.AddAsync(admin);
            await dbContext.SaveChangesAsync();
            return Ok(admin);
        }
        // put: chỉnh sửa dữ liệu
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id,AdminRequest updateAdRequest)
        {
            var admin = await dbContext.Admins.FindAsync(id);
            if(admin != null) 
            {
                admin.AdName = updateAdRequest.AdName;
                admin.AdAccount = updateAdRequest.AdAccount;
                admin.AdPassword = updateAdRequest.AdPassword;

                await dbContext.SaveChangesAsync();

                return Ok(admin);
            }
            return NotFound();
        }
        // delete: xóa dữ liệu
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var admin = await dbContext.Admins.FindAsync(id);
            if (admin != null)
            {
                dbContext.Remove(admin);
                await dbContext.SaveChangesAsync();
                return Ok(admin);
            }    
            return NotFound();
        }
    }
}
