using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebFormApp.BLL;
using MyWebFormApp.BLL.DTOs;
using MyWebFormApp.BLL.Interfaces;
using MyWebFormApp.BO;

namespace MyWebFormApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleBLL _articleBLL;
        public ArticlesController(IArticleBLL articleBLL)
        {
            _articleBLL = articleBLL;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _articleBLL.GetArticleWithCategory();

            if (result == null)
            {
                return NotFound();
            }

            if (result.Count() == 0)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _articleBLL.GetArticleById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _articleBLL.Delete(id);
                return Ok("Success Delete Article");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ArticleCreateDTO articleDTO)
        {
            try
            {
                _articleBLL.Insert(articleDTO);
                return Ok("Article created successfully");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ArticleUpdateDTO articleDTO)
        {
            try
            {
                var article = _articleBLL.GetArticleById(id);
                if (article == null)
                {
                    return NotFound();
                }

                articleDTO.ArticleID = id;
                _articleBLL.Update(articleDTO);
                return Ok("Article update successful");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetArticleByCategory/{id}")]
        public IActionResult GetArticleByCategory(int id)
        {
            var result = _articleBLL.GetArticleByCategory(id);

            if (result == null)
            {
                return NotFound();
            }

            if (result.Count() == 0)
            {
                return NoContent();
            }

            return Ok(result);
        }

    }
}
