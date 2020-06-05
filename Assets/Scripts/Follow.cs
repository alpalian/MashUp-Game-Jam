using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    public bool setOffset;
    public bool FixedUpdate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        if(setOffset)
        {
            offset = target.position - transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (FixedUpdate) return;

        transform.position = target.position - offset;
    }
}
