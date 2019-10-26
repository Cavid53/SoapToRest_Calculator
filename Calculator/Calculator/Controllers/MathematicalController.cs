using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CalculationProject;
using Calculator.DAL;
using Calculator.Helpers;
using Calculator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Calculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathematicalController : ControllerBase
    {
        private CalculatorSoapClient _calculatorSoap = new CalculatorSoapClient(CalculatorSoapClient.EndpointConfiguration.CalculatorSoap12);
        private CalculatorDbContext _dbContext;
        private readonly ILogger<MathematicalController> _logger;


        public MathematicalController(CalculatorDbContext dbContext, ILogger<MathematicalController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] NumCalculator number)
        {

            try
            {
                var data = JsonConvert.SerializeObject(number);
                _logger.LogInformation(string.Format(Messages.Request, "Add", data));

                await _dbContext.Reports.AddAsync(new Report
                {
                    MethodId = 1,
                    VALUE = string.Format(Messages.Request, "Add", data)
                });

                var response = await _calculatorSoap.AddAsync(number.FirstNum, number.SecondNum);

                await _dbContext.Reports.AddAsync(new Report
                {
                    MethodId = 1,
                    VALUE = string.Format(Messages.Response, "Add", response, data)
                });


                await _dbContext.SaveChangesAsync();
                _logger.LogInformation("The control is succesfully", response);

                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }


        }

        [HttpPost("subtract")]
        public async Task<IActionResult> Subtract([FromBody] NumCalculator number)
        {
            try
            {
                var data = JsonConvert.SerializeObject(number);
                _logger.LogInformation(string.Format(Messages.Request, "Add", data));

                await _dbContext.Reports.AddAsync(new Report
                {
                    MethodId = 2,
                    VALUE = string.Format(Messages.Request, "Add", data)
                });

                var response = await _calculatorSoap.SubtractAsync(number.FirstNum, number.SecondNum);

                await _dbContext.Reports.AddAsync(new Report
                {
                    MethodId = 2,
                    VALUE = string.Format(Messages.Response, "Add", response, data)
                });


                await _dbContext.SaveChangesAsync();
                _logger.LogInformation("The control is succesfully", response);

                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }


        }

        [HttpPost("multiply")]
        public async Task<IActionResult> Multiply([FromBody] NumCalculator number)
        {
            try
            {
                var data = JsonConvert.SerializeObject(number);
                _logger.LogInformation(string.Format(Messages.Request, "Add", data));

                await _dbContext.Reports.AddAsync(new Report
                {
                    MethodId = 3,
                    VALUE = string.Format(Messages.Request, "Add", data)
                });

                var response = await _calculatorSoap.MultiplyAsync(number.FirstNum, number.SecondNum);

                await _dbContext.Reports.AddAsync(new Report
                {
                    MethodId = 3,
                    VALUE = string.Format(Messages.Response, "Add", response, data)
                });


                await _dbContext.SaveChangesAsync();
                _logger.LogInformation("The control is succesfully", response);

                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }


        }

        [HttpPost("divide")]
        public async Task<IActionResult> Divide([FromBody] NumCalculator number)
        {
            try
            {
                var data = JsonConvert.SerializeObject(number);
                _logger.LogInformation(string.Format(Messages.Request, "Add", data));

                await _dbContext.Reports.AddAsync(new Report
                {
                    MethodId = 1,
                    VALUE = string.Format(Messages.Request, "Add", data)
                });

                var response = await _calculatorSoap.DivideAsync(number.FirstNum, number.SecondNum);

                await _dbContext.Reports.AddAsync(new Report
                {
                    MethodId = 1,
                    VALUE = string.Format(Messages.Response, "Add", response, data)
                });


                await _dbContext.SaveChangesAsync();
                _logger.LogInformation("The control is succesfully", response);

                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }


        }
    }
}