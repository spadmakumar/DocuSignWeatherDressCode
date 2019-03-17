using DocuSign.WeatherDressCode.Services.RuleBook;
using DocuSign.WeatherDressCode.Services.RuleBook.HotValidDressSequences;
using DocuSign.WeatherDressCode.Services.Services;
using SimpleInjector;

namespace DocuSignProject
{
    public static class DIHelper
    {
		public static void Register(Container container)
		{
			container.Register<IRuleBook, RuleBook>();
			container.Register<IWeatherDressCodeSequencingService, WeatherDressCodeSequencingService>();
			container.Collection.Register<IHotDressValidations>(
				typeof(HotDressValidation1),
				typeof(HotDressValidation2),
				typeof(HotDressValidation3));
		}

		public static void RegisterSingleton(Container container)
		{

		}
	}
}
