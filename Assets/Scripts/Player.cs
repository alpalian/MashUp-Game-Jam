using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody body;
    public float maxVel;
    public Vector3 input; //input
    public bool space;

    public float jumpHeight = 2f;
    public Vector2 mouseInput;
    public Vector2 sensitivity = Vector2.one;

    public bool onGround = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        onGround = OnGround(0.45f, 0.2f);

        if (onGround)
        {
            Vector3 vel = body.velocity;
            Vector3 targetVel = Quaternion.AngleAxis(transform.rotation.eulerAngles.y, Vector3.up) * input; //rotate the input around the character's up vector
            targetVel = targetVel * maxVel; //make it the max velocity
            Vector3 diff = targetVel - vel;
            diff.y = 0f; //we ignore the y component because we assume that is the gravity

            body.AddForce(diff * body.mass / Time.fixedDeltaTime);
        }

        //mouseInput.x * sensitivity.y
        //-mouseInput.y * sensitivity.x
        Vector3 rot = new Vector3(0f, mouseInput.x * sensitivity.x, 0f) * Time.fixedDeltaTime;
        rot = Quaternion.Inverse(transform.rotation) * rot;
        //rot.y = mouseInput.x * sensitivity.y * Time.fixedDeltaTime;
        rot.x = -mouseInput.y * sensitivity.y * Time.fixedDeltaTime;
        Quaternion q = Quaternion.Euler(rot);
        body.MoveRotation(transform.rotation * q); // rotate to the given rotation
    }

    public bool OnGround(float radius = 1f, float height = 0.1f)
    {
        bool onGround = false;
        RaycastHit hit;
        onGround = Physics.SphereCast(transform.position, radius, Vector3.down, out hit, height);
        //if (onGround) //Debug.Log(hit.transform.name);
        return onGround;
    }

    private void Update()
    {
        if (space) Jump(jumpHeight);
    }

    void Jump(float height)
    {
        Vector3 vel = body.velocity;
        vel.x = 0f;
        vel.z = 0f;


        //body.AddForce(-(Physics.gravity + vel/Time.fixedDeltaTime + (height*Vector3.up - Physics.gravity/2f) / Time.fixedDeltaTime) * body.mass);
        body.AddForce((height * Vector3.up - Physics.gravity*0.5f) / Time.fixedDeltaTime * body.mass);
    }

}
