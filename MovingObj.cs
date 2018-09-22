using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObj : MonoBehaviour



{
    private Vector3 pos1 = new Vector3(20.0f, 1.0f, 0f);
    private Vector3 pos2 = new Vector3(35.5f, 1.0f, 0f);
    public float speed = 1.0f;

   

    void Update()
    {
        transform.position = new Vector3(27.7f, 0.44f, -6.5f);

        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}
