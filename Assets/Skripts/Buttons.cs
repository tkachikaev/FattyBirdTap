using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public Sprite button, press;
    public bool sound;

    private Transform child;
    private Image image;

    private void Start()
    {
        /////////   Проверка музыки Она не ровна НО и поэтому играет, ее можно выключить    ////////
        if (sound)
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
        //Забираем компонент для работы
        image = GetComponent<Image>();
        //По умолчанию Звук есть, иконка по по 0-вому индеку
        child = transform.GetChild(0).transform;
    }
    private void OnMouseDown()
    {   //Картинка полсе нажатия
        image.sprite = press;
    }
    private void OnMouseUp()
    {   //Картинка после Отпуска
        image.sprite = button;
    }
    private void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            ///////Считали что объект выключен
            ///////если опять не ровно НО
            ///////Записали что ровно НО
            ///////Меняем картинку
            ///////else
            ///////Сбрасываем кей куда вписали ключик SET
            ///////Меняем иконку
            ///////Записываем дочерний объект как тру
            case "Sound":
                child.gameObject.SetActive(false);
                if (PlayerPrefs.GetString("Sound") != "SoundOff")
                {
                    PlayerPrefs.SetString("Sound", "SoundOff");
                    child = transform.GetChild(1).transform;
                }
                else
                {
                    PlayerPrefs.DeleteKey("Sound");
                    child = transform.GetChild(0).transform;
                }
                child.gameObject.SetActive(true);
                break;
        }
    }
}
