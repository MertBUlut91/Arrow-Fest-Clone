using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Walls : MonoBehaviour
{
    public MeshRenderer mr;
    Color c;

    void Start()
    {
        Animate();
    }
    void Animate()
    {
        c = GetRandomColor();
        mr.material
            .DOColor(c, 5f)
            .OnComplete(Animate);
    }
    Color GetRandomColor()
    {
        return new Color (Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f),1f);
    }
}
