using System;
using System.Collections.Generic;
using System.Text;
using DocuSign.WeatherDressCode.Services.Models;
using DocuSign.WeatherDressCode.Services.Singleton;

namespace DocuSign.WeatherDressCode.Services.RuleBook.HotValidDressSequences
{
    public class HotDressValidation2 : IHotDressValidations
	{
		private static IList<int> _mustIncludeCommands = new List<int>();
		public HotDressValidation2()
		{
			CreateValidationList();
		}
		public void Validate(InputDressCodeSequence input)
	    {
			foreach (var command in input.Commands)
		    {
			    if (!_mustIncludeCommands.Contains(command.CommandKey))
			    {
				    command.IsInvalid = true;
				    return;
			    }
		    }

		    return;
	    }


		private static void CreateValidationList()
		{
			var data = WeatherDrivenDressCodeData.Instance.InstructionsData;
			if (data.Find(v => v.Command == 8).Description == Enums.DressCodeDescription.TakeOffPajamas)
			{
				_mustIncludeCommands.Add(data.Find(v => v.Command == 8).Command);
			}

			if (data.Find(v => v.Command == 6).Description == Enums.DressCodeDescription.PutOnPants)
			{
				_mustIncludeCommands.Add(data.Find(v => v.Command == 6).Command);
			}

			if (data.Find(v => v.Command == 4).Description == Enums.DressCodeDescription.PutOnShirt)
			{
				_mustIncludeCommands.Add(data.Find(v => v.Command == 4).Command);
			}

			if (data.Find(v => v.Command == 2).Description == Enums.DressCodeDescription.PutOnHeadwear)
			{
				_mustIncludeCommands.Add(data.Find(v => v.Command == 2).Command);
			}

			if (data.Find(v => v.Command == 1).Description == Enums.DressCodeDescription.PutOnHeadwear)
			{
				_mustIncludeCommands.Add(data.Find(v => v.Command == 1).Command);
			}

			if (data.Find(v => v.Command == 7).Description == Enums.DressCodeDescription.LeaveHouse)
			{
				_mustIncludeCommands.Add(data.Find(v => v.Command == 7).Command);
			}
		}
	}
}
