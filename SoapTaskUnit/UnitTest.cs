using ConvertSoapToRest;
using ConvertSoapToRest.Controllers;
using ConvertSoapToRest.Dto;
using ConvertSoapToRest.Model;
using ConvertSoapToRest.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SoapTaskUnit
{
    public class UnitTest
    {
        Mock<ILogger<ServiceController>> logger;
        private ServiceDbContext dbContext;


        public UnitTest()
        {
            logger = new Mock<ILogger<ServiceController>>();
        }

        [Fact]
        public async Task AddAsync()
        {
            Number model = new Number
            {
                FirstNumber = 1,
                SecondNumber = 2
            };
            var context = new ServiceController(logger.Object, dbContext);

            var respons = await context.AddAsync(model);

            logger.Verify(
            x => x.Log(
            It.IsAny<LogLevel>(),
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => true),
            It.IsAny<Exception>(),
            It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)));
        }
    }
}
