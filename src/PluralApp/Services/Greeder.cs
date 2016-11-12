using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace PluralApp
{
    public interface IGreeder {
        string GetGreeding();
    }
    public class Greeder : IGreeder
    {
        private string _greeting;
        public Greeder(IConfiguration configuration)
        {
            _greeting = configuration["Greetings"];

        }

        public string GetGreeding()
        {
            return _greeting;
        }
    }
}
