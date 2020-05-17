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

    private OccupancyGrid occupancy;

    public Rect rect;

    public Texture2D mapTexture;

    public Material mapMaterial;

    void Start() {
        rays = new float[nSightRays];
        hit = new bool[nSightRays];
        occupancy = new OccupancyGrid(1024, rect);
        mapTexture = new Texture2D(1024, 1024);
        mapMaterial.SetTexture("_Main", mapTexture);
    }

    void Update() {
        for (int i = 0; i < nSightRays; i++) {
            float angle = i * 360f / nSightRays;

            Vector2 dir = Vector2.right.Rotate(angle);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, sightRadius, wallLayer.value); 
            occupancy.Update(transform.position, hit.point, hit.collider != null);

            if (hit.collider == null) {
                this.rays[i] = sightRadius;
                this.hit[i] = false;
            }
            else {
                this.rays[i] = hit.distance;
                this.hit[i] = true;
            }

        }        

        occupancy.Render(mapTexture);
    }


    void OnDrawGizmos() {

        Gizmos.color = Color.yellow;
        rect.DrawGizmo();

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
