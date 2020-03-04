using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public Sprite buttonPress, buttonUnPress;
    public bool soundButton;

    private Image image;
    private Transform child;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void OnMouseDown()
    {
        image.sprite = buttonPress;
    }

    void OnMouseUp()
    {
        image.sprite = buttonUnPress;
    }
}
