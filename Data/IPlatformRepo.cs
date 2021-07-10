using System.Collections.Generic;
using Comandos.Models;

namespace Comandos.Data
{
    public interface IPlatformRepo
    {
        IEnumerable<Platform> GetAllPlatforms();

        Platform CreatePlatform(Platform newPlatform);

        Platform GetPlatformById(int id);

        bool SaveChanges();

        bool IsValidPlatform(int platforId);
    }
}