using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using agos_api.Models;
using agos_api.Models.Base;
using System.Threading.Tasks;
using agos_api.Models.Studying;
using Microsoft.AspNetCore.Authorization;
using agos_api.Helpers;

namespace agos_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassificationController : ControllerBase
    {
        readonly private AppDbContext _dbContext;
        readonly private IOperationHelper _operationHelper;
        public ClassificationController (AppDbContext dbContext,
                                        IOperationHelper operationHelper)
        {
            _dbContext = dbContext;
            _operationHelper = operationHelper;
        }


        /// <summary>
        /// Добавление записи Classifications
        /// </summary>
        /// <param name="classificationList"></param>
        /// <returns></returns>
        /// <response code="200">Возвращение списка добавленных и недобавленных записей</response>
        [HttpPost("insert")]
        public async Task<IActionResult> InsertRecordAsync([FromBody] List<Classification> classificationList)
        {
            if(classificationList == null)
                return BadRequest();

            List<Classification> addedList = new List<Classification>();
            List<Classification> notAddedList = new List<Classification>();

            foreach(var classification in classificationList)
            {
                if (!_dbContext.Classifications.Any(x => x.ClassificationClassifier == classification.ClassificationClassifier))
                {
                    
                    var classifierCheckResult = await _operationHelper.CheckClassifierOrSpecialityAsync(classification);
                    if (classifierCheckResult)
                    {
                        // Добавление записи
                        // _dbContext.Classifications.Add(classification);
                        classification.Speciality = await _dbContext.Specialities.FirstOrDefaultAsync(x => x.SpecialityId == classification.Speciality.SpecialityId);
                        _dbContext.Classifications.Add(classification);
                        addedList.Add(classification);
                    }
                    else
                        notAddedList.Add(classification);
                }
                else
                    notAddedList.Add(classification);
            }
            
            if (addedList != null)
            {
                // Сохранение базы данных
                await _dbContext.SaveChangesAsync();
            }

            // Выдать код ответа 200 - запись сохранена
            return Ok(new {
                addedList,
                notAddedList
            });
        }

        // Получение списка всех записей
        [HttpGet]
        public async Task<ActionResult> GetAllRecordsAsyns()
        {
            var classifications = await _dbContext.Classifications
                                                        .Include(x => x.Speciality)
                                                        .ToListAsync();
            // Вернуть список записей
            return Ok(classifications);
        }

        // Получение одной специальности по SpecialityId - идентификатору
        [HttpGet("{id}")]
        public async Task<ActionResult> GetSingleRecordAsync(int id)
        {
            var classification = await _dbContext.Classifications
                                                        .Include(x => x.Speciality)
                                                        .Where(x => x.ClassificationId == id)
                                                        .ToListAsync();


            // Если запись не найдена, то выдать код ошибки - 404
            if (classification == null)
                return NotFound("Запись не найдена.");

            // Вернуть специальность
            return Ok(classification);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteSingleRecordAsync(int id)
        {
            var classification = await _dbContext.Classifications.FirstOrDefaultAsync(x => x.ClassificationId == id);

            if (classification == null)
                return NotFound();

            _dbContext.Classifications.Remove(classification);

            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}