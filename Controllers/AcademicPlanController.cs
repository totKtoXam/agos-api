using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using agos_api.Models;
using agos_api.Models.Base;
using agos_api.Models.Schedule;
using System.Threading.Tasks;
using agos_api.Models.Studying;
using Microsoft.AspNetCore.Authorization;
using agos_api.Helpers;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;
using System.Threading;
using OfficeOpenXml;

namespace agos_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcademicPlanController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IAcademicPlanHelper _acPlanHelper;

        public AcademicPlanController(AppDbContext dbContext, IAcademicPlanHelper acPlanHelper)
        {
            _dbContext = dbContext;
            _acPlanHelper = acPlanHelper;
        }

        [HttpPost]
        [Route("uploadFileAcplan")]
        [AllowAnonymous]
        public async Task<IActionResult> UploadAcPlanFile(AcademicPlanViewModel model)
        {
            if (model.acPlanfile == null || model.acPlanfile.Length <= 0)  
            {  
                return BadRequest();  
            }  
        
            if (!Path.GetExtension(model.acPlanfile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))  
            {  
                return BadRequest();  
            }


            var academicPlans = await _acPlanHelper.UploadAcPlanFromExcelAsync(model);
            

            if (academicPlans == null)
                return BadRequest();

            foreach(var academicPlan in academicPlans)
            {
                await _dbContext.AcademicPlans.AddAsync(academicPlan);
            }

            await _dbContext.SaveChangesAsync();

            return Ok(academicPlans);
        }
    }
}