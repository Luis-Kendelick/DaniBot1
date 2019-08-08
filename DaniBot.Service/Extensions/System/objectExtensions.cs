using Avanade.HackathonAzul.DaniBot;

namespace System
{
    public static class objectExtensions
    {
        public static HiddenDataObject CreateHiddenData(this object objectData)
        {
            return new HiddenDataObject { HiddenValue = objectData };
        }
    }
}