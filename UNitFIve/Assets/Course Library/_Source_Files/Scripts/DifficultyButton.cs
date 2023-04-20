using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DifficultyButton : MonoBehaviour
{
    public float difficulty;
    Button button;
    GameManager manage;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        manage = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void SetDifficulty()
    {
        manage.StartGame(difficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
