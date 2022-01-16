using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.EditorCoroutines.Editor;
using UnityEngine.UI;
using DG.Tweening;



public class ArrowFest : MonoBehaviour
{
    public float movementSpeed = 15.0f;
    public float leftRightSpeed = 30.0f;
    public float speed = 2f;
    private float xBlock = 7.0f;
    bool finishMode = false;
    public List<GameObject> arrows = new List<GameObject>();
    public GameObject arrowObject;
    public Transform parent;
    public float minX, maxX;
    public LayerMask layerMask;
    public float distance;
    public float fdistance;
    private bool isDecrease = false;
    public Text counterText;
    bool moving = true;
    public AudioClip complate;
    AudioSource cameraAudioSource;


    [Range(0, 300)] public int arrowCount;


    void Start()
    {
        cameraAudioSource = Camera.main.gameObject.GetComponent<AudioSource>();
        CreateArrow();
    }

    void Update()
    {
        if (arrows.Count == 0)
        {
            Menus.Instance.OpenLostMenu();

        }
        if (moving)
        {
            Align();
        }
        else
        {
            FinishAlign();
        }

        if (Input.GetButton("Fire1"))
        {
        }
        counterText.text = arrows.Count.ToString();

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

    private void OnValidate()
    {
        if (arrowCount > arrows.Count && !isDecrease)
        {
            CreateArrow();
        }
        else if (arrowCount < arrows.Count)
        {
            isDecrease = true;
            DestroyArrow();
        }
        else
        {
            Align();
        }
    }
    IEnumerator DestroyObject(GameObject g)
    {
        yield return new WaitForEndOfFrame();
        DestroyImmediate(g);
    }
    void CreateArrow(int count = 1)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject g = Instantiate(arrowObject, parent);
            arrows.Add(g);
        }
    }
    void DestroyArrow(int count = 0, bool lostControl = true)
    {
        for (int i = 0; i < count; i++)
        {
            if (ControlLost(lostControl))
                return;
            GameObject g = arrows[arrows.Count - 1];
            arrows.RemoveAt(arrows.Count - 1);
            EditorCoroutineUtility.StartCoroutine(DestroyObject(g), this);
        }
        isDecrease = false;
        Align();
    }


    void MoveArrows(Transform objectTransform, float degree)
    {
        Vector3 pos = Vector3.zero;
        pos.x = Mathf.Cos(degree * Mathf.Deg2Rad);
        pos.y = Mathf.Sin(degree * Mathf.Deg2Rad);
        objectTransform.localPosition = pos * distance;

    }
    void Align()
    {
        float angel = 1f;
        float arrowCount = arrows.Count;
        angel = 360 / arrowCount;

        for (int i = 0; i < arrowCount; i++)
        {
            MoveArrows(arrows[i].transform, i * angel);
        }
    }
    void FinishMoveArrows(Vector3 Objectposition)
    {

    }
    void FinishAlign()
    {
        int arrowCount = arrows.Count;
        int line = 3;


        for (int i = 0; i < line; i++)
        {
            int x = 0;
            for (int b = (arrowCount / line) * i; b < ((arrowCount / line) * i) + (arrowCount / line); b++)
            {
                if (b % 2 == 0)
                {
                    FinishMoveArrows(arrows[b].transform.position = parent.transform.position + (parent.transform.right * x) + (parent.transform.up * i));
                    x++;
                }
                else
                {
                    FinishMoveArrows(arrows[b].transform.position = parent.transform.position - (parent.transform.right * x) + (parent.transform.up * i));
                    x++;
                }

            }
        }
        if ((arrowCount / line) * line < arrowCount)
            for (int z = (arrowCount / line) * line; z < arrowCount; z++)
            {
                int x = 0;
                FinishMoveArrows(arrows[z].transform.position = parent.transform.position - (parent.transform.right * x) + (parent.transform.up * (line+1)));
                FinishMoveArrows(arrows[z].transform.position = parent.transform.position - (parent.transform.right * x) + (parent.transform.up * (line + 1)));
                x++;

            }
    }

    private void OnTriggerEnter(Collider other)
    {
        Window window;

        if (other.TryGetComponent<Window>(out window))
        {
            if (other.transform.position.x / transform.position.x < 0)
                return;
            other.enabled = false;
            if (window.TypeWindow == WindowType.Positive)
            {
                CreateArrow(window.TypeStack == StackType.Plus ? window.Value : arrows.Count * (window.Value - 1));
            }
            else
            {
                DestroyArrow(window.TypeStack == StackType.Plus ? window.Value : arrows.Count - (arrows.Count / window.Value));
            }
        }
        if (other.CompareTag("Enemy"))
        {
            GameObject g = arrows[arrows.Count - 1];
            arrows.RemoveAt(arrows.Count - 1);
            EditorCoroutineUtility.StartCoroutine(DestroyObject(g), this);
        }
        else if (other.tag == "FinishOpen")
        {
            finishMode = true; speed = 4f; CameraController.Instance.StopFollowing(); transform.DOMoveX(0f, 0.3f);
            CamFinishMove();
            moving = false;

        }
        else if (other.tag == "Finish")
        {
            speed = 15f;
            counterText.gameObject.SetActive(false);
            StartCoroutine(GameWin(8f));
        }
    }
    public bool ControlLost(bool lostControl = true)
    {
        if (arrows.Count <= 0)
        {
            if (lostControl)
                Menus.Instance.OpenLostMenu();
            return true;
        }
        return false;
    }

    IEnumerator GameWin(float time)
    {
        yield return new WaitForSeconds(time / 2);
        cameraAudioSource.Stop();
        AudioSource.PlayClipAtPoint(complate,Camera.main.transform.position);
        Menus.Instance.OpenWinMenu();
    }
    void CamFinishMove()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(Camera.main.transform.DOMoveZ(545f, 1f));
        seq.Join(Camera.main.transform.DOMoveY(15f, 1f));
        seq.Append(Camera.main.transform.DOMoveZ(625f, 1.5f));
        seq.Join(Camera.main.transform.DOMoveY(10f, 1.5f));
    }

}
