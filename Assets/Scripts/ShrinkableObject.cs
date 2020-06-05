using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkableObject : MonoBehaviour
{
    // stuff to edit
    public float size;
    public float minSize;
    public float maxSize;

    // stuff to not edit
    public float density;
    public Rigidbody rb;


    public void ChangeObjectSize(int growOrShrink, float amount)
    /** growOrShrink = 1, GROW
     *  growOrShrink = -1, SHRINK
     **/
    {
        // check if goes beyond min/max size
        if (size + growOrShrink * amount < minSize) size = minSize;
        else if (size + growOrShrink * amount > maxSize) size = maxSize;
        else size += growOrShrink * amount;
        
        rb.mass = density * Mathf.Pow(size, 3f);

    }

    // check to see if the player is wanting to change object size
    public bool IsColliding()
    {
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // density = mass / size(volume) ^ 3
        density = rb.mass;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsColliding())
        {

        }
    }
}
