using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int score;

    public static int highScore;

    public static int timePlayed;

    private float targetTime = 1f;

    [SerializeField] private TextMeshProUGUI Score;
    [SerializeField] private TextMeshProUGUI HighScore;
    [SerializeField] private TextMeshProUGUI TimePlayed;
    
    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore " + SceneManager.GetActiveScene().name);
        timePlayed = 0;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (score > highScore) highScore = score;
        
        targetTime -= Time.deltaTime;
 
        if (targetTime <= 0.0f)
        {
            targetTime = 1f;
            timePlayed++;
        }

        Score.text = "Score: " + score;
        HighScore.text = "Highscore: " + highScore;
        TimePlayed.text = "Time: " + timePlayed;
    }
}
