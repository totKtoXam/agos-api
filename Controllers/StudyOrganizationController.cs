using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using agos_api.Models;
using agos_api.Models.Base;
using System.Threading.Tasks;
using agos_api.Helpers;

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
 
        [HttpPost("insert")]
        public async Task<IActionResult> InsertRecordAsyns([FromBody] StudyOrganization model)
        {
            var studyOrganization = new StudyOrganization(model);
            db.StudyOrganizations.Add(studyOrganization);
            await db.SaveChangesAsync();
            StudyOrganization _studyOrganization = db.StudyOrganizations.OrderByDescending(x => x.StudyOrganizationId).FirstOrDefault();
            _studyOrganization.Key = StudyOrganizationHelper.KeyGenerate(
                    _studyOrganization.StudyOrganizationId, 
                    _studyOrganization.ShortName, 
                    _studyOrganization.City
                );
            db.Update(_studyOrganization);
            await db.SaveChangesAsync();
            return Ok(studyOrganization);
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