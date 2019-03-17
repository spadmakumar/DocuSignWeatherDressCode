﻿namespace DocuSign.WeatherDressCode.Services.Models
{
    public class WeatherDressCodeInstruction
    {
	    public int Command { get; set; }
	    public Enums.DressCodeDescription Description { get; set; }
	    public string HotResponse { get; set; }
	    public string ColdResponse { get; set; }
	}
}
