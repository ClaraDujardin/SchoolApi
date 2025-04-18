// using Microsoft.AspNetCore.Mvc;
// using SchoolApi.Data;

// [ApiController]
// [Route("hello")]
// public class HelloController : ControllerBase
// {
//     private readonly AppDbContext _db;

//     public HelloController(AppDbContext db)
//     {
//         _db = db;
//     }

//     [HttpGet]
//     public async Task<ActionResult<string>> GetHello()
//     {
//         return Ok("Hello.");
//     }
// }