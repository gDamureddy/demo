using System;
using LoginSign.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using LoginSign.Models;
using System.Linq;


namespace LoginSign.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class Logcon:ControllerBase
	{
        private readonly Adddbcontext _logcontext;
        public Logcon(Adddbcontext adddbcontext)
		{
            _logcontext = adddbcontext;
        }

        //[HttpPost("authenticate")]
        //public async Task<IActionResult> Authenticate([FromBody]Datatype datatype)
        //{
        //    if (datatype == null)
        //        return BadRequest();

        //    var data = await _logcontext.LoginSigntable.FirstOrDefaultAsync(x => x.username = datatype.username && x.password=datatype.password);
        //    if (data == null)
        //        return NotFound(new { Message = "username is not found!" });
        //    return Ok(new
        //    {
        //        Message = "Login success!"
        //    });

        //}


    // Somewhere in your code before saving to the database


    [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] Datatype datatype)
        {

            if (datatype == null)
                return BadRequest();

            var data = await _logcontext.users.FirstOrDefaultAsync(x => x.username == datatype.username && x.password == datatype.password);
            if (data == null)
                return NotFound(new { Message = "Invalid username or password!" });

            return Ok(new
            {
                Message = "Login success!"
            });
        }

        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody] Datatype datatype)
        {
            if (datatype == null)
                return BadRequest();
            await _logcontext.users.AddAsync(datatype);
            await _logcontext.SaveChangesAsync();

            return Ok(new
            {
                Message = "Registered successfully!"
            });
        }

    }
}
