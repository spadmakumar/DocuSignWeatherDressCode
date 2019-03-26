using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DocuSign.WeatherDressCode.Services.Models;
using DocuSign.WeatherDressCode.Services.Singleton;

namespace DocuSign.WeatherDressCode.Services.RuleBook.HotValidDressSequences
{
    public class HotClothingExclusions : IHotDressValidations
	{
	    private static IList<int> _invalidCommands = new List<int>();
		public HotClothingExclusions()
		{
			CreateValidationList();
		}

	    public void Validate(InputDressCodeSequence input)
	    {
		    foreach (var command in input.Commands)
		    {
			    if (_invalidCommands.Contains(command.CommandKey))
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
		    if (data.Find(v => v.Command == 3).Description == Enums.DressCodeDescription.PutOnSocks)
		    {
			    _invalidCommands.Add(data.Find(v => v.Command == 3).Command);
		    }

		    if (data.Find(v => v.Command == 5).Description == Enums.DressCodeDescription.PutOnJacket)
		    {
			    _invalidCommands.Add(data.Find(v => v.Command == 5).Command);
			}
	    }
	}
}
