using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Data
{
    public interface IPlatformRepo
    {
        void CreatePlatform(PLatform plat);
        PLatform? GetPlatformById(string id);
        IEnumerable<PLatform?>? GetAllPlatforms();
    }
}