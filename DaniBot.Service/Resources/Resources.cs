using Avanade.HackathonAzul.DaniBot.Localization;
using System;

public static class Resources
{
    public static Localization Messages { get => LocalizationProvider.Instance.GetLocalization(); }
}