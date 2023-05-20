using TestTestServer.Data;
using Microsoft.AspNetCore.Mvc;
using TestTestServer.Models;
using Microsoft.EntityFrameworkCore;

namespace TestTestServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryManController : Controller
    {
        private readonly APIData dbContext;

        public DeliveryManController(APIData dbContext)
        {
            this.dbContext = dbContext;
        }
        // get: lấy dữ liệu
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await dbContext.DeliveryMan.ToListAsync());
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetOne([FromRoute] int id)
        {
            var Deliveryman = await dbContext.DeliveryMan.FindAsync(id);
            if (Deliveryman == null) { return NotFound(); }
            return Ok(Deliveryman);
        }
        // post: tạo  mới
        [HttpPost]
        public async Task<IActionResult> Add(DeliveryManRequest addd)
        {
            var deliveryMan = new DeliveryMan()
            {
                // ManID = addd.ManID,
                ManName = addd.ManName,
                ManPhone = addd.ManPhone,
                ManAccount = addd.ManAccount,
                ManPassword = addd.ManPassword,
            };
            await dbContext.DeliveryMan.AddAsync(deliveryMan);
            await dbContext.SaveChangesAsync();
            return Ok(deliveryMan);
        }
        // put: chỉnh sửa dữ liệu
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, DeliveryManRequest Update)
        {
            var deliveryMan = await dbContext.DeliveryMan.FindAsync(id);
            if (deliveryMan != null)
            {
                deliveryMan.ManName = Update.ManName;   
                deliveryMan.ManAccount = Update.ManAccount;
                deliveryMan.ManPassword = Update.ManPassword;

                await dbContext.SaveChangesAsync();

                return Ok(deliveryMan);
            }
            return NotFound();
        }
        // delete: xóa dữ liệu
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deliveryMan = await dbContext.DeliveryMan.FindAsync(id);
            if (deliveryMan != null)
            {
                dbContext.Remove(deliveryMan);
                await dbContext.SaveChangesAsync();
                return Ok(deliveryMan);
            }
            return NotFound();
        }
    }
}
