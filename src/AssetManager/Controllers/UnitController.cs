using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssetManager.Services;
using AssetManager.Entity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AssetManager.Controllers
{
    [Route("api/[controller]")]
    public class UnitController : Controller
    {
        public IWebServices<UnitProfile> _unitProfileService { get; set; }
        public UnitController(IWebServices<UnitProfile> unitProfileService)
        {
            _unitProfileService = unitProfileService;
        }

        // GET: /unit/
        public IActionResult Index()
        {
            return View();
        }

        // GET api/units
        [HttpGet]
        public async Task<List<UnitProfile>> GetAll()
        {
            throw new NotImplementedException();
        }

        // GET api/units/5
        [HttpGet("{id}")]
        public async Task<UnitProfile> Get(long id)
        {
            throw new NotImplementedException();
        }


        // POST api/units
        [HttpPost]
        public async Task<UnitProfile> Post([FromBody]UnitProfile aUnit)
        {
            throw new NotImplementedException();
        }
    }
}
