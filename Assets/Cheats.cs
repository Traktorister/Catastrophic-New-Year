using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cheats : MonoBehaviour
{
    public bool cheatsEnable;
    public TMP_Text text;
    private int textline;
    public bool cheats;
    void Start()
    {
        text.color = Color.black;
        textline = 0;
        cheatsEnable = GetComponent<GameOver>().cheats;
        cheats = false;
    }

    public void NewGameButton()
    {
        if (cheatsEnable == false)
        {
            if (textline == 0)
            {
                text.text = "���� ����������";
                textline = 1;
            }

            if (textline == 1)
            {
                text.text = "�� ������? ������, ���� ����������";
                textline = 2;
            }

            if (textline == 2)
            {
                text.text = "�����, ��� ���������";
                textline = 3;
            }

            if (textline == 3)
            {
                text.text = "��� �������";
                textline = 4;
            }

            if (textline == 4)
            {
                text.text = "��� �������, ������";
                textline = 5;
            }

            if (textline == 5)
            {
                text.text = "������ ���������?";
                textline = 6;
            }

            if(textline == 6)
            {
                text.text = "�������� �������, ����, ��������� ��� �����";
                textline = 7;
            }

            if (textline == 7)
            {
                text.text = "������ ��?";
                textline = 8;
            }

            if (textline == 8)
            {
                text.text = "��, ��� �� �� ����?";
                textline = 9;
            }

            if (textline == 9)
            {
                text.text = "���, ������";
                textline = 10;
            }

            if(textline == 10)
            {
                text.text = "�� ������, �� ����� ������ ������?";
                textline = 11;
            }

            if (textline == 11)
            {
                text.text = "������� �� ����� �����";
                textline = 12;
            }

            if (textline == 12)
            {
                text.text = "�� �� �� ����";
                textline = 13;
            }

            else
            {
                text.text = "���� ���, �������� �����?";
            }
        }

        if (cheatsEnable == true && cheats == false)
        {
            if (textline >= 3)
            {
                text.text = "������ ��, ����� ������! ���� ��������";
                cheats = true;
            }

            else
            {
                text.text = "���� ��������";
                cheats = true;
            }
            
        }

        if (cheatsEnable == true && cheats == true)
        {
            text.text = "���� ���������";
            cheats = false;
        }
    }
}
