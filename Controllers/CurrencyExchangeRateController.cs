using CurrencyExchangeCrud.Data.Dtos;
using CurrencyExchangeCrud.Data.Models;
using CurrencyExchangeCrud.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CurrencyExchangeCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyExchangeRateController : ControllerBase
    {
        private readonly ICurrencyExchangeRateAppService _currencyexchangeServiceAppService;

        public CurrencyExchangeRateController(ICurrencyExchangeRateAppService currencyExchangeRateAppService)
        {
            _currencyexchangeServiceAppService = currencyExchangeRateAppService;
        }

        // GET: api/Currencies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurrencyExchangeRate>>> GetCurrencyExchangeRateAll()
        {
            try
            {
                var currency = await _currencyexchangeServiceAppService.GetAllAsync();

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
        public async Task<ActionResult<CurrencyExchangeRateDto>> GetCurrencyExchangeRate([FromRoute] int? id)
        {
            if (id == null)
            {

                return NotFound();
            }

            try
            {
                var currency = await _currencyexchangeServiceAppService.GetByIdAsync((int)id);

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

        // POST: api/Currencies
        [HttpPost]
        public async Task<ActionResult<CurrencyExchangeRate>> PostCurrency(CurrencyExchangeRateDto currencyDto)
        {
            try
            {
                await _currencyexchangeServiceAppService.CreateAsync(currencyDto);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Currencies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurrency(int? id, CurrencyExchangeRateDto currencyDto)
        {
            if (id != currencyDto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _currencyexchangeServiceAppService.UpdateAsync(currencyDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return NoContent();
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
                var currency = await _currencyexchangeServiceAppService.GetByIdAsync((int)id);

                if (currency == null)
                {
                    return BadRequest();
                }

                await _currencyexchangeServiceAppService.DeleteAsync((int)id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return NoContent();
        }

        [HttpGet("GetExchangeRateToINRByCurrencyCode/{currencyCode}")]
        public async Task<ActionResult<double>> GetExchangeRateToINRByCurrencyCode([FromRoute] string? currencyCode, DateTime? exchangeDate = null)
        {
            try
            {
                var exchange = await _currencyexchangeServiceAppService.GetExchangeRateToINRByCurrencyCode(currencyCode, exchangeDate);

                if (exchange == null)
                {
                    return NoContent();
                }

                return Ok(exchange);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetExchangeRateToINRByCurrencyName/{currencyName}")]
        public async Task<ActionResult<double>> GetExchangeRateToINRByCurrencyName([FromRoute] string? currencyName, DateTime? exchangeDate = null)
        {
            try
            {
                var exchange = await _currencyexchangeServiceAppService.GetExchangeRateToINRByCurrencyName(currencyName, exchangeDate);

                if (exchange == null)
                {
                    return NoContent();
                }

                return Ok(exchange);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetExchangeRateByCurrencyCode/{sourceCurrencyCode}/{targetCurrencyCode}")]
        public async Task<ActionResult<double>> GetExchangeRateByCurrencyCode([FromRoute] string? sourceCurrencyCode, [FromRoute] string? targetCurrencyCode, DateTime? exchangDate = null)
        {
            try
            {
                var exchange = await _currencyexchangeServiceAppService.GetExchangeRateByCurrencyCode(sourceCurrencyCode, targetCurrencyCode, exchangDate);

                if (exchange == null)
                {
                    return BadRequest();
                }

                return Ok(exchange);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetExchangeRateByCurrencyName/{sourceCurrencyName}/{targetCurrencyName}")]
        public async Task<ActionResult<double>> GetExchangeRateByCurrencyName([FromRoute] string? sourceCurrencyName, [FromRoute] string? targetCurrencyName, DateTime? exchangDate = null)
        {
            try
            {
                var exchange = await _currencyexchangeServiceAppService.GetExchangeRateByCurrencyName(sourceCurrencyName, targetCurrencyName, exchangDate);

                if (exchange == null)
                {
                    return BadRequest();
                }

                return Ok(exchange);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
