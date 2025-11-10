using UnityEngine;
using System.Collections;

public class health : MonoBehaviour
{
    public int maxHP;
    int hp;

    private AudioSource source;
    public AudioClip fah;

    bool dead = false;
    bool isAttack = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = GetComponent<AudioSource>();
        hp = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("dodo"))
        {
            //print("hit " + collision.gameObject.name);
            hp--;
            if (hp<=0 )
            {
                if (!dead)
                {
                    source.PlayOneShot(fah, 1.0f);
                    dead = true;
                    StartCoroutine(dieBitch());
                }
            }
            
        }
    }
    IEnumerator dieBitch()
    {
        yield return new WaitForSeconds(0.75f);
        Destroy(gameObject);
    }
}
