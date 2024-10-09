using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour 
{
    public int life = 15;
    public float speed = 1f;
    public bool zAxis = false;
    private float xMin = -2.7f, xMax = 2.7f;


    private void Update()
    {
        float movement = (speed * Input.GetAxisRaw("Horizontal") * Time.deltaTime);
        transform.Translate(1 * movement, 0, 0);
        transform.position = new Vector3((Mathf.Clamp(transform.position.x, xMin, xMax)), transform.position.y, transform.position.z);
    }
}
