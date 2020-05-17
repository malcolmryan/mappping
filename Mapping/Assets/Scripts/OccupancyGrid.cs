using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WordsOnPlay.Utils;

[System.Serializable]
public class OccupancyGrid {
    public int size = 1024;
    public Rect rect;

    public float logOddsEmpty = 1;
    public float logOddsFull = 1;
    
    private float[,] occupancy;

    public OccupancyGrid(int size, Rect rect) {
        this.size = size;
        this.rect = rect;
        occupancy = new float[size,size];
    }

    private void SetOccupied(IVector2 ij, bool occupied) {
        if (ij.x >= 0 && ij.x < size && ij.y >= 0 && ij.y < size) {
            if (occupied) {
                occupancy[ij.x,ij.y] += logOddsFull;
            }
            else {
                occupancy[ij.x,ij.y] -= logOddsEmpty;
            }
        }
    }

    public void Update(Vector2 start, Vector2 end, bool hit) {
        start = rect.InversePoint(start);
        end = rect.InversePoint(end);

        Vector2 p = start;
        IVector2 ij = new IVector2(p);
        IVector2 stop = new IVector2(end);

        Vector2 d = end - start;
        int dx = (int)Mathf.Sign(d.x);
        int dy = (int)Mathf.Sign(d.y);

        while (ij != stop) {
            SetOccupied(ij, false);

            float dh = Mathf.Abs(ij.x + dx - p.x);
            float dv = Mathf.Abs(ij.y + dy - p.y);

            if (dv * d.x < dh * d.y) {
                ij.y += dy;
            }
            else {
                ij.x += dx;
            }
        }

        // update the endpoint
        SetOccupied(stop, hit);
    }

    public void Render(Texture2D texture) {
        for (int i = 0; i < size; i++) {
            for (int j = 0; j < size; j++) {
                float p = Mathf.Exp(occupancy[i,j]);
                p = p / (1+p);
                Color c = new Color(p,p,p);
                texture.SetPixel(i,j,c);
            }            
        }
        texture.Apply();
    }

}
