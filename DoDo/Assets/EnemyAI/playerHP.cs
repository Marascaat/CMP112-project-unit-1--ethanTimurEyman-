using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHP : MonoBehaviour
{
    public Slider bar;

    public int maxHP = 100;
    public int hp;
    public int damageDealt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        bar.value = ((float)(hp) / (float)(maxHP));
        if(hp == 0) 
        {
            SceneManager.LoadScene("Level 1");
        }
    }
    public void PlayerHit()
    {
        hp = hp - damageDealt;
    }
}
