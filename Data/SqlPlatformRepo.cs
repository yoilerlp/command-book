using System.Collections.Generic;
using System.Linq;
using Comandos.Models;

namespace Comandos.Data 
{
    public class SqlPlatformRepo : IPlatformRepo
    {

        private CommanderContext _contex {get;}

        public SqlPlatformRepo(CommanderContext context)
        {
            _contex = context;
        }
        public Platform CreatePlatform(Platform newPlatform)
        {
            _contex.Platforms.Add(newPlatform);
            return newPlatform;
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _contex.Platforms.ToList();
        }

        public bool SaveChanges()
        {
            return _contex.SaveChanges() >= 0;
        }

        public bool IsValidPlatform(int platforId)
        {
           return _contex.Platforms.Any<Platform>(platform => platform.PlatformId == platforId);
        }

        public Platform GetPlatformById(int id)
        {
          return _contex.Platforms.FirstOrDefault(p => p.PlatformId == id);
        }
    }


}