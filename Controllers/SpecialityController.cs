using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using agos_api.Models;
using agos_api.Models.Base;
using System.Threading.Tasks;
 
namespace agos_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpecialityController : ControllerBase
    {
        AppDbContext db;
        public SpecialityController(AppDbContext context)
        {
            db = context;
            if (!db.Specialitys.Any())
            {
                db.Specialitys.Add(new Speciality { Speciality_Name = "Программирование", Speciality_Classifier = "12548" });
                db.Specialitys.Add(new Speciality { Speciality_Name = "Операционные системы и пакет прикладных программ", 
                    Speciality_Classifier = "16448" });
                db.SaveChanges();
            }
        }
 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Speciality>>> Get()
        {
            return await db.Specialitys.ToListAsync();
        }
 
        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Speciality>> Get(int id)
        {
            Speciality speciality = await db.Specialitys.FirstOrDefaultAsync(x => x.SpecialityId == id);
            if (speciality == null)
                return NotFound();
            return new ObjectResult(speciality);
        }
 
        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Speciality>> Post(Speciality speciality)
        {
            if (speciality == null)
            {
                return BadRequest();
            }
 
            db.Specialitys.Add(speciality);
            await db.SaveChangesAsync();
            return Ok(speciality);
        }
 
        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Speciality>> Put(Speciality speciality)
        {
            if (speciality == null)
            {
                return BadRequest();
            }
            if (!db.Specialitys.Any(x => x.SpecialityId ==speciality.SpecialityId))
            {
                return NotFound();
            }
 
            db.Update(speciality);
            await db.SaveChangesAsync();
            return Ok(speciality);
        }
 
        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Speciality>> Delete(int id)
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