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

	    public enum DressCodeDescription
	    {
		    [Description("Put on footwear")] PutOnFootwear = 1,
		    [Description("Put on headwear")] PutOnHeadwear = 2,
		    [Description("Put on socks")] PutOnSocks = 3,
		    [Description("Put on shirt")] PutOnShirt = 4,
		    [Description("Put on jacket")] PutOnJacket = 5,
		    [Description("Put on pants")] PutOnPants = 6,
		    [Description("Leave house")] LeaveHouse = 7,
		    [Description("Take off pajamas")] TakeOffPajamas = 8

		}
	}
}
