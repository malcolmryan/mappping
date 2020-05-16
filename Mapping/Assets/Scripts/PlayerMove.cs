using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    new private Rigidbody2D rigidbody;

    public float speed = 5;
    public float sightRadius = 10;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v;
        v.x = Input.GetAxis("Horizontal");
        v.y = Input.GetAxis("Vertical");

        v = v.normalized * Mathf.Max(Mathf.Abs(v.x), Mathf.Abs(v.y));

        rigidbody.velocity = v * speed;        
    }
}
