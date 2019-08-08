using Avanade.HackathonAzul.DaniBot;
using Newtonsoft.Json;

namespace Microsoft.Bot.Builder.Dialogs
{
    public static class WaterfallStepContextExtensions
    {
        public static object GetHiddenDataValue(this WaterfallStepContext stepContext)
        {
            string hiddenValueString = stepContext.Context.Activity.Value.ToString();
            HiddenDataObject hiddenData = JsonConvert.DeserializeObject<HiddenDataObject>(hiddenValueString);
            return hiddenData.HiddenValue;
        }

        public static T GetHiddenDataValue<T>(this WaterfallStepContext stepContext)
        {
            return (T)GetHiddenDataValue(stepContext);
        }
    }
}