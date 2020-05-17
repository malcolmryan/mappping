using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WordsOnPlay.Utils {
public struct IVector2  {

    public int x;
    public int y;

    public IVector2(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public IVector2(float x, float y) {
        this.x = Mathf.FloorToInt(x);
        this.y = Mathf.FloorToInt(y);
    }

    public IVector2(Vector2 v) {
        this.x = Mathf.FloorToInt(v.x);
        this.y = Mathf.FloorToInt(v.y);
    }

    public static bool operator ==(IVector2 iv1, IVector2 iv2) {
        return iv1.Equals(iv2);
    }
    public static bool operator !=(IVector2 iv1, IVector2 iv2) {
        return !iv1.Equals(iv2);
    }

    override public bool Equals(object o) {
        IVector2 iv = (IVector2)o;
        return (iv.x == x) && (iv.y == y);
    }

    public override string ToString() => $"({x}, {y})";
}
}