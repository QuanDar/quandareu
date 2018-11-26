using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quaneu.datalayer.Contracts;
using quaneu.datalayer.Entities.Extensions;
using quaneu.datalayer.Models;

namespace quaneu.webapi.Controllers
{
    [Route("api/[controller]")]
    public class WordPressTemplateController : Controller
    {
        private IRepositoryWrapper _repoWrapper;

        public WordPressTemplateController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        // GET: api/WordPressTemplates
        [HttpGet]
        public async Task<IEnumerable<WordPressTemplateCategoryViewModel>> GetWordPressTemplates()
        {
            return await _repoWrapper.WordPressTemplates.GetWordPressTemplates();
        }

        // GET: api/WordPressTemplates
        [HttpGet("categories")]
        public async Task<IEnumerable<WordPressCategory>> GetCategories()
        {
            var categories = await _repoWrapper.WordPressCategories.FindAll();

            return categories;
        }

        // GET: api/WordPressTemplates/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWordPressTemplate([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var wordPressTemplate = await _repoWrapper.WordPressTemplates.GetWordPressTemplateById(id);

            if (wordPressTemplate == null)
            {
                return NotFound();
            }

            return Ok(wordPressTemplate);
        }

        // GET: api/WordPressTemplates/5
        [HttpGet("amount/{amount}")]
        public async Task<IEnumerable<WordPressTemplate>> GetWordPressTemplates([FromRoute] int amount)
        {
            var wordPressTemplate = await _repoWrapper.WordPressTemplates.GetWordPressTemplates(amount);

            return wordPressTemplate;
        }

        // PUT: api/WordPressTemplates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWordPressTemplate([FromRoute] int id, [FromBody] WordPressTemplate wordPressTemplate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wordPressTemplate.Id)
            {
                return BadRequest();
            }

            _repoWrapper.WordPressTemplates.Update(wordPressTemplate);

            try
            {
                await _repoWrapper.WordPressTemplates.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WordPressTemplateExists(id))
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

        // POST: api/WordPressTemplates
        [HttpPost]
        public async Task<IActionResult> PostWordPressTemplate([FromBody] WordPressTemplate wordPressTemplate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repoWrapper.WordPressTemplates.Add(wordPressTemplate);
            await _repoWrapper.WordPressTemplates.Save();

            return CreatedAtAction("GetWordPressTemplate", new { id = wordPressTemplate.Id }, wordPressTemplate);
        }

        [HttpPost("categories")]
        public async Task<IActionResult> PostWordPressTemplateCategory([FromBody] WordPressCategory wordPressCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repoWrapper.WordPressCategories.Add(wordPressCategory);
            await _repoWrapper.WordPressTemplates.Save();

            return CreatedAtAction("GetCategories", new { id = wordPressCategory.Id }, wordPressCategory);
        }

        // DELETE: api/WordPressTemplates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWordPressTemplate([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var wordPressTemplate = await _repoWrapper.WordPressTemplates.FindAsync(id);
            if (wordPressTemplate == null)
            {
                return NotFound();
            }

            _repoWrapper.WordPressTemplates.Delete(wordPressTemplate);
            await _repoWrapper.WordPressTemplates.Save();

            return Ok(wordPressTemplate);
        }
        [HttpDelete("{categories}/{id}")]
        public async Task<IActionResult> DeleteWordPressTemplateCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _repoWrapper.WordPressCategories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _repoWrapper.WordPressCategories.Delete(category);
            await _repoWrapper.WordPressCategories.Save();

            return Ok(category);
        }
        private bool WordPressTemplateExists(int id)
        {
            return _repoWrapper.WordPressTemplates.Any(e => e.Id == id);
        }
    }
}