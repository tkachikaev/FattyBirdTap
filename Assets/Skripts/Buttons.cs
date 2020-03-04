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
        if (soundButton)
        {
            if (PlayerPrefs.GetString("Sound") != "SoundOff")
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
            }
        }
        image = GetComponent<Image>();
        child = transform.GetChild(0).transform;
    }

    void OnMouseDown()
    {
        image.sprite = buttonPress;
    }

    void OnMouseUp()
    {
        image.sprite = buttonUnPress;
    }
    private void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "Sound":
                child.gameObject.SetActive(false);
                if (PlayerPrefs.GetString("Sound") != "SoundOff")
                {
                    PlayerPrefs.SetString("Sound", "SoundOff");
                    child = transform.GetChild(1).transform;             
                }
                break;
        }
    }
}
