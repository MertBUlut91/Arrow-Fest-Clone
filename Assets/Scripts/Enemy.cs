using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject arrow;
    public Transform arrowPoint;
    private Vector3 hitArea;
    public AudioClip coin;
    public GameObject effect;
    public GameObject goldPrefab;
    public GameObject panel;
    private bool die = false;

    private void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        hitArea = arrowPoint.transform.position;
        ArrowFest arrowObject;
        if (other.TryGetComponent<ArrowFest>(out arrowObject)|| other.CompareTag("Arrow")&&die==false)
        {
            die = true;
            GameObject Arrow = Instantiate(arrow, hitArea, Quaternion.Euler(new Vector3(0, 78, -80)), arrowPoint.parent);
            Instantiate(effect, hitArea, Quaternion.Euler(new Vector3(0, 78, -80)), arrowPoint.parent);
            Instantiate(goldPrefab, Camera.main.WorldToScreenPoint(transform.position), panel.transform.rotation, panel.transform);
            Arrow.transform.localScale = new Vector3(0.08f, 0.08f, 0.08f);
            GetComponent<Animator>().SetBool("die", true);
            AudioSource.PlayClipAtPoint(coin, transform.position);
            Data.coin += 10;
        }

    }
}
