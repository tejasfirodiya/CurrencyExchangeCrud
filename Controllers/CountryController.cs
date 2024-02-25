using CurrencyExchangeCrud.Data.Dtos;
using CurrencyExchangeCrud.Data.Models;
using CurrencyExchangeCrud.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchangeCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryAppService _countryAppService;

        public CountryController(ICountryAppService countryAppService)
        {
            _countryAppService = countryAppService;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryMaster>>> GetCountries()
        {
            try
            {
                var country = await _countryAppService.GetAllAsync();

                if (country == null)
                {
                    return NotFound();
                }

                return Ok(country);
            }
            catch (Exception e)
            {
                return Problem("Error in GetAll : ", e.Message);
            }
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryMasterDto>> GetCountry([FromRoute] int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var country = await _countryAppService.GetByIdAsync((int)id);

                if (country == null)
                {
                    return NotFound();
                }

                return Ok(country);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Countries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int? id, CountryMasterDto countrydto)
        {
            if (id != countrydto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _countryAppService.UpdateAsync(countrydto);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Problem();
            }

            return NoContent();
        }

        // POST: api/Countries
        [HttpPost]
        public async Task<ActionResult<CountryMaster>> PostCountry(CountryMasterDto countrydto)
        {
            try
            {
                await _countryAppService.CreateAsync(countrydto);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                var country = await _countryAppService.GetByIdAsync((int)id);

                if (country == null)
                {
                    return BadRequest();
                }

                await _countryAppService.DeleteAsync((int)id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }
    }
}
