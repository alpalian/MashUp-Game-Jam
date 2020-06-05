using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public bool on;
    public Vector3 input;
    public Vector2 mouseInput;
    public bool space;

    public Player avatar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!on) return;

        input.x = Input.GetAxisRaw("Horizontal");
        input.z = Input.GetAxisRaw("Vertical");
        input.y = 0f;

        input = Vector3.ClampMagnitude(input, 1f);

        //mouse input
        mouseInput.x = Input.GetAxis("Mouse X");
        mouseInput.y = Input.GetAxis("Mouse Y");

        space = Input.GetKeyDown(KeyCode.Space);


        if (avatar != null)
        {
            avatar.input = input;
            avatar.mouseInput = mouseInput;
            avatar.space = space;
        }
    }
}
