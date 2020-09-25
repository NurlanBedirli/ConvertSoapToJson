using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConvertSoapToRest.Dto;
using ConvertSoapToRest.Enums;
using ConvertSoapToRest.Model;
using ConvertSoapToRest.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskService;

namespace ConvertSoapToRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceController : ControllerBase
    {
        public ILogger<ServiceController>  _logger;
        private readonly CalculatorSoapClient  _soapClient = new CalculatorSoapClient(CalculatorSoapClient.EndpointConfiguration.CalculatorSoap12);
        private readonly ServiceDbContext _dbContext;

        public ServiceController(ILogger<ServiceController>  logger, ServiceDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }


        #region AddMethod
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddAsync([FromBody] Number number)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                _logger.LogInformation((int)CalculateEnum.Add, "Request to Json", "Method started ");
                try
                {
                    _logger.LogInformation((int)CalculateEnum.Add, "Request to Soap", "Request sent");
                     result = await _soapClient.AddAsync(number.FirstNumber, number.SecondNumber);
                    _logger.LogInformation((int)CalculateEnum.Add, "Response from Soap", "Request success");

                    using (var transaction = await _dbContext.Database.BeginTransactionAsync())
                    {
                         Table table = new Table();
                        _dbContext.Tables.Add(table);
                        await _dbContext.SaveChangesAsync();

                        SecondTable second = new SecondTable
                        {
                            Value = result.ToString(),
                            TableId = table.Id
                        };
                        await _dbContext.SecondTables.AddAsync(second);
                        await _dbContext.SaveChangesAsync();
                        await transaction.CommitAsync();
                    }
                }
                catch (Exception exp)
                {
                    _logger.LogError((int)CalculateEnum.Add, "Error message", exp.Message);
                    return BadRequest(exp.Message);
                }
                return Ok(result);
            }
            return BadRequest(ModelState);
        }
        #endregion

        #region DivideMethod
        [HttpPost]
        [Route("divide")]
        public async Task<ActionResult> DivideAsync([FromBody] Number number)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                _logger.LogInformation((int)CalculateEnum.Divide, "Request to Json", "Method started ");
                try
                {
                    _logger.LogInformation((int)CalculateEnum.Divide, "Request to Soap", "Request sent");
                    result = await _soapClient.DivideAsync(number.FirstNumber, number.SecondNumber);
                    _logger.LogInformation((int)CalculateEnum.Divide, "Response from Soap", "Request success");

                    using (var transaction = await _dbContext.Database.BeginTransactionAsync())
                    {
                        Table table = new Table();
                        _dbContext.Tables.Add(table);
                        await _dbContext.SaveChangesAsync();

                        SecondTable second = new SecondTable
                        {
                            Value = result.ToString(),
                            TableId = table.Id
                        };
                        await _dbContext.SecondTables.AddAsync(second);
                        await _dbContext.SaveChangesAsync();
                        await transaction.CommitAsync();

                    }
                }
                catch (Exception exp)
                {
                    _logger.LogError((int)CalculateEnum.Divide, "Error message", exp.Message);
                    throw;
                }
                return Ok(result);
            }
            return BadRequest(ModelState);
        }
        #endregion

        #region MultiplyMethod
        [HttpPost]
        [Route("multiply")]
        public async Task<ActionResult> MultiplyAsync([FromBody] Number number)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                _logger.LogInformation((int)CalculateEnum.Multiply, "Request to Json", "Method started ");
                try
                {
                    _logger.LogInformation((int)CalculateEnum.Multiply, "Request to Soap", "Request sent");
                    result = await _soapClient.MultiplyAsync(number.FirstNumber, number.SecondNumber);
                    _logger.LogInformation((int)CalculateEnum.Multiply, "Response from Soap", "Request success");

                    using (var transaction = await _dbContext.Database.BeginTransactionAsync())
                    {
                        Table table = new Table();
                        _dbContext.Tables.Add(table);
                        await _dbContext.SaveChangesAsync();

                        SecondTable second = new SecondTable
                        {
                            Value = result.ToString(),
                            TableId = table.Id
                        };
                        await _dbContext.SecondTables.AddAsync(second);
                        await _dbContext.SaveChangesAsync();
                        await transaction.CommitAsync();
                    }
                }
                catch (Exception exp)
                {
                    _logger.LogError((int)CalculateEnum.Multiply, "Error message", exp.Message);
                    throw;
                }
                return Ok(result);
            }
            return BadRequest(ModelState);
        }
        #endregion

        #region SubtractMethod
        [HttpPost]
        [Route("subtract")]
        public async Task<ActionResult> SubtractAsync([FromBody] Number number)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                _logger.LogInformation((int)CalculateEnum.Subtract, "Request to Json", "Method started ");
                try
                {
                    _logger.LogInformation((int)CalculateEnum.Subtract, "Request to Soap", "Request sent");
                    result = await _soapClient.SubtractAsync(number.FirstNumber, number.SecondNumber);
                    _logger.LogInformation((int)CalculateEnum.Subtract, "Response from Soap", "Request success");

                    using (var transaction = await _dbContext.Database.BeginTransactionAsync())
                    {
                        Table table = new Table();
                        _dbContext.Tables.Add(table);
                        await _dbContext.SaveChangesAsync();

                        SecondTable second = new SecondTable
                        {
                            Value = result.ToString(),
                            TableId = table.Id
                        };
                        await _dbContext.SecondTables.AddAsync(second);
                        await _dbContext.SaveChangesAsync();
                        await transaction.CommitAsync();
                    }
                }
                catch (Exception exp)
                {
                    _logger.LogError((int)CalculateEnum.Subtract, "Error message", exp.Message);
                    throw;
                }
                return Ok(result);
            }
            return BadRequest(ModelState);
        }
        #endregion

    }
}