using CsvHelper.Configuration;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserUpload.Data;
using UserUpload.Entities;
using System.Globalization;
using UserUpload.DTO;
using UserUpload.UserMap;
using Microsoft.EntityFrameworkCore;

namespace UserUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext _uctx;
        private readonly ILogger<UserController> _logger;

        public UserController(UserDbContext uctx, ILogger<UserController> logger)
        {
            _logger = logger;
            _uctx = uctx;   
        }

        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] FileImport import)
        {
            List<UserDTO> userDTOs = new List<UserDTO>(); // changed
            using (TextReader reader = new StreamReader(import.ImportFile.OpenReadStream()))
            using (var file = new CsvReader(reader, new CultureInfo("en-US")))
            {
                userDTOs = file.GetRecords<UserDTO>().ToList();
            }
            var users = userDTOs.Select(r => r.ToEntity()).ToList();
            _uctx.Users.AddRange();
            await _uctx.SaveChangesAsync();
            _logger.LogInformation($"You have added {userDTOs.Count} datas.");
            return Ok();
        }

        [HttpGet]
        public  IActionResult Export()
        {
            var user = new UsersUploads();
            user.User = _uctx.Users.Include(p => p.Pets).Select(p => p.ToExport()).ToList();
            System.Xml.Serialization.XmlSerializer writer = 
                new System.Xml.Serialization.XmlSerializer(typeof(UsersUploads));
            System.IO.MemoryStream xml = new MemoryStream();
            writer.Serialize(xml, user); byte[] b = xml.ToArray();
            return File(b, "application/xml");
        }
        

        
    }
}
