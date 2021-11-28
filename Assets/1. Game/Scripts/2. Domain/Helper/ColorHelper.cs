using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorHelper 
{
    private static int HexToDec(string hex)
    {
        return System.Convert.ToInt32(hex, 16);
    }

    private static float HextoFloatNormalized(string hex)
    {
        return HexToDec(hex) / 225f;
    }

    public static Color GetColorFromString(string hexString)
    {
        float red = HextoFloatNormalized(hexString.Substring(0, 2));
        float green = HextoFloatNormalized(hexString.Substring(2, 2));
        float blue = HextoFloatNormalized(hexString.Substring(4, 2));
        return new Color(red, green, blue);
    }
}
