using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject dodoPrefab;
    public float dodoInterval = 0.6f;
    public int maxDodoCount = 15;
    public string nextLevelName = "Maze";

    public Vector2 xRange = new Vector2(-7f, 6f);
    public Vector2 zRange = new Vector2(8.5f, 16f);
    public float yPosition = 2.347f;

    private int spawnedCount = 0;
    private GameObject currentDodo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnDodo());
    }

    public IEnumerator spawnDodo() 
    {
        while (spawnedCount < maxDodoCount)
        {
            yield return new WaitUntil(() => currentDodo == null);
            
            yield return new WaitForSeconds(dodoInterval);
            GameObject newDodo = Instantiate(dodoPrefab, new Vector3(Random.Range(xRange.x, xRange.y), yPosition, Random.Range(zRange.x, zRange.y)), Quaternion.identity);
            currentDodo = newDodo;
            spawnedCount++;
        }
        SceneManager.LoadScene(nextLevelName);
    }
}
