using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using agos_api.Models;
using agos_api.Models.Base;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace agos_api.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class SpecialityController : ControllerBase
    {
        AppDbContext db;
        public SpecialityController(AppDbContext context)
        {
            db = context;
        }

        [HttpPost("insert")]
        public async Task<IActionResult> InsertRecordAsync([FromBody] Speciality model)
        {
            db.Specialitys.Add(model);
            await db.SaveChangesAsync();
            return Ok(model);
        }

        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Speciality>>> GetAllRecordsAsyns()
        {
            return await db.Specialitys.ToListAsync();
        }
 
        // GET api/users/5
        [HttpGet("getsingle/{id}")]
        public async Task<ActionResult<Speciality>> GetSingleRecordAsync(int id)
        {
            Speciality speciality = await db.Specialitys.FirstOrDefaultAsync(x => x.SpecialityId == id);
            if (speciality == null)
                return NotFound();
            return new ObjectResult(speciality);
        }
 
        // PUT api/users/
        [HttpPut("update")]
        public async Task<ActionResult<Speciality>> UpdateRecordAsync([FromBody] Speciality model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            if (!db.Specialitys.Any(x => x.SpecialityId == model.SpecialityId))
            {
                return NotFound();
            }
 
            db.Update(model);
            await db.SaveChangesAsync();
            return Ok(model);
        }
 
        // DELETE api/users/5
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Speciality>> DeleteRecordAsync(int id)
        {
            Speciality speciality = db.Specialitys.FirstOrDefault(x => x.SpecialityId == id);
            if (speciality == null)
            {
                return NotFound();
            }
            db.Specialitys.Remove(speciality);
            await db.SaveChangesAsync();
            return Ok(speciality);
        }
    }
}