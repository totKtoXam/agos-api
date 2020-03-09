using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using agos_api.Models;
using agos_api.Helpers;
using agos_api.Models.Base;
using System.Threading.Tasks;
using agos_api.Models.Schedule;
using agos_api.Models.Studying;
using agos_api.Models.Organizations;
using agos_api.Models.Organizations.PersonOrg;
using Microsoft.AspNetCore.Authorization;

namespace agos_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public TeacherController (AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("insert")]
        public async Task<IActionResult> InsertRecordAsync([FromBody] List<Teacher> teachers)
        {
            if (teachers == null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                List<Teacher> addedList = new List<Teacher>();
                List<Teacher> notAddedList = new List<Teacher>();
                foreach (var teacher in teachers)
                {
                    var foundTeacher = await _dbContext.Teachers
                                                        .FirstOrDefaultAsync(x =>
                                                                                x.LastName  == teacher.LastName &&
                                                                                x.FirstName == teacher.FirstName
                                                                            );
                    if (foundTeacher == null)
                    {
                        teacher.StudyOrganization = await _dbContext.StudyOrganizations.FindAsync(teacher.StudyOrganization.StudyOrganizationId);
                        await _dbContext.Teachers.AddAsync(teacher);
                        addedList.Add(teacher);
                    }
                    else
                    {
                        notAddedList.Add(teacher);
                    }
                }
                if (addedList != null)
                {
                    await _dbContext.SaveChangesAsync();
                }
                return Ok(new {
                    addedList,
                    notAddedList
                });
            }
            else
            {
                return BadRequest(teachers);
            }
        }

        [HttpGet("studyorg/{studyOrgId}")]
        public async Task<IActionResult> GetAllRecordsByStudyOrgAsync(int studyOrgId)
        {
            var records = await _dbContext.Teachers
                                            .Include(x => x.StudyOrganization)
                                            .Where(x => x.StudyOrganization.StudyOrganizationId == studyOrgId)
                                            .ToListAsync();
            if (records == null)
                return NotFound();

            return Ok(records);
        }

        [Authorize(Roles="devAdmin")]
        [HttpGet("studyorg/dev")]
        public async Task<IActionResult> GetAllRecordsByStudyOrgForDevAsync ()
        {
            var teachers = await _dbContext.Teachers
                                            .Include(x => x.StudyOrganization)
                                            .ToListAsync();
            return Ok(teachers);
        }

        [HttpGet("{teacherId}")]
        public async Task<IActionResult> GetSingleRecordAsync(int teacherId)
        {
            var teacher = await _dbContext.Teachers
                                            .Include(x => x.StudyOrganization)
                                            .FirstOrDefaultAsync(x => x.TeacherId == teacherId);
            if (teacher == null)
                return NotFound();
            
            return Ok(teacher);
        }
    }
}