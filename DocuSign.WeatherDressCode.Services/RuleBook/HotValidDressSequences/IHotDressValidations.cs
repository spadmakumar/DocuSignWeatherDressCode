using System;
using System.Collections.Generic;
using System.Text;
using DocuSign.WeatherDressCode.Services.Models;

namespace DocuSign.WeatherDressCode.Services.RuleBook.HotValidDressSequences
{
    public interface IHotDressValidations
    {
	    void Validate(InputDressCodeSequence input);
    }
}
