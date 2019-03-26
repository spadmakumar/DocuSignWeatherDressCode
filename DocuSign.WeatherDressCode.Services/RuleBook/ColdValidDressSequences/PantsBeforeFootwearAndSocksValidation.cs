using System;
using System.Collections.Generic;
using System.Text;
using DocuSign.WeatherDressCode.Services.Models;
using DocuSign.WeatherDressCode.Services.Singleton;

namespace DocuSign.WeatherDressCode.Services.RuleBook.ColdValidDressSequences
{
    public class PantsBeforeFootwearAndSocksValidation : IColdDressValidations
    {
	    private static int _putOnPants;
	    private static int _putOnFootwear;
	    private static int _putOnSocks;
	    public PantsBeforeFootwearAndSocksValidation()
	    {
		    CreateValidationList();
	    }
		public void Validate(InputDressCodeSequence input)
	    {
		    var checkList = new List<int>();
			foreach (var command in input.Commands)
			{
				if (command.CommandKey == _putOnFootwear)
				{
					if (!checkList.Exists(x => x == _putOnPants) || !checkList.Exists(x => x == _putOnSocks))
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

		    if (data.Find(v => v.Command == 6).Description == Enums.DressCodeDescription.PutOnPants)
		    {
			    _putOnPants = data.Find(v => v.Command == 6).Command;
		    }

		    if (data.Find(v => v.Command == 1).Description == Enums.DressCodeDescription.PutOnFootwear)
		    {
			    _putOnFootwear = data.Find(v => v.Command == 1).Command;
		    }

		    if (data.Find(v => v.Command == 3).Description == Enums.DressCodeDescription.PutOnSocks)
		    {
			    _putOnSocks = data.Find(v => v.Command == 3).Command;
		    }
		}
	}
}
