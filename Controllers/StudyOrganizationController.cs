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
    public class StudyOrganizationController : ControllerBase
    {
        AppDbContext db;
        public StudyOrganizationController(AppDbContext context)
        {
            db = context;
        }

        public string KeyGenerate(int StudyOrganizationId, string ShortName, string City)
        {
            return (StudyOrganizationId).ToString() + "-" + ShortName + "-" + City;
        }
 
        [HttpPost("insert")]
        public async Task<IActionResult> InsertRecordAsyns([FromBody] StudyOrganization model)
        {
            db.StudyOrganizations.Add(model);
            await db.SaveChangesAsync();
            StudyOrganization studyOrganization = db.StudyOrganizations.OrderByDescending(x => x.StudyOrganizationId).FirstOrDefault();
            model.Key = KeyGenerate(
                    studyOrganization.StudyOrganizationId, 
                    studyOrganization.ShortName, 
                    studyOrganization.City
                );

            db.Update(model);
            await db.SaveChangesAsync();
            return Ok(model);

        }

        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<StudyOrganization>>> GetAllRecordsAsyns()
        {
            return await db.StudyOrganizations.ToListAsync();
        }
 
        // GET api/users/5
        [HttpGet("getsingle/{id}")]
        public async Task<ActionResult<Speciality>> GetSingleRecordAsyns(int id)
        {
            StudyOrganization studyOrganization = await db.StudyOrganizations.FirstOrDefaultAsync(x => x.StudyOrganizationId == id);
            if (studyOrganization == null)
                return NotFound();
            return new ObjectResult(studyOrganization);
        }
 
        // PUT api/users/
        [HttpPut("update")]
        public async Task<ActionResult<Speciality>> UpdateRecordAsyns([FromBody] StudyOrganization model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            if (!db.StudyOrganizations.Any(x => x.StudyOrganizationId == model.StudyOrganizationId))
            {
                return NotFound();
            }
 
            db.Update(model);
            await db.SaveChangesAsync();
            return Ok(model);
        }
 
        // DELETE api/users/5
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Speciality>> DeleteRecordAsyns(int id)
        {
            StudyOrganization studyOrganization = db.StudyOrganizations.FirstOrDefault(x => x.StudyOrganizationId == id);
            if (studyOrganization == null)
            {
                return NotFound();
            }
            db.StudyOrganizations.Remove(studyOrganization);
            await db.SaveChangesAsync();
            return Ok(studyOrganization);
        }
    }
}