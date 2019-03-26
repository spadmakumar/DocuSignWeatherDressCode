using DocuSign.WeatherDressCode.Services.RuleBook;
using DocuSign.WeatherDressCode.Services.RuleBook.ColdValidDressSequences;
using DocuSign.WeatherDressCode.Services.RuleBook.CommonValidations;
using DocuSign.WeatherDressCode.Services.RuleBook.HotValidDressSequences;
using DocuSign.WeatherDressCode.Services.Services;
using SimpleInjector;

namespace DocuSignProject
{
    public static class DIHelper
    {
		public static void Register(Container container)
		{
			container.Collection.Register<IHotDressValidations>(
				typeof(HotClothingExclusions),
				typeof(LeaveHouseValidation),
				typeof(PyjamaValidation),
				typeof(PantsBeforeFootwearValidation),
				typeof(ShirtBeforeHeadwearValidation),
				typeof(Duplicates));
			container.Collection.Register<IColdDressValidations>(
				typeof(Duplicates),
				typeof(PyjamaValidation),
				typeof(ShirtBeforeHeadWearAndJacketValidation),
				typeof(PantsBeforeFootwearAndSocksValidation),
				typeof(LeaveHouseValidationCold));
			container.Register<IRuleBook, RuleBook>();
			container.Register<IWeatherDressCodeSequencingService, WeatherDressCodeSequencingService>();
		}
	}
}
