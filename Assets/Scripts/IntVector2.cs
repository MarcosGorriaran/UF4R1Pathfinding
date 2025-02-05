using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct IntVector2
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public IntVector2(int x, int y)
    {
        X = x;
        Y = y;
    }
}
