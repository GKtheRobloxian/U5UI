using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Diagnostics;

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
    public GameObject pauseButton;
    public Slider healthBar;
    public Image fill;
    public int maxHealth;
    float currentMaxHealth;
    float damageTaken = 0;
    GameObject pauseScreen;
    int konamiCountdown = 0;
    int ultrakillCountdown = 0;
    public bool paused;
    bool spawning;
    float spawnRateDecrease = 0.002f;

    public AudioSource musicPlayer;
    public AudioClip secretMusic;

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
        pauseButton.SetActive(true);
        spawnRateDecrease /= (difficulty/3.5f);

    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive && !paused)
        {
            spawning = true;
            yield return new WaitForSeconds(spawnRate + Random.Range(-randomSpawnRange, randomSpawnRange));
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnRate -= Time.deltaTime * spawnRateDecrease;
        GameOver();
        SmoothHealthBar();
        Pausing();
        KonamiCode();
        UltrakillCode();
    }

    void UltrakillCode()
    {
        if (spawning == false && ultrakillCountdown == 0 && Input.GetKeyDown(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 1 && Input.GetKeyDown(KeyCode.O))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 2 && Input.GetKeyDown(KeyCode.Space))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 3 && Input.GetKeyDown(KeyCode.Y))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 4 && Input.GetKeyDown(KeyCode.O))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 5 && Input.GetKeyDown(KeyCode.U))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 6 && Input.GetKeyDown(KeyCode.Space))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 7 && Input.GetKeyDown(KeyCode.L))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 8 && Input.GetKeyDown(KeyCode.O))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 9 && Input.GetKeyDown(KeyCode.V))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 10 && Input.GetKeyDown(KeyCode.E))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 11 && Input.GetKeyDown(KeyCode.Space))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 12 && Input.GetKeyDown(KeyCode.T))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 13 && Input.GetKeyDown(KeyCode.H))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 14 && Input.GetKeyUp(KeyCode.E))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 15 && Input.GetKeyDown(KeyCode.Space))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 16 && Input.GetKeyDown(KeyCode.C) && Input.GetKey(KeyCode.LeftShift))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 17 && Input.GetKeyDown(KeyCode.I))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 18 && Input.GetKeyDown(KeyCode.T))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 19 && Input.GetKeyDown(KeyCode.Y))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 20 && Input.GetKeyDown(KeyCode.Space))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 21 && Input.GetKeyDown(KeyCode.Y))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 22 && Input.GetKeyDown(KeyCode.O))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 23 && Input.GetKeyUp(KeyCode.U))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 24 && Input.GetKeyDown(KeyCode.Space))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 25 && Input.GetKeyDown(KeyCode.L))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 26 && Input.GetKeyDown(KeyCode.I))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 27 && Input.GetKeyDown(KeyCode.V))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 28 && Input.GetKeyDown(KeyCode.E))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 29 && Input.GetKeyDown(KeyCode.Space))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 30 && Input.GetKeyDown(KeyCode.I))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 31 && Input.GetKeyDown(KeyCode.N))
        {
            ultrakillCountdown++;
        }
        if (spawning == false && ultrakillCountdown == 32 && Input.GetKeyDown(KeyCode.Slash) && Input.GetKey(KeyCode.LeftShift))
        {
            StartGame(5, 3);
            musicPlayer.clip = secretMusic;
            musicPlayer.Play();
        }
    }

    void KonamiCode()
    {
        if (spawning == false && konamiCountdown == 0 && Input.GetKeyDown(KeyCode.UpArrow))
        {
            konamiCountdown++;
        }
        if (spawning == false && konamiCountdown == 1 && Input.GetKeyDown(KeyCode.UpArrow))
        {
            konamiCountdown++;
        }
        if (spawning == false && konamiCountdown == 2 && Input.GetKeyDown(KeyCode.DownArrow))
        {
            konamiCountdown++;
        }
        if (spawning == false && konamiCountdown == 3 && Input.GetKeyDown(KeyCode.DownArrow))
        {
            konamiCountdown++;
        }
        if (spawning == false && konamiCountdown == 4 && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            konamiCountdown++;
        }
        if (spawning == false && konamiCountdown == 5 && Input.GetKeyDown(KeyCode.RightArrow))
        {
            konamiCountdown++;
        }
        if (spawning == false && konamiCountdown == 6 && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            konamiCountdown++;
        }
        if (spawning == false && konamiCountdown == 7 && Input.GetKeyDown(KeyCode.RightArrow))
        {
            konamiCountdown++;
        }
        if (spawning == false && konamiCountdown == 8 && Input.GetKeyDown(KeyCode.B))
        {
            konamiCountdown++;
        }
        if (spawning == false && konamiCountdown == 9 && Input.GetKeyDown(KeyCode.A))
        {
            StartGame(3.5f, 2);
            musicPlayer.clip = secretMusic;
            musicPlayer.Play();
        }
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

    public void Pausing()
    {

        pauseScreen = GameObject.Find("Pause Screen");
        if (pauseScreen)
        {
            paused = true;
        }
        else
        {
            paused = false;
        }

        if (paused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
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
