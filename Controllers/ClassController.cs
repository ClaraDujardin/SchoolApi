using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Data;
using SchoolApi.Models;

[ApiController]
[Route("classes")]
public class ClassController : ControllerBase
{
    private readonly AppDbContext _db;

    public ClassController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
     public async Task<ActionResult<List<Class>>> GetClasses() {
         return Ok(await _db.Classes.ToListAsync());
     }

     [HttpPost]
     public async Task<ActionResult<Class>> CreateClass([FromBody] Class classObj) {
         if (classObj == null) {
             return BadRequest("Class object is null.");
         }

         _db.Classes.Add(classObj);
         await _db.SaveChangesAsync();
         return CreatedAtAction(nameof(GetClasses), new { id = classObj.Id }, classObj);


}
}
