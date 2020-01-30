using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using agos_api.Models;
using agos_api.Helpers;
using agos_api.Models.Base;
using System.Threading.Tasks;
using agos_api.Models.Schedule;
using agos_api.Models.Organizations;

namespace agos_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudyOrganizationController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public StudyOrganizationController(AppDbContext context)
        {
            _dbContext = context;
        }
 
        [HttpPost("insert")]
        public async Task<IActionResult> InsertRecordAsyns([FromBody] StudyOrganization model)
        {
            var studyOrganization = new StudyOrganization(model);
            _dbContext.StudyOrganizations.Add(studyOrganization);
            await _dbContext.SaveChangesAsync();
            studyOrganization.Key = StudyOrganizationHelper.KeyGenerate(
                    studyOrganization.StudyOrganizationId, 
                    studyOrganization.ShortName, 
                    studyOrganization.City
                );
            _dbContext.Update(studyOrganization);
            await _dbContext.SaveChangesAsync();
            return Ok(studyOrganization);
        }

        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<StudyOrganization>>> GetAllRecordsAsyns()
        {
            return await _dbContext.StudyOrganizations.ToListAsync();
        }
 
        // GET api/users/5
        [HttpGet("getsingle/{id}")]
        public async Task<ActionResult<Speciality>> GetSingleRecordAsyns(int id)
        {
            StudyOrganization studyOrganization = await _dbContext.StudyOrganizations.FirstOrDefaultAsync(x => x.StudyOrganizationId == id);
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
            if (!_dbContext.StudyOrganizations.Any(x => x.StudyOrganizationId == model.StudyOrganizationId))
            {
                return NotFound();
            }
 
            _dbContext.Update(model);
            await _dbContext.SaveChangesAsync();
            return Ok(model);
        }
 
        // DELETE api/users/5
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Speciality>> DeleteRecordAsyns(int id)
        {
            StudyOrganization studyOrganization = _dbContext.StudyOrganizations.FirstOrDefault(x => x.StudyOrganizationId == id);
            if (studyOrganization == null)
            {
                return NotFound();
            }
            _dbContext.StudyOrganizations.Remove(studyOrganization);
            await _dbContext.SaveChangesAsync();
            return Ok(studyOrganization);
        }
    }
}