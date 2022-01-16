using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : SingletonScript<CameraController>
{
    public Transform target;
    public Vector3 offset;
    bool isPlaying = true;
    public static AudioSource camMusic;

    private void LateUpdate()
    {
        if (isPlaying)
        {
            Vector3 desiredPosition = target.position + offset;
            transform.position = desiredPosition;
            transform.LookAt(target);
        }

    }
    public void StopFollowing()
    {
        isPlaying = false;
    }
}
