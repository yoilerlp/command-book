using System.Collections.Generic;
using Comandos.Models;

namespace Comandos.Data 
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAllCommands();
        
        IEnumerable<Command> GetAllCommandsWithFullInf();

        Command GetCommandById(int id);
        Command AddCommand(Command newCommand);
        void DeleteCommand(Command command);

        bool SaveChanges();
        
    }



}