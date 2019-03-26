using System;
using System.Collections.Generic;
using System.Text;
using DocuSign.WeatherDressCode.Services.Models;
using DocuSign.WeatherDressCode.Services.Singleton;

namespace DocuSign.WeatherDressCode.Services.RuleBook.HotValidDressSequences
{
    public class ShirtBeforeHeadwearValidation : IHotDressValidations
    {
	    private static int _putOnShirtCommand;
	    private static int _putOnHeadWear;
		public ShirtBeforeHeadwearValidation()
	    { 
		    CreateValidationList();
	    }
		public void Validate(InputDressCodeSequence input)
	    {
		    var checkList = new List<int>();
			foreach (var command in input.Commands)
			{
				if (command.CommandKey == _putOnHeadWear)
				{
					if (!checkList.Exists(x => x == _putOnShirtCommand))
					{
						command.IsInvalid = true;
						return;
					}
				}

				checkList.Add(command.CommandKey);
			}
		}

	    private static void CreateValidationList()
	    {
		    var data = WeatherDrivenDressCodeData.Instance.InstructionsData;

		    if (data.Find(v => v.Command == 4).Description == Enums.DressCodeDescription.PutOnShirt)
		    {
			    _putOnShirtCommand = data.Find(v => v.Command == 4).Command;
		    }

		    if (data.Find(v => v.Command == 2).Description == Enums.DressCodeDescription.PutOnHeadwear)
		    {
			    _putOnHeadWear = data.Find(v => v.Command == 2).Command;
		    }
		}
	}
}
