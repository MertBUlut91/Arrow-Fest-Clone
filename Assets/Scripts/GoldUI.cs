using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GoldUI : MonoBehaviour
{
    Transform panel;
    Sequence goldAnimation;

    void Start()
    {
        AnimationStart();
    }

    void AnimationStart()
    {
        panel = GameObject.FindGameObjectWithTag("GoldPanel").transform;
        goldAnimation = DOTween.Sequence();

        goldAnimation.Append(transform.DOMove(panel.position, 2)
            .SetEase(Ease.OutBounce))
            .OnComplete(()=>Destroy(gameObject));
    }
}
