using System.Collections.Generic;
using System.Linq;
using DocuSign.WeatherDressCode.Services.Models;
using DocuSign.WeatherDressCode.Services.RuleBook.ColdValidDressSequences;
using DocuSign.WeatherDressCode.Services.RuleBook.HotValidDressSequences;

namespace DocuSign.WeatherDressCode.Services.RuleBook.CommonValidations
{
    public class Duplicates : IHotDressValidations, IColdDressValidations
	{
	    public void Validate(InputDressCodeSequence input)
	    {
			var checkList = new List<int>();
		    foreach (var command in input.Commands)
		    {
			    checkList.Add(command.CommandKey);
			    if (checkList.GroupBy(x => x).Any(g => g.Count() > 1))
			    {
				    command.IsInvalid = true;
			    }
		    }
	    }
	}
}

