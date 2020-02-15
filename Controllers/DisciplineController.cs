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
    [Route("api/[controller]/")]
    public class DisciplineController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IDisciplineHelper _disciplineHelper;
        public DisciplineController(AppDbContext context, IDisciplineHelper disciplineHelper)
        {
            _dbContext = context;
            _disciplineHelper = disciplineHelper;
        }

        // Добавление новой записи
        [HttpPost("insert")]
        public async Task<IActionResult> InsertRecordAsync([FromBody] List<DisciplineSpecialityViewModel> model)
        {
            if(model == null)
                return BadRequest();

            var resultModel = await _disciplineHelper.AddDisciplineWithDiscSpecAsync(model);

            // Выдать код ответа 200 - запись сохранена
            return Ok(resultModel);
        }

        // Получение списка всех записей
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Speciality>>> GetAllRecordsAsyns()
        {
            // Вернуть список записей
            return await _dbContext.Specialities.ToListAsync();
        }

        // Получение одной специальности по SpecialityId - идентификатору
        [HttpGet("{id}")]
        public async Task<ActionResult<Speciality>> GetSingleRecordAsync(int id)
        {
            Discipline discipline = await _dbContext.Disciplines.FirstOrDefaultAsync(x => x.DisciplineId == id);
            // Если запись не найдена, то выдать код ошибки - 404
            if (discipline == null)
                return NotFound("Запись не найдена.");
            // Вернуть специальность
            return new ObjectResult(discipline);
        }
 
        // Редактирование записи
        [HttpPut("update")]
        public async Task<ActionResult<Speciality>> UpdateRecordAsync([FromBody] Discipline model)
        {
            // Если модель пуста == null, то выдать код ошибки - 400
            if (model == null)
                return BadRequest("Данные введены не коректно.");

            // Если запись не найдена, то выдать код ошибки - 404
            if (!_dbContext.Disciplines.Any(x => x.DisciplineId == model.DisciplineId))
                return NotFound("Запись, которую Вы хотите изменить не найдена");

            // Изменение даннхы
            _dbContext.Update(model);
            
            // Сохранение базы данных
            await _dbContext.SaveChangesAsync();
            
            // Вернуть код ответ 200 - запись изменена и модель
            return Ok(model);
        }
 
        // Удаление записи
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Discipline>> DeleteRecordAsync(int id)
        {
            Discipline discipline = _dbContext.Disciplines.FirstOrDefault(x => x.DisciplineId == id);
             // Если запись не найдена, то выдать код ошибки - 404
            if (discipline == null)
            {
                return NotFound("Запись, которую Вы хотите удалить не найдена.");
            }
            // Удаление записи
            _dbContext.Disciplines.Remove(discipline);

            // Сохарнение базы данных
            await _dbContext.SaveChangesAsync();
            
            // Вернуть код ответ 200 - запись удалена и удаленную специальность
            return Ok(discipline);
        }
    }
}