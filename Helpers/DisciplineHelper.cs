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
            int savedCound = 0;
            foreach (var item in model)
            {
                if (!string.IsNullOrEmpty(item.Classifier) && !string.IsNullOrEmpty(item.Name))
                {
                    var typeLesson = await _dbContext.TypeLessons.FirstOrDefaultAsync(x => x.TypeLessonId == item.TypeLesson.TypeLessonId);
                    if (typeLesson != null)
                    {
                        var discipline = new Discipline();
                        discipline.Name = item.Name;
                        discipline.Classifier = item.Classifier;
                        discipline.TypeLesson = typeLesson;
                        if (item.ClassificationIdList.Count() > 0)
                        {
                            foreach(var classificationId in item.ClassificationIdList)
                            {
                                var classification = await _dbContext.Classifications.FirstOrDefaultAsync(x => x.ClassificationId == classificationId);
                                if (classification != null)
                                {

                                    var discipClassific = new DisciplineClassific();
                                    discipClassific.Classification = classification;
                                    discipClassific.Discipline = discipline;

                                    await _dbContext.DisciplineClassifics.AddAsync(discipClassific);
                                    savedCound ++;
                                }
                            }
                        }
                        else
                        {
                            await _dbContext.Disciplines.AddAsync(discipline);
                        }
                    }
                }
            }

            if (savedCound > 0)
            {
                await _dbContext.SaveChangesAsync();
                return model;
            }
            else
                return null;
        }
    }
}