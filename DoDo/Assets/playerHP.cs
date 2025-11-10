using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class playerHP : MonoBehaviour
{
    public Slider bar;

    public int maxHP = 100;
    public int hp;
    public bool canBeHit = true;
    public float invulnTime;
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
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            //print("hit " + collision.gameObject.name);
            Debug.Log("Player Hit");
            if (canBeHit)
            {
                hp--;
                Debug.Log("Player Hit");

                if (hp <= 0)
                {
                    Debug.Log("Player Is Dead");
                }
                 StartCoroutine(Invuln());
            }  
        }
    }

    IEnumerator Invuln()
    {
        canBeHit = false;
        yield return new WaitForSeconds(invulnTime);
        canBeHit = true;
    }
}
