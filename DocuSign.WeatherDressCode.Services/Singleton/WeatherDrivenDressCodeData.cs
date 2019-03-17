using System.Collections.Generic;
using DocuSign.WeatherDressCode.Services.Models;

namespace DocuSign.WeatherDressCode.Services.Singleton
{
    public sealed class WeatherDrivenDressCodeData
    {
	    private static volatile WeatherDrivenDressCodeData _instance;
	    private static List<WeatherDressCodeInstruction> _data;
		private static readonly object syncroot = new object();

	    private WeatherDrivenDressCodeData()
	    {
		    _data = GetTemperatureDressCodeData();
	    }

	    public List<WeatherDressCodeInstruction> InstructionsData => _data;

	    public static WeatherDrivenDressCodeData Instance
	    {
		    get
		    {
			    if (_instance == null)
			    {
				    lock (syncroot)
				    {
					    if (_instance == null)
						    _instance = new WeatherDrivenDressCodeData();
				    }
			    }

			    return _instance;
		    }
	    }

		private static List<WeatherDressCodeInstruction> GetTemperatureDressCodeData()
	    {
			var data = new List<WeatherDressCodeInstruction>
				{
					new WeatherDressCodeInstruction
					{
						Command = 1,
						Description = Enums.DressCodeDescription.PutOnFootwear,
						HotResponse = "sandals",
						ColdResponse = "boots"
					},
					new WeatherDressCodeInstruction
					{
						Command = 2,
						Description = Enums.DressCodeDescription.PutOnHeadwear,
						HotResponse = "sun visor",
						ColdResponse = "hat"
					},
					new WeatherDressCodeInstruction
					{
						Command = 3,
						Description = Enums.DressCodeDescription.PutOnSocks,
						HotResponse = "fails	",
						ColdResponse = "socks"
					},
					new WeatherDressCodeInstruction
					{
						Command = 4,
						Description = Enums.DressCodeDescription.PutOnShirt,
						HotResponse = "t-shirt",
						ColdResponse = "shirt"
					},
					new WeatherDressCodeInstruction
					{
						Command = 5,
						Description = Enums.DressCodeDescription.PutOnJacket,
						HotResponse = "fail",
						ColdResponse = "jacket"
					},
					new WeatherDressCodeInstruction
					{
						Command = 6,
						Description = Enums.DressCodeDescription.PutOnPants,
						HotResponse = "shorts",
						ColdResponse = "pants"
					},
					new WeatherDressCodeInstruction
					{
						Command = 7,
						Description = Enums.DressCodeDescription.LeaveHouse,
						HotResponse = "leaving house",
						ColdResponse = "leaving house"
					},
					new WeatherDressCodeInstruction
					{
						Command = 8,
						Description = Enums.DressCodeDescription.TakeOffPajamas,
						HotResponse = "Removing PJs",
						ColdResponse = "Removing PJs"
					}
			};

		    return data;
	    }

	}
}
