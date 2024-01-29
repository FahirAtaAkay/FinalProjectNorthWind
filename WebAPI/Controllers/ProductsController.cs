﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;
        public ProductsController(IProductService productService)
        {
                _productService = productService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll() 
        {
            var result = _productService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")] // alyas verdik localhostta api/route/alyas şeklinde çalışabilir bir yapımız oldu
        public IActionResult GetById(int id) 
        {
            var result = _productService.GetById(id);
            if (result.IsSuccess) 
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Product product) 
        {
            var result = _productService.Add(product);
            if(result.IsSuccess) 
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Product product) 
        {
            var result = _productService.Update(product);
            if(result.IsSuccess) 
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



    }
}