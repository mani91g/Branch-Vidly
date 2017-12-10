using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.DTOs;
using AutoMapper;
using System.Data.Entity;

namespace WebApplication1.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
        public IHttpActionResult GetCustomer()
        {
            var object1 = _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customers, CustomerDTO>);

            return Ok( _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customers, CustomerDTO>));
        }

        //GET /api/customers/id
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers
                .Include(c => c.MembershipType)
                .Single(c => c.Id == id);

            if (customer == null)
                return BadRequest();

            return Ok(Mapper.Map<Customers,CustomerDTO>(customer));
        }

        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDTO, Customers>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(Request.RequestUri+"/"+customerDto.Id,customerDto);
        }

        //PUT /api/customers/id
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDTO customerDto)
        {
            var customerInDb = _context.Customers.Single(c => c.Id == id);

            if (!ModelState.IsValid)
                return BadRequest();

            if (customerDto == null)
                return NotFound();

            Mapper.Map(customerDto, customerInDb);

                        
            _context.SaveChanges();

            return Ok(customerDto);
                
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.Single(c => c.Id == id);

            if (customerInDb == null)
                return BadRequest();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
