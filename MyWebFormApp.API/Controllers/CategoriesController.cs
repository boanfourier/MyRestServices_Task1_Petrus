﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebFormApp.BLL.DTOs;
using MyWebFormApp.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWebFormApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryBLL _categoryBLL;
        public CategoriesController(ICategoryBLL categoryBLL)
        {
            _categoryBLL = categoryBLL;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _categoryBLL.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _categoryBLL.GetById(id);
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
                _categoryBLL.Delete(id);
                return Ok("Success Delete Category");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CategoryCreateDTO categoryDTO)
        {
            try
            {
                _categoryBLL.Insert(categoryDTO);
                return Ok("Category created successfully");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CategoryUpdateDTO categoryDTO)
        {
            try
            {
                var category = _categoryBLL.GetById(id);
                if (category == null)
                {
                    return NotFound();
                }
                categoryDTO.CategoryID = id;
                _categoryBLL.Update(categoryDTO);
                return Ok("Category update successful");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByName/{name}")]
        public IActionResult GetByName(string name)
        {
            var result = _categoryBLL.GetByName(name);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

    }
}
