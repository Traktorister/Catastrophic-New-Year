using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public TMP_Text pointsText;
    public TMP_Text timeText;
    private int gnoms;
    public float time;

    public void Start()
    {
        Gnoms(gnoms);
        gnoms += GetComponent<Explode>().gnomeDeath;
    }
    public void Gnoms(int gnoms)
    {
        gameObject.SetActive(true);
        pointsText.text = gnoms.ToString() + " √номов";
    }
}
