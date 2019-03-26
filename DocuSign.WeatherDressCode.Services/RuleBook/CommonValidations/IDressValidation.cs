using DocuSign.WeatherDressCode.Services.Models;

namespace DocuSign.WeatherDressCode.Services.RuleBook.CommonValidations
{
    public interface IDressValidation
    {
	    void Validate(InputDressCodeSequence input);
	}
}
