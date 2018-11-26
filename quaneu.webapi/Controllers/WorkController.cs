using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quaneu.datalayer;
using quaneu.datalayer.Contracts;
using quaneu.datalayer.Models.Work;

namespace quaneu.webapi.Controllers
{
    [Route("api/[controller]")]
    public class WorkController : Controller
    {
        private IRepositoryWrapper _repoWrapper;

        public WorkController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        // GET: api/Works
        [HttpGet]
        public async Task<IEnumerable<Work>> GetWorks()
        {
            return await _repoWrapper.Works.GetWorksWithImage();
        }

        // GET: api/Works/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWork([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var work = await _repoWrapper.Works.FindAsync(id);

            if (work == null)
            {
                return NotFound();
            }

            return Ok(work);
        }

        // PUT: api/Works/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWork([FromRoute] int id, [FromBody] Work work)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != work.Id)
            {
                return BadRequest();
            }

            _repoWrapper.Works.Add(work);

            try
            {
                await _repoWrapper.Works.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Works
        [HttpPost]
        public async Task<IActionResult> PostWork([FromBody] Work work)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repoWrapper.Works.Add(work);
            await _repoWrapper.Works.Save();

            return CreatedAtAction("GetWork", new { id = work.Id }, work);
        }

        // DELETE: api/Works/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWork([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var work = await _repoWrapper.Works.FindAsync(id);
            if (work == null)
            {
                return NotFound();
            }

            _repoWrapper.Works.Delete(work);
            await _repoWrapper.Works.Save();

            return Ok(work);
        }

        private bool WorkExists(int id)
        {
            return _repoWrapper.Works.Any(e => e.Id == id);
        }
    }
}