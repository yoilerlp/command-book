using System.Collections;
using System.Collections.Generic;
using Comandos.Models;
using Comandos.Data;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Comandos.Dtos;
using System.Linq;

namespace Comandos.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class CommandsController : ControllerBase
    {

        public CommandsController(ICommanderRepo commanderRepo, IMapper mapper, IPlatformRepo platformRepo)
        {
            _repository = commanderRepo;
            _mapper = mapper;
            _platformRepo = platformRepo;
        }

        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;
        private readonly IPlatformRepo _platformRepo;

        // GET api/commands/
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandersItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandersItems));
        }

        // GET api/commandsFull
        // para obtener los Commands con su respectiva Platform
        [HttpGet]
        [Route("commandsFull")]
        public ActionResult<IEnumerable<Command>> GetAllCommandsWithFullInf()
        {
            return Ok(_repository.GetAllCommandsWithFullInf());
        }


        // para ver como puedo agrupar la data y modelarla segun yo quiera
        [HttpGet]
        [Route("commandsByPlatform")]
        public ActionResult GetDataGroup()
        {
            return Ok(_repository.GetAllCommandsWithFullInf()
                                 .GroupBy(com => com.Platform.Name).Select(grupo =>
                                 {
                                     return new
                                     {
                                         Plataforma = grupo.Key,
                                         Comandos = grupo.ToList().Select(item =>
                                         {
                                             return new
                                             {
                                                 Id = item.CommandId,
                                                 HowTo = item.HowTo,
                                                 Line = item.Line
                                             };
                                         }),
                                     };
                                 }));

        }


        // GET api/commands/1
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById([FromRoute] int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if (commandItem != null) return Ok(_mapper.Map<CommandReadDto>(commandItem));
            return NotFound();
        }

        // POST api/commands/
        [HttpPost]
        public ActionResult<CommandReadDto> AddCommand(CommandCreateDto newCommand)
        {
            if (newCommand == null) return BadRequest("No valid Data");

            var newCommandPlatform = newCommand.PlatformId;

            var isValidPlatform = _platformRepo.IsValidPlatform(newCommandPlatform);

            if (!isValidPlatform) return BadRequest("Missing PlatformId");

            var commandToSave = _mapper.Map<Command>(newCommand);

            _repository.AddCommand(commandToSave);
            _repository.SaveChanges();

            var objToReturn = new
            {
                Id = commandToSave.CommandId,
            };

            return CreatedAtRoute(nameof(GetCommandById), objToReturn, commandToSave);
        }

        // PUT api/commands/1
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdate)
        {
            var commandFoun = _repository.GetCommandById(id);
            commandUpdate.PlatformId = commandFoun.PlatformId;

            if (commandFoun == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdate, commandFoun);

            _repository.SaveChanges();
            return NoContent();
        }

        // DELETE api/commands/1
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandFound = _repository.GetCommandById(id);
            if (commandFound == null) return NotFound();

            _repository.DeleteCommand(commandFound);
            _repository.SaveChanges();
            return NoContent();
        }

    }
}