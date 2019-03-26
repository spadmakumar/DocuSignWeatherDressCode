using DocuSign.WeatherDressCode.Services.Models;
using DocuSign.WeatherDressCode.Services.RuleBook.ColdValidDressSequences;
using DocuSign.WeatherDressCode.Services.RuleBook.HotValidDressSequences;
using DocuSign.WeatherDressCode.Services.Singleton;

namespace DocuSign.WeatherDressCode.Services.RuleBook.CommonValidations
{
    public class PyjamaValidation : IHotDressValidations,IColdDressValidations
    {
		private static int _removePyjamaCommand;
	    public PyjamaValidation()
	    {
		    CreateValidationList();
	    }
	    public void Validate(InputDressCodeSequence input)
	    {
		    if (input?.Commands[0].CommandKey != _removePyjamaCommand)
		    {
			    foreach (var command in input?.Commands)
			    {
				    command.IsInvalid = true;
				    return;
			    }
		    }
	    }

		private static void CreateValidationList()
	    {
		    var data = WeatherDrivenDressCodeData.Instance.InstructionsData;
		    if (data.Find(v => v.Command == 8).Description == Enums.DressCodeDescription.TakeOffPajamas)
		    {
			    _removePyjamaCommand = data.Find(v => v.Command == 8).Command;
		    }
	    }
	}
}
