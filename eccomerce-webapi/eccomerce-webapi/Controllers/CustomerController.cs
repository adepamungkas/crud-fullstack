using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using eccomerce_webapi.Models;
using eccomerce_webapi.Repositories;
using eccomerce_webapi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eccomerce_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<CustomerModel> _customerRepository;
        private readonly IMapper _mapper;
        public CustomerController(IRepository<CustomerModel> countryRepository, IMapper mapper)
        {
            _customerRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet("", Name = "GetAll")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_customerRepository.GetAll().Select(x =>
                {
                    return _mapper.Map<CustomerViewModel>(x);
                }));
            }
            catch (Exception exception)
            {
                //logg exception or do anything with it
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }


        // GET api/values/5
        [HttpGet("{id}", Name = "GetSingle")]
        public IActionResult Get(int id)
        {
            try
            {
                CustomerModel customerModel = _customerRepository.GetSingle(id);

                if (customerModel == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<CustomerViewModel>(customerModel));
            }
            catch (Exception exception)
            {
                //Do something with the exception
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CustomerViewModel viewModel)
        {
            try
            {
                if (viewModel == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                CustomerModel singleById = _customerRepository.GetSingle(id);

                if (singleById == null)
                {
                    return NotFound();
                }

                singleById.Name = viewModel.Name;

                _customerRepository.Update(singleById);
                int save = _customerRepository.Save();

                if (save > 0)
                {
                    return Ok(_mapper.Map<CustomerViewModel>(singleById));
                }

                return BadRequest();
            }
            catch (Exception exception)
            {
                //Do something with the exception
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }



        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]CustomerViewModel viewModel)
        {
            try
            {
                if (viewModel == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                CustomerModel item = _mapper.Map<CustomerModel>(viewModel);

                _customerRepository.Add(item);
                int save = _customerRepository.Save();

                //  return CreatedAtAction("GetCustomer", new { id = item.Id }, item)
            
                if (save > 0)
                {
                    return CreatedAtAction("GetSingle", new { id = item.Id }, item);
                   // return CreatedAtRoute("GetSingle", new { controller = "CustomerController", id = item.Id }, item);
                }

                return BadRequest();
            }
            catch (Exception exception)
            {
                //Do something with the exception
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }



        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                CustomerModel singleById = _customerRepository.GetSingle(id);

                if (singleById == null)
                {
                    return NotFound();
                }

                _customerRepository.Delete(singleById);
                int save = _customerRepository.Save();

                if (save > 0)
                {
                    return NoContent();
                }

                return BadRequest();
            }
            catch (Exception exception)
            {
                //Do something with the exception
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}