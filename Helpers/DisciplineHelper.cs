using System.Collections.Generic;
using agos_api.Models.Studying;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using agos_api.Models;
using agos_api.Models.Base;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace agos_api.Helpers
{
    public interface IDisciplineHelper
    {
        Task<List<DisciplineSpecialityViewModel>> AddDisciplineWithDiscSpecAsync(List<DisciplineSpecialityViewModel> model);
    }
    public class DisciplineHelper : IDisciplineHelper
    {
        private readonly AppDbContext _dbContext;
        public DisciplineHelper(AppDbContext context)
        {
            _dbContext = context;
        }

        public async Task<List<DisciplineSpecialityViewModel>> AddDisciplineWithDiscSpecAsync(List<DisciplineSpecialityViewModel> model)
        {
            foreach(var discipline in model)
            {
                if (discipline != null)
                {
                    await _dbContext.Disciplines.AddAsync(new Discipline{
                        Name = discipline.Name,
                        TypeLesson = discipline.TypeLesson,
                        Classifier = discipline.Classifier
                    });
                }
            }
            
            // Сохранение базы данных
            await _dbContext.SaveChangesAsync();

            foreach(var disciplineSpec in model)
            {
                if (disciplineSpec.SpecialityIdList != null)
                {
                    foreach(var specId in disciplineSpec.SpecialityIdList)
                    {
                        var speciality = await _dbContext.Specialitys.FirstOrDefaultAsync(x => x.SpecialityId == specId);
                        if (speciality != null)
                        {
                            var discipline = await _dbContext.Disciplines.FirstOrDefaultAsync(x => x.Classifier == disciplineSpec.Classifier);
                            await _dbContext.DisciplineSpecials.AddAsync(new DisciplineSpecial{
                                Discipline = discipline,
                                Speciality = speciality
                            });
                        }
                    }
                }
            }

            await _dbContext.SaveChangesAsync();
            return model;
        }
    }
}