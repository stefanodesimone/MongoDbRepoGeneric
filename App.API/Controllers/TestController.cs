using App.API.Classes;
using Microsoft.AspNetCore.Mvc;
using MongoDbRepoGeneric.Interfaces;
using System;

namespace App.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
       

        private readonly ILogger<TestController> _logger;
        private readonly IMongoDbGenericRepository<User> _userRepo;


        public TestController(ILogger<TestController> logger, IMongoDbGenericRepository<User> userRepo)
        {
            _logger = logger;
            _userRepo = userRepo;
        }
        [HttpPost]
        public void Post([FromBody] User value)
        {
            _userRepo.InsertDocument(value);
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userRepo.GetAll();
        }

    }
}
