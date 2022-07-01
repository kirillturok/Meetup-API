using System;
using System.Collections.Generic;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Modsen.Controllers
{
    [Route("api/event")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Events")]
    public class EventController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public EventController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet, Authorize]
        public IActionResult GetEvents()
        {
            var events = _repository.Event.GetAllEvents(false);
            var eventDto = _mapper.Map<IEnumerable<EventDto>>(events);
            return Ok(eventDto);
        }

        [HttpGet("{id}"), Authorize]
        public IActionResult GetEvent(Guid id)
        {
            var ev = _repository.Event.GetEvent(id, trackChanges: false);
            if (ev == null)
            {
                _logger.LogInfo($"Company with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var evDto = _mapper.Map<EventDto>(ev);
                return Ok(evDto);
            }
        }

        [HttpPost, Authorize(Roles = "Administrator")]
        public IActionResult CreateEvent([FromBody] EventForCreationDto ev)
        {
            if (ev == null)
            {
                _logger.LogError("EventForCreationDto object sent from client is null.");
                return BadRequest("EventForCreationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the EventForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var eventEntity = _mapper.Map<Event>(ev);
            _repository.Event.CreateEvent(eventEntity);
            _repository.Save();
            var eventToReturn = _mapper.Map<EventDto>(eventEntity);
            return CreatedAtAction(nameof(GetEvent), new { id = eventToReturn.Id }, eventToReturn);
        }

        [HttpPut("{id}"), Authorize(Roles = "Administrator")]
        public IActionResult UpdateCompany(Guid id, [FromBody] EventForUpdateDto ev)
        {
            if (ev == null)
            {
                _logger.LogError("EventForUpdateDto object sent from client is null.");
                return BadRequest("EventForUpdateDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the EventForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }

            var eventEntity = _repository.Event.GetEvent(id, trackChanges: true);
            if (eventEntity == null)
            {
                _logger.LogInfo($"Event with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(ev, eventEntity);
            _repository.Save();
            return NoContent();
        }

        [HttpDelete("{id}"), Authorize(Roles = "Administrator")]
        public IActionResult DeleteCompany(Guid id)
        {
            var ev = _repository.Event.GetEvent(id, trackChanges: false);
            if (ev == null)
            {
                _logger.LogInfo($"Event with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.Event.DeleteEvent(ev);
            _repository.Save();
            return NoContent();
        }
    }
}
