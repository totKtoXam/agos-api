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

namespace agos_api.Helpers
{
    public interface IAcademicPlanHelper
    {
        Task<List<AcademicPlan>> UploadAcPlanFromExcelAsync(AcademicPlanViewModel model);
    }
    public class AcademicPlanHelper : IAcademicPlanHelper
    {
        private readonly AppDbContext _dbContext;

        public AcademicPlanHelper(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<AcademicPlan>> UploadAcPlanFromExcelAsync(AcademicPlanViewModel model)
        {
            var academicPlans = new List<AcademicPlan> ();
            
            using (var stream = new MemoryStream())
            {
                await model.acPlanfile.CopyToAsync(stream);

                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row ++)
                    {
                        var classifier = worksheet.Cells[row, 2].Value.ToString().Trim();
                        var allHours = worksheet.Cells[row, 3].Value.ToString().Trim();

                        var discipSpec = await _dbContext.DisciplineSpecials
                                                        .Include(x => x.Discipline)
                                                        .FirstOrDefaultAsync(x => x.Discipline.Classifier == classifier);
                        
                        var academicPlan = new AcademicPlan ()
                        {
                            Semestr = model.Semestr,
                            DisciplineSpecial = discipSpec,
                            AllHours = allHours
                        };

                        academicPlans.Add(academicPlan);
                    }
                }
            }

            return academicPlans;
        }
    }
}