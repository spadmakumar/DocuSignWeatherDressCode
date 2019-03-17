using System;
using DocuSign.WeatherDressCode.Services.Models;

namespace DocuSign.WeatherDressCode.Services.Services
{
    public interface IWeatherDressCodeSequencingService
    {
	    DressCodeResponse GetValidDressCode(InputDressCodeSequence input);
    }
}
