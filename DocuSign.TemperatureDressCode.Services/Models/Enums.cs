using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DocuSign.WeatherDressCode.Services.Models
{
    public class Enums
    {
	    public enum TempCode
	    {
		    [Description("Hot")] Hot = 1,
		    [Description("Cold")] Cold = 2
	    }
	}
}
