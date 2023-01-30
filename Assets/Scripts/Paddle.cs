using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 2.0f;
    public float maxMovementOnXAxis = 2.0f;
    
 
    void Update()
    {
        float input = Input.GetAxis("Horizontal");

        Vector3 pos = transform.position;
        pos.x += input * speed * Time.deltaTime;

        if (pos.x > maxMovementOnXAxis)
            pos.x = maxMovementOnXAxis;
        else if (pos.x < -maxMovementOnXAxis)
            pos.x = -maxMovementOnXAxis;

        transform.position = pos;
    }
}
