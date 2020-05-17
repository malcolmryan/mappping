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

    public override string ToString() => $"({x}, {y})";
}
}