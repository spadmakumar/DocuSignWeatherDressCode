using SimpleInjector;
using System;
using System.Collections.Generic;
using DocuSign.WeatherDressCode.Services.Models;
using DocuSign.WeatherDressCode.Services.Services;

namespace DocuSignProject
{
    class Program
    {
        static void Main(string[] args)
        {
			//Creating the container for DI
	        var container = new Container();
	        DIHelper.Register(container);
	        DIHelper.RegisterSingleton(container);
	        container.Verify();

	        var serviceProvider = container.GetInstance<WeatherDressCodeSequencingService>();
			var input = new InputDressCodeSequence();
	        input.Code = Enums.TempCode.Hot;
			input.Commands = new List<Command>
			{
				new Command
				{
					CommandKey = 8
				},
				new Command
				{
					CommandKey = 6
				},
				new Command
				{
					CommandKey = 3
				},
				new Command
				{
					CommandKey = 5
				}
			};
	        serviceProvider.GetValidDressCode(input);
			Console.WriteLine("Welcome to Docusign Project");
	        Console.ReadKey();
        }
    }
}
