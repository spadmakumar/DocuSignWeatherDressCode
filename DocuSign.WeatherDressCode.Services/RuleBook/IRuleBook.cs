using System;
using System.Collections.Generic;
using System.Text;
using DocuSign.WeatherDressCode.Services.Models;

namespace DocuSign.WeatherDressCode.Services.RuleBook
{
    public interface IRuleBook
    {
	    void ValidColdDressSequences(InputDressCodeSequence input);
	    void ValidHotDressSequences(InputDressCodeSequence input);
    }
}
