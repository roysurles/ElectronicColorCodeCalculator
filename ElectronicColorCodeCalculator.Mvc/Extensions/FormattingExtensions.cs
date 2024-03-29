﻿namespace ElectronicColorCodeCalculator.Mvc.Extensions;

public static class FormattingExtensions
{
    public static string WhiteSpaceString { get; } = " ";
    public static string HtmlWhiteSpaceString { get; } = "&nbsp;";
    public static string PlusMinusString { get; } = "\u00B1";
    public static string OhmSignString { get; } = "\u2126";
    public static string MultiplyString { get; } = "x";
    public static string OhmsString { get; } = "Ohms";
    public static string KiloSuffixString { get; } = "k";
    public static string MegaSuffixString { get; } = "M";
    public static string GigaSuffixString { get; } = "G";
    public static string NumberFormatString { get; } = "#,##0.###";
    public static string PercentFormatString { get; } = "#,##0.###%";
    public static string TwentyPercentPlusMinusToleranceString { get; } = $"{PlusMinusString} 20%";

    public static string ToFormattedNameWithSignificantFigureHtml(this IColorCodeBandModel model) =>
        WebUtility.HtmlDecode($"{model.Name.PadRight(19)}{model.SignificantFigure}".Replace(WhiteSpaceString, HtmlWhiteSpaceString));
    public static string ToFormattedMulitplierHtml(this IColorCodeBandModel model) =>
        WebUtility.HtmlDecode($"{model.Name.PadRight(9)}{string.Concat(MultiplyString, WhiteSpaceString, model.Multiplier.ToFormattedDecimalString(true), OhmSignString).PadLeft(11)}"
            .Replace(WhiteSpaceString, HtmlWhiteSpaceString));
    public static string ToFormattedToleranceHtml(this IColorCodeBandModel model) =>
        WebUtility.HtmlDecode($"{model.Name.PadRight(11)}{string.Concat(PlusMinusString, WhiteSpaceString, model.Tolerance.Value.ToString(PercentFormatString)).PadLeft(9)}".Replace(WhiteSpaceString, HtmlWhiteSpaceString));
    public static string ToFormattedOhms(this decimal? decimalValue, string bandDColor, IFourColorCodeBandsViewModel fourColorCodeBandsViewModel)
    {
        // if no value then just return null
        if (!decimalValue.HasValue)
            return null;

        // if there is no selected bandDColor, then just return default of plus minus 20%
        if (string.IsNullOrWhiteSpace(bandDColor))
            return string.Concat(decimalValue.ToFormattedDecimalString(), WhiteSpaceString, OhmsString, WhiteSpaceString, TwentyPercentPlusMinusToleranceString);

        // try to get band D color from input; if not found, then throw exception since the user tried to submit -- this should not occur
        var bandDcolor = fourColorCodeBandsViewModel.BandDAvailableColors.FirstOrDefault(x => string.Equals(x.Name, bandDColor, StringComparison.OrdinalIgnoreCase));
        if (bandDcolor == null)
            throw new InvalidOperationException($"{bandDColor} is not an available color for Band D.");

        // return the fully formatted string
        return string.Concat(decimalValue.ToFormattedDecimalString(), WhiteSpaceString, OhmsString, WhiteSpaceString, bandDcolor.Tolerance.Value.ToString(PercentFormatString));
    }

    public static string ToFormattedDecimalString(this decimal? decimalValue, bool addSpaceBeforeSuffix = false)
    {
        if (!decimalValue.HasValue)
            return null;

        if (decimalValue >= 1_000_000_000)
            return string.Concat((decimalValue / 1_000_000_000).Value.ToString(NumberFormatString), GetWhiteSpace(addSpaceBeforeSuffix), GigaSuffixString);

        if (decimalValue >= 1_000_000)
            return string.Concat((decimalValue / 1_000_000).Value.ToString(NumberFormatString), GetWhiteSpace(addSpaceBeforeSuffix), MegaSuffixString);

        if (decimalValue >= 1_000)
            return string.Concat((decimalValue / 1_000).Value.ToString(NumberFormatString), GetWhiteSpace(addSpaceBeforeSuffix), KiloSuffixString);

        return string.Concat(decimalValue.Value.ToString(NumberFormatString), GetWhiteSpace(addSpaceBeforeSuffix));
    }
    public static string GetWhiteSpace(bool addWhiteSpace) =>
        addWhiteSpace
            ? WhiteSpaceString
            : string.Empty;
}
