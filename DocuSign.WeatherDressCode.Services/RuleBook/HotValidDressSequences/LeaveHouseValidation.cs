using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DocuSign.WeatherDressCode.Services.Models;
using DocuSign.WeatherDressCode.Services.Singleton;

namespace DocuSign.WeatherDressCode.Services.RuleBook.HotValidDressSequences
{
    public class LeaveHouseValidation : IHotDressValidations
	{
		private static IList<int> _commandsBeforeLeavingHouse = new List<int>();
		private static int _leavingHouseCommandKey;
		public LeaveHouseValidation()
		{
			CreateValidationList();
		}
		public void Validate(InputDressCodeSequence input)
	    {
		    if (input.Commands.Find(x => x.CommandKey == _leavingHouseCommandKey)!=null)
		    {
			    var checkList = new List<int>();
			    foreach (var command in input.Commands)
			    {
				    if (command.CommandKey == _leavingHouseCommandKey)
				    {
						command.IsInvalid = !_commandsBeforeLeavingHouse.All(itm2 => checkList.Contains(itm2));
					}
				    else
				    {
					    checkList.Add(command.CommandKey);
				    }
			    }
			}
	    }


		private static void CreateValidationList()
		{
			var data = WeatherDrivenDressCodeData.Instance.InstructionsData;
			if (data.Find(v => v.Command == 8).Description == Enums.DressCodeDescription.TakeOffPajamas)
			{
				_commandsBeforeLeavingHouse.Add(data.Find(v => v.Command == 8).Command);
			}

			if (data.Find(v => v.Command == 6).Description == Enums.DressCodeDescription.PutOnPants)
			{
				_commandsBeforeLeavingHouse.Add(data.Find(v => v.Command == 6).Command);
			}

			if (data.Find(v => v.Command == 4).Description == Enums.DressCodeDescription.PutOnShirt)
			{
				_commandsBeforeLeavingHouse.Add(data.Find(v => v.Command == 4).Command);
			}

			if (data.Find(v => v.Command == 2).Description == Enums.DressCodeDescription.PutOnHeadwear)
			{
				_commandsBeforeLeavingHouse.Add(data.Find(v => v.Command == 2).Command);
			}

			if (data.Find(v => v.Command == 1).Description == Enums.DressCodeDescription.PutOnFootwear)
			{
				_commandsBeforeLeavingHouse.Add(data.Find(v => v.Command == 1).Command);
			}

			if (data.Find(v => v.Command == 7).Description == Enums.DressCodeDescription.LeaveHouse)
			{
				_leavingHouseCommandKey = data.Find(v => v.Command == 7).Command;
			}
		}
	}
}
