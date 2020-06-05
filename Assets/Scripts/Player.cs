using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody body;
    public float maxVel;
    public Vector3 input; //input
    public bool space;

    public Vector2 mouseInput;
    public Vector2 sensitivity = Vector2.one;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 vel = body.velocity;
        Vector3 targetVel = input * maxVel;
        Vector3 diff = targetVel - vel;
        diff.y = 0f; //we ignore the y component because we assume that is the gravity

        body.AddForce(diff * body.mass / Time.fixedDeltaTime);

        //mouseInput.x * sensitivity.y
        //-mouseInput.y * sensitivity.x
        Vector3 rot = new Vector3(0f, mouseInput.x * sensitivity.x, 0f) * Time.fixedDeltaTime;
        rot = Quaternion.Inverse(transform.rotation) * rot;
        //rot.y = mouseInput.x * sensitivity.y * Time.fixedDeltaTime;
        rot.x = -mouseInput.y * sensitivity.y * Time.fixedDeltaTime;
        Quaternion q = Quaternion.Euler(rot);
        body.MoveRotation(transform.rotation * q); // rotate to the given rotation
    }

    private void Update()
    {
        if (space) Jump(2f);
    }

    void Jump(float height)
    {
        Vector3 vel = body.velocity;
        vel.x = 0f;
        vel.z = 0f;


        body.AddForce(-(Physics.gravity + vel/Time.fixedDeltaTime + (Vector3.up * height)/Time.fixedDeltaTime) * body.mass);
    }

}
