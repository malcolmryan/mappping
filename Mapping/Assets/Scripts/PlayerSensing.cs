using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WordsOnPlay.Utils;

public class PlayerSensing : MonoBehaviour
{
    private const float TAU = Mathf.PI * 2;

    public float sightRadius = 10;
    
    public int nSightRays = 10;
    public LayerMask wallLayer;

    void Update() {
        for (int i = 0; i < nSightRays; i++) {
            float angle = i * TAU / nSightRays;

            Vector2 dir = Vector2.right.Rotate(angle);
            Physics2D.Raycast(transform.position, dir, sightRadius, wallLayer.value); 
        }        
    }
}
