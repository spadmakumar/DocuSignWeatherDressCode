using System.Collections.Generic;
using DocuSign.WeatherDressCode.Services.Models;
using DocuSign.WeatherDressCode.Services.RuleBook;
using DocuSign.WeatherDressCode.Services.Singleton;

namespace DocuSign.WeatherDressCode.Services.Services
{
	public class WeatherDressCodeSequencingService : IWeatherDressCodeSequencingService
	{
		private readonly IRuleBook _ruleBook;
		private readonly WeatherDrivenDressCodeData _weatherDrivenDressCodeData;

		public WeatherDressCodeSequencingService(IRuleBook ruleBook)
		{
			_ruleBook = ruleBook;
			_weatherDrivenDressCodeData = WeatherDrivenDressCodeData.Instance;
		}

		public DressCodeResponse GetValidDressCode(InputDressCodeSequence input)
		{
			var response = new DressCodeResponse();
			switch (input.Code)
			{
				case Enums.TempCode.Hot:
					_ruleBook.ValidHotDressSequences(input);
					GetResponseListForHotTemp(input,response);
					return response;
				case Enums.TempCode.Cold:
					_ruleBook.ValidColdDressSequences(input);
					GetResponseListForColdTemp(input, response);
					return response;
				default:
					response.ResponseList = new List<string>();
					response.ResponseList.Add("fail");
					return response;
			}
		}

		private void GetResponseListForHotTemp(InputDressCodeSequence input,DressCodeResponse response)
		{
			response.ResponseList = new List<string>();
			foreach (var command in input.Commands)
			{
				if (!command.IsInvalid)
				{
					response.ResponseList.Add(_weatherDrivenDressCodeData.InstructionsData
						.Find(v => v.Command == command.CommandKey).HotResponse);
				}
				else
				{
					response.ResponseList.Add("fail");
					return;
				}
			}
		}

		private void GetResponseListForColdTemp(InputDressCodeSequence input, DressCodeResponse response)
		{
			response.ResponseList = new List<string>();
			foreach (var command in input.Commands)
			{
				if (!command.IsInvalid)
				{
					response.ResponseList.Add(_weatherDrivenDressCodeData.InstructionsData
						.Find(v => v.Command == command.CommandKey).ColdResponse);
				}
				else
				{
					response.ResponseList.Add("fail");
					return;
				}
			}
		}
	}
}
