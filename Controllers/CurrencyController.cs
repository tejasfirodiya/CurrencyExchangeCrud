using CurrencyExchangeCrud.Data.Dtos;
using CurrencyExchangeCrud.Data.Models;
using CurrencyExchangeCrud.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchangeCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyAppService _currencyAppService;

        public CurrencyController(ICurrencyAppService currencyAppService)
        {
            _currencyAppService = currencyAppService;
        }

        // GET: api/Currencies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurrencyMaster>>> GetCurrencies()
        {
            try
            {
                var currency = await _currencyAppService.GetAllAsync();

                if (currency == null)
                {
                    return NotFound();
                }

                return Ok(currency);
            }
            catch (Exception e)
            {
                return Problem("Error in GetAll : ", e.Message);
            }
        }

        // GET: api/Currencies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CurrencyMasterDto>> GetCurrency([FromRoute] int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var currency = await _currencyAppService.GetByIdAsync((int)id);

                if (currency == null)
                {
                    return NotFound();
                }

                return Ok(currency);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Currencies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurrency(int? id, CurrencyMasterDto currencyDto)
        {
            if (id != currencyDto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _currencyAppService.UpdateAsync(currencyDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Problem();
            }

            return NoContent();
        }

        // POST: api/Currencies
        [HttpPost]
        public async Task<ActionResult<CurrencyMaster>> PostCurrency(CurrencyMasterDto currencyDto)
        {
            try
            {
                await _currencyAppService.CreateAsync(currencyDto);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Currencies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurrency(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                var currency = await _currencyAppService.GetByIdAsync((int)id);

                if (currency == null)
                {
                    return BadRequest();
                }

                await _currencyAppService.DeleteAsync((int)id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return NoContent();
        }
    }
}
