using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRotation : MonoBehaviour
{
    public Transform target;
    public Quaternion offset;

    public bool setOffset;
    public bool FixedUpdate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        if (setOffset)
        {
            offset = target.rotation * Quaternion.Inverse(transform.rotation);
            //offset = target.position - transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (FixedUpdate) return;
        //transform.position = target.position - offset;

        transform.rotation = target.rotation * Quaternion.Inverse(offset);
    }
}
