using API.Model;
using API.Repositories.Interfaces;
using API.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/v1/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly IMapper _mapper;

        public PersonController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromServices] IPersonRepository repository
            )
        {
            var allPerson = await repository.GetAll();
            return Ok(allPerson);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(
            [FromRoute] Guid id,
            [FromServices] IPersonRepository repository
            )
        {
            var person = await repository.GetById(id);
            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromServices] IPersonRepository repository,
            [FromBody] CreatePersonViewModel createPersonViewModel
            )
        {
            var person = _mapper.Map<Person>(createPersonViewModel);
            await repository.Create(person);
            return Ok(person);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id,
            [FromServices] IPersonRepository repository,
            [FromBody] UpdatePersonViewModel updatePersonViewModel
            )
        {
            var person = _mapper.Map<Person>(updatePersonViewModel);
            await repository.Update(person, id);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(
            [FromRoute] Guid id,
            [FromServices] IPersonRepository repository
            )
        {
            await repository.Remove(id);
            return NoContent();
        }
    }
}
