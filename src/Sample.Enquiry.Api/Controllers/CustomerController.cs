﻿using Sample.Enquiry.Core.Entities;
using Sample.Enquiry.Core.Interfaces;
using Sample.Enquiry.Api.ApiModels;
using Sample.Enquiry.Api.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Sample.Enquiry.Api
{
    public class CustomerController : BaseApiController
    {
        private readonly IRepository _repository;

        public CustomerController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/ToDoItems
        [HttpGet]
        public IActionResult List()
        {
            var customers = _repository.List<Customer>()
                .Select(  c => c.ToDto());
            return Ok(customers);
        }

        // GET: api/ToDoItems
        [HttpGet("{id:int}")]
        public IActionResult GetById(ulong id)
        {
            var item = ToDoItemDTO.FromToDoItem(_repository.GetById<ToDoItem>(id));
            return Ok(item);
        }
    }
}
