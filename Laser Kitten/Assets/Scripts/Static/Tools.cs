using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tools
{
    public static int BoolToInt(bool boolian)
    {
        if (boolian) return 1;
        else return 0;
    }
    public static bool IntToBool(int integer)
    {
        if (integer == 0) return false;
        else return true;
    }
}
