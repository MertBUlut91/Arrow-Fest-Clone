using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArrowController : MonoBehaviour
{
    public float movementSpeed = 15.0f;
    public float leftRightSpeed = 30.0f;
    private float xBlock = 7.0f;


    void Update()
    {
        if (Input.GetAxis("Mouse X") < 0)
        {
            transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
        }
        if (Input.GetAxis("Mouse X") > 0)
        {
            transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
        }
        if (transform.position.x >= xBlock)
        {
            transform.position = new Vector3(xBlock, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= -xBlock)
        {
            transform.position = new Vector3(-xBlock, transform.position.y, transform.position.z);
        }

        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
    }

}
