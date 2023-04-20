using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float spawnRate = 1.5f;
    public float randomSpawnRange;
    int score;
    public TMP_Text scoreText;
    public TMP_Text gameOve;
    public List<GameObject> targets;
    public bool isGameActive;
    public GameObject restart;
    public GameObject titleScreen;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartGame(float difficulty)
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
        randomSpawnRange /= difficulty;
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate + Random.Range(-randomSpawnRange, randomSpawnRange));
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnRate -= Time.deltaTime * 0.002f;
    }

    public void GameOver()
    {
        gameOve.gameObject.SetActive(true);
        isGameActive = false;
        restart.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateScore(int scored)
    {
        score += scored;
        scoreText.text = "Score: " + score;
    }    
}
