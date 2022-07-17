using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rotaion = transform.localRotation;
        rotaion.x += 0.05f * -Input.GetAxis("Mouse Y");
        if (rotaion.x > 0.3f)
            rotaion.x = 0.3f;
        else if (rotaion.x < -0.6f)
            rotaion.x = -0.6f;
        rotaion.y = 0;
        rotaion.z = 0;
        transform.localRotation = rotaion;
           
    }
}
