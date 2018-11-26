using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quaneu.datalayer;
using quaneu.datalayer.Contracts;
using quaneu.datalayer.Models;
using quaneu.datalayer.Models.Image;

namespace quaneu.webapi.Controllers
{
    [Route("api/[controller]")]
    public class ImageController : Controller
    {
        private IRepositoryWrapper _repoWrapper;

        public ImageController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        // GET: api/Images
        [HttpGet]
        public async Task<IEnumerable<Image>> GetImages()
        {
            return await _repoWrapper.Images.FindAll();
        }

        // GET: api/Images/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetImage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var image = await _repoWrapper.Images.FindAsync(id);

            if (image == null)
            {
                return NotFound();
            }

             return Ok(image);
           }

        // PUT: api/Images/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImage([FromRoute] int id, [FromBody] Image image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != image.Id)
            {
                return BadRequest();
            }

            _repoWrapper.Images.Update(image);

            try
            {
                await _repoWrapper.Images.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageExists(id))
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

        // POST: api/Images
        [HttpPost]
        public async Task<IActionResult> PostImage([FromBody] Image image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repoWrapper.Images.Add(image);
            await _repoWrapper.Images.Save();

            return CreatedAtAction("GetImage", new { id = image.Id }, image);
        }

        // DELETE: api/Images/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var image = await _repoWrapper.Images.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }

            _repoWrapper.Images.Delete(image);
            await _repoWrapper.Images.Save();

            return Ok(image);
        }

        private bool ImageExists(int id)
        {
            return _repoWrapper.Images.Any(e => e.Id == id);
        }
    }
}