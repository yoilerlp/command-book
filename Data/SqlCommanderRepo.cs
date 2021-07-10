using System;
using System.Collections.Generic;
using System.Linq;
using Comandos.Models;
using Comandos.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Comandos.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private CommanderContext _context { get; }
        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        

        public Command GetCommandById(int id)
        {

            var itemFound = _context.Commands.FirstOrDefault(p => p.CommandId == id);

            return itemFound;
        }

        public Command AddCommand(Command newCommand)
        {
           
           var commandSave = _context.Commands.Add(newCommand);
            return newCommand;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void DeleteCommand(Command command)
        {
            _context.Commands.Remove(command);
        }

        public IEnumerable<Command> GetAllCommandsWithFullInf()
        {
           return _context.Commands.Include(comm => comm.Platform)
           .ToList();
        }
    }

}