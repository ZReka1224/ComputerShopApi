using ComputerShopApi.Models;
using ComputerShopApi.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShopApi.Controllers
{
    [Route("osystems")]
    [ApiController]
    public class OsystemController : ControllerBase
    {
        public ComputerShopDbContext _context = new();
        [HttpPost("addOsystem")]
        public object AddNewOsystem([FromBody]AddNewOsystemDto addNewOsystemDto)
        {
            var osystem = new Osystem
            {
                Id = Guid.NewGuid(),
                Name = addNewOsystemDto.Name,
                Version = addNewOsystemDto.Version,
                Registration = DateTime.Now,
                UpDateTime = DateTime.Now,
            };
            if(osystem != null)
            {
                _context.Osystems.Add(osystem);
                _context.SaveChanges();

                return StatusCode(201, new {message = "Sikeres felvétel", result =osystem});
            }
            return StatusCode(400, new { message = "Sikeres felvétel", result = osystem });
        }

        [HttpGet("allOsystem")]
        public object GetAllOsystem()
        {
            var osystem = _context.Osystems.ToList();
            Exception e = new();

            if(osystem.Count > 0)
            {
                return StatusCode(200, new { message = "Sikeres lekérdezés", result = osystem });
            }
            else if (osystem.Count < 0)
            {
                return StatusCode(200, new { message = "üves tabla", result = osystem });
            }
            else
            {
                return StatusCode(400, new { message = "Hiba a lekérdezésbe", result = e.Message });
            }
        }

        [HttpPut("updateOsystem")]
        public object UpdateOsystem([FromQuery]Guid id,[FromBody]UpdateOsystemDto updateOsystemDto)
        {
            var osystems = _context.Osystems.FirstOrDefault(os => os.Id == id);

            if(osystems != null)
            {
                osystems.Name = updateOsystemDto.Name;
                osystems.Version = updateOsystemDto.Version;
                osystems.UpDateTime = DateTime.Now;

                return StatusCode(200, new { message = "üves tabla", result = osystems });
            }
           
            else
            {
                return StatusCode(400, new { message = "Hiba a lekérdezésbe", result = osystems });
            }

        }

        [HttpDelete]
        public object DeleteOsystem([FromQuery] Guid id)
        {
            var osystems = _context.Computers.FirstOrDefault(os => os.Id == id);

            if (osystems != null)
            {
                _context.Computers.Remove(osystems);
                _context.SaveChanges();


                return StatusCode(200, new { message = "Sikeres törlés ", result = osystems });
            }

            else if (osystems == null)
            {
                return StatusCode(404, new { message = "Nincs ilyen Id", result = osystems });
            }
            else
            {
                return StatusCode(400, new { message = "Hiba a frissítésben", result = osystems });
            }

        }


    }
}



