using System.Reflection;
using AutoFixture;
using FunctionApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace TestProject1
{
    public class UnitTest1
    {

        [Fact]
        public async void Test1()
        {
            var serviceProvider = new ServiceCollection()
                                                .AddLogging()
                                                .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            var logger = factory.CreateLogger<Function1>();

            var context = new DefaultHttpContext();
            var request = context.Request;

            var function = new Function1(); 
            
            
            var response = await function.Run(request, logger) as OkObjectResult;
            Assert.NotNull(response);

            var body = response.Value as String;
            Assert.Equal("What is six times seven? \nThe answer is forty-two.", body);

            
            

        }
    }
}