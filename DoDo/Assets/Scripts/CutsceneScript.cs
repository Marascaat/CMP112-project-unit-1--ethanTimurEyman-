using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CutsceneScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(NextScene());
    }

    private IEnumerator NextScene() 
    {
        yield return new WaitForSeconds(30);
        SceneManager.LoadScene("Cutscene 1");
    }
}
