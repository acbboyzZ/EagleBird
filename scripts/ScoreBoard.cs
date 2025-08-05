using UnityEngine;
using UnityEngine.UI;
public class ScoreBoard : MonoBehaviour
{
    public float speed = 10f;
    public Text Timer;
    public Text scoreText;     // Assign this in the Inspector
    //public Text winText;       // Assign this in the Inspector
    public int winScore = 10;  // Number of pickups required to win
    public float timeLeft = 5f;
    public GameObject restartButton;
    private Rigidbody rb;
    public int score;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Timer.text = "";
        Time.timeScale = 1;
        score = 0;
        SetScoreText();
        // winText.text = "";     // Clear win message at start
        //scoreText.text += score;
    }
    void Update()
    {
    if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            timeLeft = 0;
            TimerEnded();
        }
    }
    public void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score >= winScore)
        {
            //winText.text = "You Win!";
        }
    }
    void UpdateTimerDisplay()
    {
        if (Timer != null)
            Timer.text = Mathf.CeilToInt(timeLeft).ToString(); // Optional: Format for mm:ss
    }
    void TimerEnded()
    {
        Debug.Log("Timer has ended!");
        restartButton.SetActive(true);
        Time.timeScale = 0;
        // Do something dramatic here—explode, game over, etc.
    }
}