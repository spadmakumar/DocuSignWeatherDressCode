using System;
using System.Collections.Generic;
using System.Text;
using DocuSign.WeatherDressCode.Services.Models;
using DocuSign.WeatherDressCode.Services.RuleBook;
using DocuSign.WeatherDressCode.Services.RuleBook.HotValidDressSequences;

namespace DocuSign.WeatherDressCode.Services.Services
{
	public class WeatherDressCodeSequencingService : IWeatherDressCodeSequencingService
	{
		private readonly IRuleBook _ruleBook;

		public WeatherDressCodeSequencingService(IRuleBook ruleBook)
		{
			_ruleBook = ruleBook;
		}

		public DressCodeResponse GetValidDressCode(InputDressCodeSequence input)
		{
			var response = new DressCodeResponse();
			switch (input.Code)
			{
				case Enums.TempCode.Hot:
					_ruleBook.ValidHotDressSequences(input);
					return response;
				case Enums.TempCode.Cold:
					return response;
				default:
					response.ResponseList.Add("fail");
					return response;
			}
		}
	}
}
