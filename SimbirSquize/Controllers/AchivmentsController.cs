using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimbirSquize.Data;
using SimbirSquize.Data.Dtos;
using SimbirSquize.Data.Testing;

namespace SimbirSquize.Controllers
{
    [Route("api/v1/achivments")]
    public class AchivmentsController : AbstractController
    {
        private TestingContext _db;

        public AchivmentsController(TestingContext db)
        {
            _db = db;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAchivments([FromQuery] Guid? userId)
        {
            var achivments = _db.Achivments.AsQueryable();
            List<Guid> userAchivmentIds = new List<Guid>();
            if (userId != null)
            {
                userAchivmentIds = await _db.USersAchivments.Where(x => x.UserId.Equals(userId))
                    .Select(x => x.AchivmentId).ToListAsync();
                achivments = achivments.Where(x => userAchivmentIds.Contains(x.Id));
            }

            return Ok(WrapToResponse(achivments));
        }

        [HttpPost()]
        public IActionResult CreateAchivment([FromBody] AchivmentDto achivmentDto)
        {
            var achiv = new Achivment
            {
                Title = achivmentDto.Title,
                Description = achivmentDto.Description
            };
            _db.Achivments.Add(achiv);
            _db.SaveChanges();

            return Ok(WrapToResponse(achiv));
        }

        [HttpPost("activate")]
        public IActionResult CreateAchivment([FromBody] Guid achivemntId)
        {
            var userId = new Guid("0fed4347-eeb7-4333-b173-bc476876e034");
            var userAchiv = new UserAchivment
            {
                AchivmentId = achivemntId,
                UserId = userId
            };
            _db.USersAchivments.Add(userAchiv);
            _db.SaveChanges();

            return Ok(WrapToResponse(userAchiv));
        }
    }
}