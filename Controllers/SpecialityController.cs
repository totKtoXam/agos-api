using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using agos_api.Models;
using agos_api.Models.Base;
using System.Threading.Tasks;
using agos_api.Models.Studying;
using Microsoft.AspNetCore.Authorization;
using System;

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
        public async Task<IActionResult> InsertRecordAsync([FromBody] List<Speciality> specialityList)
        {
            if(specialityList == null)
                return BadRequest();

            List<Speciality> notAddedList = new List<Speciality>();
            List<Speciality> addedList = new List<Speciality>();

            foreach(var speciality in specialityList)
            {
                // if (speciality.GetType() == typeof(Speciality))
                // {
                //     Console.WriteLine("THIS IS SPECIALITY!");
                // }
                
                if (ModelState.IsValid)
                {
                    if (!_dbContext.Specialities.Any(x => x.SpecialityClassifier == speciality.SpecialityClassifier))
                    {
                        // Добление записи
                        _dbContext.Specialities.Add(speciality);
                        addedList.Add(speciality);
                    }
                    else
                        notAddedList.Add(speciality);
                }
                else
                    notAddedList.Add(speciality);
            }
            
            // Сохранение базы данных
            await _dbContext.SaveChangesAsync();

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
            var specialitys = await _dbContext.Specialities.ToListAsync();
            // Вернуть список записей
            return Ok(specialitys);
        }

        // Получение одной специальности по SpecialityId - идентификатору
        [HttpGet("{id}")]
        public async Task<ActionResult> GetSingleRecordAsync(int id)
        {
            Speciality speciality = await _dbContext.Specialities.FirstOrDefaultAsync(x => x.SpecialityId == id);
            // Если запись не найдена, то выдать код ошибки - 404
            if (speciality == null)
                return NotFound("Запись не найдена.");
            // Вернуть специальность
            return Ok(speciality);
        }
 
        // Редактирование записи
        [HttpPut("update")]
        public async Task<ActionResult<Speciality>> UpdateRecordAsync([FromBody] List<Speciality> specialityList)
        {
            if(specialityList == null)
                return BadRequest();

            List<Speciality> notUpdatedList = new List<Speciality>();
            List<Speciality> updatedList = new List<Speciality>();

            foreach(var speciality in specialityList)
            {
                // if (speciality.GetType() == typeof(Speciality))
                // {
                //     Console.WriteLine("THIS IS SPECIALITY!");
                // }
                
                if (ModelState.IsValid)
                {
                    if (_dbContext.Specialities.Any(x => x.SpecialityId == speciality.SpecialityId))
                    {
                        // Изменение данных записи
                        _dbContext.Update(speciality);
                        updatedList.Add(speciality);
                    }
                    else
                        notUpdatedList.Add(speciality);
                }
                else
                    notUpdatedList.Add(speciality);
            }
            
            // Сохранение базы данных
            await _dbContext.SaveChangesAsync();

            // Выдать код ответа 200 - запись сохранена
            return Ok(new {
                updatedList,
                notUpdatedList
            });
        }
 
        // Удаление записи
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteRecordAsync(int id)
        {
            Speciality speciality = _dbContext.Specialities.FirstOrDefault(x => x.SpecialityId == id);
             // Если запись не найдена, то выдать код ошибки - 404
            if (speciality == null)
            {
                return NotFound("Запись, которую Вы хотите удалить не найдена.");
            }
            // Удаление записи
            _dbContext.Specialities.Remove(speciality);
            // Сохарнение базы данных
            await _dbContext.SaveChangesAsync();
            // Вернуть код ответ 200 - запись удалена и удаленную специальность
            return Ok(speciality);
        }
    }
}