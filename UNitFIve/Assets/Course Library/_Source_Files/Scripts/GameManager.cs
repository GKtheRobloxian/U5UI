using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
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
    public GameObject particle;
    public Slider healthBar;
    public Image fill;
    public int maxHealth;
    float currentMaxHealth;
    float damageTaken = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartGame(float difficulty, int healthReduction)
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
        randomSpawnRange /= difficulty;
        healthBar.maxValue = maxHealth - healthReduction;
        healthBar.value = 0;
        healthBar.fillRect.gameObject.SetActive(false);
        currentMaxHealth = healthBar.maxValue;
        Debug.Log(currentMaxHealth);
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
        GameOver();
        SmoothHealthBar();
    }

    public void GameOver()
    {
        if(damageTaken >= currentMaxHealth && currentMaxHealth != 0)
        {
            gameOve.gameObject.SetActive(true);
            isGameActive = false;
            restart.SetActive(true);

        }
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

    public void LifeUpdate(int healthReduce)
    {
        healthBar.fillRect.gameObject.SetActive(true);
        damageTaken += healthReduce;
        Debug.Log(damageTaken);
        if (damageTaken < 0)
        {
            damageTaken = 0;
        }
    }

    void SmoothHealthBar()
    {
        healthBar.value = Mathf.Lerp(healthBar.value, damageTaken, 0.01f);
    }
}
