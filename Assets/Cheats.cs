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
                text.text = "Читы недоступны";
                textline = 1;
            }

            if (textline == 1)
            {
                text.text = "Ты слепой? Говорю, читы недоступны";
                textline = 2;
            }

            if (textline == 2)
            {
                text.text = "Ладно, дам подсказку";
                textline = 3;
            }

            if (textline == 3)
            {
                text.text = "Ищи монетку";
                textline = 4;
            }

            if (textline == 4)
            {
                text.text = "Ищи монетку, говорю";
                textline = 5;
            }

            if (textline == 5)
            {
                text.text = "Видишь стрелочку?";
                textline = 6;
            }

            if(textline == 6)
            {
                text.text = "Огромную красную, блин, стрелочку над ёлкой";
                textline = 7;
            }

            if (textline == 7)
            {
                text.text = "Видишь же?";
                textline = 8;
            }

            if (textline == 8)
            {
                text.text = "Ну, что ты не идёшь?";
                textline = 9;
            }

            if (textline == 9)
            {
                text.text = "Иди, говорю";
                textline = 10;
            }

            if(textline == 10)
            {
                text.text = "Не знаешь, на какую кнопку ходить?";
                textline = 11;
            }

            if (textline == 11)
            {
                text.text = "Подёргай за левый сосок";
                textline = 12;
            }

            if (textline == 12)
            {
                text.text = "Да не за свой";
                textline = 13;
            }

            else
            {
                text.text = "Тебе что, заняться нечем?";
            }
        }

        if (cheatsEnable == true && cheats == false)
        {
            if (textline >= 3)
            {
                text.text = "Можешь же, когда хочешь! Читы включены";
                cheats = true;
            }

            else
            {
                text.text = "Читы включены";
                cheats = true;
            }
            
        }

        if (cheatsEnable == true && cheats == true)
        {
            text.text = "Читы выключены";
            cheats = false;
        }
    }
}
