using System;
using System.Collections.Generic;
using System.Text;

namespace DocuSign.WeatherDressCode.Services.Models
{
    public class InputDressCodeSequence
    {
	    public Enums.TempCode Code { get; set; }
	    public List<int> Commands { get; set; }
    }
}
