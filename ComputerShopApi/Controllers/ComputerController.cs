using ComputerShopApi.Models;
using ComputerShopApi.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShopApi.Controllers
{
    [Microsoft.AspNetCore.Components.Route("computers")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        public ComputerShopDbContext _context = new();

        [HttpPost("addComputer")]
        public object AddNewComputer([FromBody] AddNewComputersDto addNewComputersDto)
        {
            var computer = new Computer
            {
                Id = Guid.NewGuid(),
                Brand = addNewComputersDto.Brand,
                Type= addNewComputersDto.Type,
                Display = addNewComputersDto.Display,
                Memory = addNewComputersDto.Memory,
                CreatedTime = DateTime.Now,
                OsId= addNewComputersDto.OsId,
            };
            if (computer != null)
            {
                _context.Computers.Add(computer);
                _context.SaveChanges();

                return StatusCode(201, new { message = "Sikeres felvétel", result = computer });
            }
            return StatusCode(400, new { message = "Sikertelen felvétel", result = computer });
        }

        [HttpGet("allComputers")]
        public object GetAllComputers()
        {
            var computer = _context.Computers.ToList();
            Exception e = new();

            if (computer.Count > 0)
            {
                return StatusCode(200, new { message = "Sikeres lekérdezés", result = computer });
            }
            else if (computer.Count < 0)
            {
                return StatusCode(200, new { message = "üves tabla", result = computer });
            }
            else
            {
                return StatusCode(400, new { message = "Hiba a lekérdezésbe", result = e.Message });
            }
        }

        [HttpPut("updateComputer")]
        public object UpdateComputer([FromQuery] Guid id, [FromBody] updateComputersDto updateComputersDto)
        {
            var computers = _context.Computers.FirstOrDefault(os => os.Id == id);
            Exception e = new();

            if (computers != null)
            {
                computers.Brand = updateComputersDto.Brand;
                computers.Type = updateComputersDto.Type;
                computers.Display = updateComputersDto.Display;
                computers.Memory = updateComputersDto.Memory;
                computers.OsId = updateComputersDto.OsId;
                
              

                return StatusCode(200, new { message = "üves tabla", result = computers });
            }
            else if (computers == null)
            {
                return StatusCode(404, new { message = "Nincs ilyen id", result = computers });
            }

            else
            {
                return StatusCode(400, new { message = "Hiba a lekérdezésbe", result = e.Message });
            }
           

        }

        [HttpDelete("delete")]
        public object DeleteComputers([FromQuery] Guid id)
        {
            var computer = _context.Computers.FirstOrDefault(computer => computer.Id == id);

            if (computer != null)
            {
                _context.Computers.Remove(computer);
                _context.SaveChanges();


                return StatusCode(200, new { message = "Sikeres törlés ", result = computer });
            }

            else if (computer == null)
            {
                return StatusCode(404, new { message = "Nincs ilyen Id", result = computer });
            }
            else
            {
                return StatusCode(400, new { message = "Hiba a frissítésben", result = computer });
            }

        }


    }

}

