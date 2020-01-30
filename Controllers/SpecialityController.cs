using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using agos_api.Models;
using agos_api.Models.Base;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace agos_api.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class SpecialityController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public SpecialityController(AppDbContext context)
        {
            _dbContext = context;
        }

        // Добавление новой записи
        [HttpPost("insert")]
        public async Task<IActionResult> InsertRecordAsync([FromBody] Speciality model)
        {
            // Добление записи
            _dbContext.Specialitys.Add(model);
            // Сохранение базы данных
            await _dbContext.SaveChangesAsync();
            // Выдать код ответа 200 - запись сохранена
            return Ok(model);
        }

        // Получение списка всех записей
        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Speciality>>> GetAllRecordsAsyns()
        {
            // Вернуть список записей
            return await _dbContext.Specialitys.ToListAsync();
        }

        // Получение одной специальности по SpecialityId - идентификатору
        [HttpGet("getsingle/{id}")]
        public async Task<ActionResult<Speciality>> GetSingleRecordAsync(int id)
        {
            Speciality speciality = await _dbContext.Specialitys.FirstOrDefaultAsync(x => x.SpecialityId == id);
            // Если запись не найдена, то выдать код ошибки - 404
            if (speciality == null)
                return NotFound("Запись не найдена.");
            // Вернуть специальность
            return new ObjectResult(speciality);
        }
 
        // Редактирование записи
        [HttpPut("update")]
        public async Task<ActionResult<Speciality>> UpdateRecordAsync([FromBody] Speciality model)
        {
            // Если модель пуста == null, то выдать код ошибки - 400
            if (model == null)
            {
                return BadRequest("Данные введены не коректно.");
            }

            // Если запись не найдена, то выдать код ошибки - 404
            if (!_dbContext.Specialitys.Any(x => x.SpecialityId == model.SpecialityId))
            {
                return NotFound("Запись, которую Вы хотите изменить не найдена");
            }

            // Изменение даннхы
            _dbContext.Update(model);
            // Сохранение базы данных
            await _dbContext.SaveChangesAsync();
            // Вернуть код ответ 200 - запись изменена и модель
            return Ok(model);
        }
 
        // Удаление записи
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Speciality>> DeleteRecordAsync(int id)
        {
            Speciality speciality = _dbContext.Specialitys.FirstOrDefault(x => x.SpecialityId == id);
             // Если запись не найдена, то выдать код ошибки - 404
            if (speciality == null)
            {
                return NotFound("Запись, которую Вы хотите удалить не найдена.");
            }
            // Удаление записи
            _dbContext.Specialitys.Remove(speciality);
            // Сохарнение базы данных
            await _dbContext.SaveChangesAsync();
            // Вернуть код ответ 200 - запись удалена и удаленную специальность
            return Ok(speciality);
        }
    }
}