using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum WindowType
{
    Positive, Negative
}
public enum StackType
{ 
    Plus,Times
}
public class Window : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] WindowType typeWindow;
    [SerializeField] StackType typeStack;
    [SerializeField] int value;
    [SerializeField] Text textValue;
#pragma warning disable CS0108 // Üye devralınmış üyeyi gizler; yeni anahtar sözcük eksik
    [SerializeField] MeshRenderer renderer;
#pragma warning restore CS0108 // Üye devralınmış üyeyi gizler; yeni anahtar sözcük eksik
    void Start()
    {
        SetTextValue();
    }
    void SetTextValue()
    {
        renderer.material = typeWindow == WindowType.Positive ? MaterialManager.Instance.bluePositive : MaterialManager.Instance.redNegative;
        textValue.text = typeWindow == WindowType.Positive ? typeStack == StackType.Plus ? " + " : " x " : typeStack == StackType.Plus ? " - " : " ÷ ";
        textValue.text += value.ToString();
    }
    public WindowType TypeWindow { get => typeWindow; }
    public StackType TypeStack { get => typeStack; }
    public int Value { get => value; }
}
