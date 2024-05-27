using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HardcoreMode : MonoBehaviour
{
    public bool Hardcore;
    public TMP_Text text;

    public void Start()
    {
        Hardcore = false;
        text.color = Color.black;
    }
    public void NewGameButton()
    {
        if (Hardcore == false)
        {
            Hardcore = true;
            text.text = "����� �������� �������";
            text.color = Color.red;
        }
        else
        {
            Hardcore = false;
            text.text = "����� �������� ��������";
            text.color = Color.black;
        }
    }
}
