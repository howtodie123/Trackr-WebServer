using TestTestServer.Data;
using Microsoft.AspNetCore.Mvc;
using TestTestServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System;

namespace TestTestServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParcelController : Controller
    {
        private readonly APIData dbContext;

        public ParcelController(APIData dbContext)
        {
            this.dbContext = dbContext;
        }
        // get: lấy dữ liệu
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await dbContext.Parcel.ToListAsync());
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetOne([FromRoute] int id)
        {
            var Parcel = await dbContext.Parcel.FindAsync(id);
            if (Parcel == null) { return NotFound(); }
            return Ok(Parcel);
        }
        // post: tạo  mới
        [HttpPost]
        public async Task<IActionResult> Add(ParcelRequest addd)
        {
            var Parcel = new Parcel()
            {
                // ParID = addd.ParID,
                ParDescription = addd.ParDescription,
                ParStatus = addd.ParStatus,
                ParDeliveryDate = addd.ParDeliveryDate,
                ParLocation = addd.ParLocation,
                Realtime = addd.Realtime,
                Price = addd.Price,
                CusID = addd.CusID,
                ManID = addd.ManID,
            };
            await dbContext.Parcel.AddAsync(Parcel);
            await dbContext.SaveChangesAsync();
            return Ok(Parcel);
        }
        // put: chỉnh sửa dữ liệu
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, ParcelRequest Update)
        {
            var Parcel = await dbContext.Parcel.FindAsync(id);
            if (Parcel != null)
            {
                Parcel.ParDescription = Update.ParDescription;
                Parcel.ParStatus = Update.ParStatus;
                Parcel.ParDeliveryDate = Update.ParDeliveryDate;
                Parcel.ParLocation = Update.ParLocation;
                Parcel.Realtime = Update.Realtime;
                Parcel.Price = Update.Price;
                Parcel.CusID = Update.CusID;
                Parcel.ManID = Update.ManID;

                await dbContext.SaveChangesAsync();

                return Ok(Parcel);
            }
            return NotFound();
        }
        // delete: xóa dữ liệu
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var Parcel = await dbContext.Parcel.FindAsync(id);
            if (Parcel != null)
            {
                dbContext.Remove(Parcel);
                await dbContext.SaveChangesAsync();
                return Ok(Parcel);
            }
            return NotFound();
        }
    }
}
