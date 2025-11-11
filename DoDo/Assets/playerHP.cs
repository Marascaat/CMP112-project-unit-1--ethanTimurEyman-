using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class playerHP : MonoBehaviour
{
    public Slider bar;

    public int maxHP = 100;
    public int hp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        bar.value = ((float)(hp) / (float)(maxHP));
    }
    public void PlayerHit()
    {
        hp = hp - 10;
    }
}
