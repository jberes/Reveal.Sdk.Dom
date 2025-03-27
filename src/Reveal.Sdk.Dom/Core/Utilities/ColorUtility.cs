using System;
using System.Globalization;
using System.Text.RegularExpressions;

internal static class ColorUtility
{
    /// <summary>
    /// Converts a color string to an integer.
    /// Accepts:
    /// - Hex strings: #RRGGBB or #RRGGBBAA
    /// - RGB(A) strings: rgb(r, g, b) or rgba(r, g, b, a)
    /// </summary>
    public static int FromColorString(string color)
    {
        color = color.Trim();

        if (color.StartsWith("#"))
        {
            return HexColorToInt(color);
        }

        if (color.StartsWith("rgb", StringComparison.OrdinalIgnoreCase))
        {
            return RgbaStringToInt(color);
        }

        throw new ArgumentException($"Unsupported color format: {color}");
    }

    /// <summary>
    /// Converts an integer to a hex color string.
    /// Returns #RRGGBB if fully opaque, or #RRGGBBAA if alpha is less than 255.
    /// </summary>
    public static string IntToHexColorString(int argb)
    {
        uint uintColor = (uint)argb;

        byte a = (byte)((uintColor >> 24) & 0xFF);
        byte r = (byte)((uintColor >> 16) & 0xFF);
        byte g = (byte)((uintColor >> 8) & 0xFF);
        byte b = (byte)(uintColor & 0xFF);

        string rgbHex = $"#{r:X2}{g:X2}{b:X2}";

        return a < 255 ? $"{rgbHex}{a:X2}" : rgbHex;
    }

    /// <summary>
    /// Converts a hex color string to an integer.
    /// Accepts: #RRGGBB or #RRGGBBAA
    /// </summary>
    public static int HexColorToInt(string hex)
    {
        hex = hex.TrimStart('#');

        if (hex.Length == 6)
        {
            // #RRGGBB → assume alpha = 0xFF
            byte r = byte.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
            byte g = byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
            byte b = byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
            return (255 << 24) | (r << 16) | (g << 8) | b;
        }
        else if (hex.Length == 8)
        {
            // #RRGGBBAA
            byte r = byte.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
            byte g = byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
            byte b = byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
            byte a = byte.Parse(hex.Substring(6, 2), NumberStyles.HexNumber);
            return (a << 24) | (r << 16) | (g << 8) | b;
        }

        throw new ArgumentException($"Invalid hex color format: {hex}");
    }

    /// <summary>
    /// Converts an RGBA string to an integer.
    /// Accepts rgb(r, g, b) or rgba(r, g, b, a)
    /// </summary>
    public static int RgbaStringToInt(string rgba)
    {
        var match = Regex.Match(rgba, @"rgba?\(\s*(\d+)\s*,\s*(\d+)\s*,\s*(\d+)(?:\s*,\s*(\d*\.?\d+))?\s*\)", RegexOptions.IgnoreCase);

        if (!match.Success)
        {
            throw new ArgumentException($"Invalid rgba format: {rgba}");
        }

        byte r = byte.Parse(match.Groups[1].Value);
        byte g = byte.Parse(match.Groups[2].Value);
        byte b = byte.Parse(match.Groups[3].Value);
        byte a = match.Groups[4].Success ? (byte)Math.Round(float.Parse(match.Groups[4].Value, CultureInfo.InvariantCulture) * 255) : (byte)255;

        return (a << 24) | (r << 16) | (g << 8) | b;
    }
}
