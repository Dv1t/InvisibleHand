using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvisibleHand.Identities;
using InvisibleHand.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InvisibleHand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotController : ControllerBase
    {
        private readonly LotService _lotService;
        private readonly UserService _userService;

        public LotController(LotService lotService,UserService userService)
        {
            _lotService = lotService;
            _userService = userService;
        }

        

        [HttpGet("{owner:length(11)}", Name = "GetLot")]
        public ActionResult<List<Lot>> Get(string owner)
        {
            var lots = _lotService.FindByOwner(owner);

            if (lots == null)
            {
                return NotFound();
            }

            return lots;
        }

        [HttpPost]
        public ActionResult<Lot> Create([FromHeader] string owner, [FromHeader] string product, [FromHeader] double price, [FromHeader] bool sell)
        {
           
                Lot lot = new Lot();
                lot.Product = product;
                lot.Sell = sell;
                lot.Owner = owner;
                lot.Price = price;
            
           
            return _lotService.Create(lot);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, User userIn)
        {
            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.Update(id, userIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var lot = _lotService.Get(id);

            if (lot == null)
            {
                return NotFound();
            }

            _userService.Remove(lot.Id);

            return NoContent();
        }
    }
}
