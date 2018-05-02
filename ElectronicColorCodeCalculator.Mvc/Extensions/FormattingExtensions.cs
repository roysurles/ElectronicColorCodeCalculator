using ElectronicColorCodeCalculator.Core.Models.ColorCodeBand;
using System;
using System.Linq;
using System.Net;

namespace ElectronicColorCodeCalculator.Mvc.Extensions
{
    public static class FormattingExtensions
    {
        public const string WhiteSpaceString = " ";
        public const string HtmlWhiteSpaceString = "&nbsp;";
        public const string PlusMinusString = "\u00B1";
        public const string OhmSignString = "\u2126";
        public const string MultiplyString = "x";
        public const string OhmString = "Ohms";
        public const string KiloSuffixString = "k";
        public const string MegaSuffixString = "M";
        public const string GigaSuffixString = "G";
        public const string NumberFormatString = "#,##0.###";
        public const string PercentFormatString = "#,##0.###%";
        public const string TwentyPercentPlusMinusToleranceString = PlusMinusString + "20%";

        public static string ToFormattedNameWithSignificantFigureHtml(this IColorCodeBandModel model) =>
            WebUtility.HtmlDecode($"{model.Name.PadRight(19)}{model.SignificantFigure}".Replace(WhiteSpaceString, HtmlWhiteSpaceString));
        public static string ToFormattedMulitplierHtml(this IColorCodeBandModel model) =>
            WebUtility.HtmlDecode($"{model.Name.PadRight(9)}{string.Concat(MultiplyString, WhiteSpaceString, model.Multiplier.ToFormattedDecimalString(true), OhmSignString).PadLeft(11)}"
                .Replace(WhiteSpaceString, HtmlWhiteSpaceString));
        public static string ToFormattedToleranceHtml(this IColorCodeBandModel model) =>
            WebUtility.HtmlDecode($"{model.Name.PadRight(11)}{string.Concat(PlusMinusString, WhiteSpaceString, model.Tolerance.Value.ToString(PercentFormatString)).PadLeft(9)}".Replace(WhiteSpaceString, HtmlWhiteSpaceString));
        public static string ToFormattedOhmsResult(this decimal? decimalValue, string bandDColor, IFourColorCodeBandsViewModel fourColorCodeBandsViewModel)
        {
            // if no value then just return null
            if (!decimalValue.HasValue)
                return null;

            // if there is no selected bandDColor, then just return default of plus minus 20% 
            if (string.IsNullOrWhiteSpace(bandDColor))
                return string.Concat(decimalValue.ToFormattedDecimalString(), WhiteSpaceString, OhmString, WhiteSpaceString, TwentyPercentPlusMinusToleranceString);

            // try to get band D color from input; if not found, then throw exception since the user tried to submit -- this should not occur
            var bandDcolor = fourColorCodeBandsViewModel.BandDAvailableColors.FirstOrDefault(x => Equals(x.Name, bandDColor));
            if (bandDcolor == null)
                throw new InvalidOperationException($"{bandDColor} is not an available color for Band D.");

            // return the fully formatted string
            return string.Concat(decimalValue.ToFormattedDecimalString(), WhiteSpaceString, OhmString, WhiteSpaceString, bandDcolor.Tolerance.Value.ToString(PercentFormatString));
        }

        public static string ToFormattedDecimalString(this decimal? decimalValue, bool addSpaceBeforeSuffix = false)
        {
            if (!decimalValue.HasValue)
                return null;

            var resultString = string.Concat(decimalValue.Value.ToString(NumberFormatString), GetWhiteSpace(addSpaceBeforeSuffix));

            if (decimalValue >= 1_000)
                resultString = string.Concat((decimalValue / 1_000).Value.ToString(NumberFormatString), GetWhiteSpace(addSpaceBeforeSuffix), KiloSuffixString);

            if (decimalValue >= 1_000_000)
                resultString = string.Concat((decimalValue / 1_000_000).Value.ToString(NumberFormatString), GetWhiteSpace(addSpaceBeforeSuffix), MegaSuffixString);

            if (decimalValue >= 1_000_000_000)
                resultString = string.Concat((decimalValue / 1_000_000_000).Value.ToString(NumberFormatString), GetWhiteSpace(addSpaceBeforeSuffix), GigaSuffixString);

            return resultString;
        }
        public static string GetWhiteSpace(bool addWhiteSpace) =>
            addWhiteSpace
                ? WhiteSpaceString
                : string.Empty;
    }
}
