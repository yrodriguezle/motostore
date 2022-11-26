using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.EntityFrameworkCore;

using Motostore.DataAccess;
using Motostore.Models;
using Motostore.Repositories;

namespace Motostore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _configuration;
        private readonly DataContext _dataContext;
        private readonly IRepository _repository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration, DataContext dataContext, IRepository repository)
        {
            _logger = logger;
            _configuration = configuration;
            _dataContext = dataContext;
            _repository = repository;
        }

        [HttpGet]
        [Route("GetUsersByContext")]
        public async Task<IEnumerable<User>> Users()
        {
            return await _dataContext.Users.ToListAsync();
        }

        [HttpGet]
        [Route("GetUsersByRepository")]
        public async Task<IEnumerable<User>> UsersRepository()
        {
            return await _repository.User.GetAll();
        }
    }
}