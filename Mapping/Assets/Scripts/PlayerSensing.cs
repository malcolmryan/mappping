using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WordsOnPlay.Utils;

public class PlayerSensing : MonoBehaviour
{
    private const float TAU = Mathf.PI * 2;

    public float sightRadius = 10;
    
    public int nSightRays = 100;
    public LayerMask wallLayer;

    private float[] rays;
    private bool[] hit;

    void Start() {
        rays = new float[nSightRays];
        hit = new bool[nSightRays];
    }

    void Update() {
        for (int i = 0; i < nSightRays; i++) {
            float angle = i * 360f / nSightRays;

            Vector2 dir = Vector2.right.Rotate(angle);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, sightRadius, wallLayer.value); 

            if (hit.collider == null) {
                this.rays[i] = sightRadius;
                this.hit[i] = false;
            }
            else {
                this.rays[i] = hit.distance;
                this.hit[i] = true;
            }

        }        
    }


    void OnDrawGizmos() {
        if (!Application.isPlaying) {
            return;
        }

        for (int i = 0; i < nSightRays; i++) {
            float angle = i * 360f / nSightRays;
            Vector3 dir = Vector2.right.Rotate(angle);

            Gizmos.color = (hit[i] ? Color.red : Color.green);
            Gizmos.DrawLine(transform.position, transform.position + dir * rays[i]);
        }
    }
}
