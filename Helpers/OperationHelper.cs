using System.Collections.Generic;
using System.Threading.Tasks;
using agos_api.Models.Base;
using agos_api.Models.Studying;

namespace agos_api.Helpers
{
    public interface IOperationHelper
    {
        Task<bool> CheckClassifierOrSpecialityAsync(Classification slassification);
    }
    public class OperationHelper : IOperationHelper
    {
        readonly private AppDbContext _dbContext;
        public OperationHelper (AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> CheckClassifierOrSpecialityAsync(Classification classification)
        {
            var foundSpeciality = await _dbContext.Specialities.FindAsync(classification.Speciality.SpecialityId);
            var specClassf = foundSpeciality.SpecialityClassifier.Substring(0, 4);
            var classClassf = classification.ClassificationClassifier.Substring(0, 4);

            if (specClassf == classClassf)
                return true;
            else
                return false;
        }
    }
}