using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Models;
using Microsoft.VisualBasic;
using StackExchange.Redis;

namespace API.Data
{
    public class RedisPlatformRepo : IPlatformRepo
    {
        private readonly IConnectionMultiplexer _redis;

        public RedisPlatformRepo(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        public void CreatePlatform(PLatform plat)
        {
            if (plat == null)
            {
                throw new ArgumentOutOfRangeException(nameof(plat));
            }
            var db = _redis.GetDatabase();
            var serialPlat = JsonSerializer.Serialize(plat);
            db.HashSet($"hashplatform", new HashEntry[] 
                {new HashEntry(plat.Id, serialPlat)});
        }

        public IEnumerable<PLatform?>? GetAllPlatforms()
        {
             var db = _redis.GetDatabase();

            var completeSet = db.HashGetAll("hashplatform");
            
            if (completeSet.Length > 0)
            {
                var obj = Array.ConvertAll(completeSet, val => 
                    JsonSerializer.Deserialize<PLatform>(val.Value)).ToList();
                return obj;   
            }
            
            return null;
        }

        public PLatform? GetPlatformById(string id)
        {
             var db = _redis.GetDatabase();

            //var plat = db.StringGet(id);

            var plat = db.HashGet("hashplatform", id);

            if (!string.IsNullOrEmpty(plat))
            {
                return JsonSerializer.Deserialize<PLatform>(plat);
            }
            return null;
        }
    }
}