using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperScript : MonoBehaviour
{
    MeshRenderer renderer;
    Rigidbody rigidbody;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        rigidbody = GetComponent<Rigidbody>();

        renderer.enabled = false;
        rigidbody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < 3)
        {
            timer += Time.deltaTime;
        }
        else
        {
            renderer.enabled = true;
            rigidbody.useGravity = true;

            timer = 0;
        }
    }
}
