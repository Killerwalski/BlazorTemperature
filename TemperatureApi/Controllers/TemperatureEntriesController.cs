using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemperatureApi.Models;
using TemperatureApi.Services;

namespace TemperatureApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureEntriesController : ControllerBase
    {
        // private readonly TemperatureApiContext _context;
        private readonly TemperatureDataService _dataService;

        public TemperatureEntriesController(TemperatureDataService dataService)
        {
            _dataService = dataService;
        }

        // GET: api/TemperatureEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TemperatureEntry>>> GetTemperatureEntry()
        {
            return  _dataService.Get();
        }
    }
}
