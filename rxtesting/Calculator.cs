using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace rxtesting
{
    public class Calculator
    {
        private readonly ILogger<Calculator> _logger;

        public Calculator(ILogger<Calculator> logger)
        {
            _logger = logger;
            _logger.LogInformation("executing constructor...");
        }

        public int Add(int x, int y)
        {
            _logger.LogInformation($"{x} + {y}");
            return x+ y;
        }
        
        public double AddDouble(double x, double y) => x + y;

    }
}
