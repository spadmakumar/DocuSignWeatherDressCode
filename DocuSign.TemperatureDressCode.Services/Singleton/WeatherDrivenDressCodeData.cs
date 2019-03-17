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
						Description = "Put on footwear",
						HotResponse = "sandals",
						ColdResponse = "boots"
					},
					new WeatherDressCodeInstruction
					{
						Command = 2,
						Description = "Put on headwear",
						HotResponse = "sun visor",
						ColdResponse = "hat"
					},
					new WeatherDressCodeInstruction
					{
						Command = 3,
						Description = "Put on socks",
						HotResponse = "fails	",
						ColdResponse = "socks"
					},
					new WeatherDressCodeInstruction
					{
						Command = 4,
						Description = "Put on shirt",
						HotResponse = "t-shirt",
						ColdResponse = "shirt"
					},
					new WeatherDressCodeInstruction
					{
						Command = 5,
						Description = "Put on jacket",
						HotResponse = "fail",
						ColdResponse = "jacket"
					},
					new WeatherDressCodeInstruction
					{
						Command = 6,
						Description = "Put on pants",
						HotResponse = "shorts",
						ColdResponse = "pants"
					},
					new WeatherDressCodeInstruction
					{
						Command = 7,
						Description = "Leave house",
						HotResponse = "leaving house",
						ColdResponse = "leaving house"
					},
					new WeatherDressCodeInstruction
					{
						Command = 8,
						Description = "Take off pajamas",
						HotResponse = "Removing PJs",
						ColdResponse = "Removing PJs"
					}
			};

		    return data;
	    }

	}
}
