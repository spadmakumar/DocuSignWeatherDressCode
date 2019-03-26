using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Numerics;
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
	        container.Verify();

	        var serviceProvider = container.GetInstance<WeatherDressCodeSequencingService>();
			Console.WriteLine("Please enter Temp Code(Hot or Cold) and Dress code commands");
	        Input(serviceProvider);

	        Console.ReadKey();
        }

	    private static void Input(WeatherDressCodeSequencingService serviceProvider)
	    {
		    var userInput = Console.ReadLine();
		    var codeAndCommands = userInput?.Split(' ');
		    if (codeAndCommands != null)
		    {
			    var input = new InputDressCodeSequence {Commands = new List<Command>()};
			    foreach (var instruction in codeAndCommands)
			    {
				    switch (instruction.ToLower())
				    {
					    case "cold":
						    input.Code = Enums.TempCode.Cold;
						    continue;
					    case "hot":
						    input.Code = Enums.TempCode.Hot;
						    continue;
				    }

				    input.Commands.Add(new Command {CommandKey = Int32.Parse(instruction)});
			    }

			    var dressCodeResponse = serviceProvider.GetValidDressCode(input);
			    foreach (var response in dressCodeResponse.ResponseList)
			    {
				    Console.WriteLine(response);
			    }
		    }
		    Input(serviceProvider);
		}
    }
}
