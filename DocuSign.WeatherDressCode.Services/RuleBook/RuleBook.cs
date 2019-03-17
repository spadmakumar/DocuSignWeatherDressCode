using System;
using System.Collections.Generic;
using System.Text;
using DocuSign.WeatherDressCode.Services.Models;
using DocuSign.WeatherDressCode.Services.RuleBook.HotValidDressSequences;

namespace DocuSign.WeatherDressCode.Services.RuleBook
{
    public class RuleBook : IRuleBook
    {
	    private readonly IEnumerable<IHotDressValidations> _hotDressValidations;
	    //private readonly IEnumerable<IColdDressValidations> _coldDressValidations;

		public RuleBook(IEnumerable<IHotDressValidations> hotDressValidations)
	    {
		    _hotDressValidations = hotDressValidations;

	    }
		public void ValidColdDressSequences(InputDressCodeSequence input)
	    {
		    throw new NotImplementedException();
	    }

	    public void ValidHotDressSequences(InputDressCodeSequence input)
	    {
		    foreach (var validation in _hotDressValidations)
		    {
			    validation.Validate(input);
		    }
		}
    }
}
