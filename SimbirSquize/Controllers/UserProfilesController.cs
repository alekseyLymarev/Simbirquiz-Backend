using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SimbirSquize.Data.Testing;

namespace SimbirSquize.Controllers
{
    [Route("api/v1/profiles")]
    public class UserProfilesController : AbstractController
    {
        private TestingContext _db;

        public UserProfilesController(TestingContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetUserProfile()
        {
            var userId = new Guid("0fed4347-eeb7-4333-b173-bc476876e034");
            var profile = _db.UserProfiles.FirstOrDefault(x => x.UserId.Equals(userId));
            return Ok(WrapToResponse(profile));
        }
        
        [HttpPost("level")]
        public IActionResult AppendLevel()
        {
            var userId = new Guid("0fed4347-eeb7-4333-b173-bc476876e034");
            var profile = _db.UserProfiles.FirstOrDefault(x => x.UserId.Equals(userId));
            profile.Level++;
            _db.UserProfiles.Update(profile);
            _db.SaveChanges();
            return Ok(WrapToResponse(profile));
        }
        
        [HttpPost("coins")]
        public IActionResult SetCoins([FromBody] int coins)
        {
            var userId = new Guid("0fed4347-eeb7-4333-b173-bc476876e034");
            var profile = _db.UserProfiles.FirstOrDefault(x => x.UserId.Equals(userId));
            profile.Coins += coins;
            _db.UserProfiles.Update(profile);
            _db.SaveChanges();
            return Ok(WrapToResponse(profile));
        }
    }
}