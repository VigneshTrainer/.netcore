using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CardsController : Controller
    {
        private CardsDbContext cardsDbContext;

        public CardsController(CardsDbContext cardsDbContext)
        {
            this.cardsDbContext = cardsDbContext;
        }

        //Get All Cards
        [HttpGet]
        public async Task <IActionResult> GetAllCards()
        {
            var cards = await cardsDbContext.Cards.ToListAsync();
            return Ok(cards);
        }


        //Get Single card
        [HttpGet]
        [Route("id:guid")]
        public async Task<IActionResult> GetAllCards([FromRoute] Guid id)
        {
            var card=await cardsDbContext.Cards.FirstOrDefaultAsync(x=>x.Id==id);
            if (card !=null)
            {
                return Ok(card);
            }
            return NotFound(card);
        }

        //[HttpPost]
        //public async Task<IActionResult> AddCard([FromForm] Card card)
        //{
        //    card.Id = Guid.NewGuid();

        //    await cardsDbContext.Cards.AddAsync(card);
        //}
    }
}
