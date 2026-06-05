using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    public GameObject winPanel;
    public GameObject gameOverPanel;

    public int score = 0;
    public int scoreParaGanar = 6;

    public float tiempoLimite = 60f;
    private float tiempoActual;

    private bool juegoTerminado = false;

    void Start()
    {
        tiempoActual = tiempoLimite;

        scoreText.text = "Score: " + score;
        timerText.text = "Tiempo: " + Mathf.CeilToInt(tiempoActual);

        winPanel.SetActive(false);
        gameOverPanel.SetActive(false);

        Time.timeScale = 1f;
    }

    void Update()
    {
        if (juegoTerminado == true)
        {
            return;
        }

        tiempoActual -= Time.deltaTime;
        timerText.text = "Tiempo: " + Mathf.CeilToInt(tiempoActual);

        if (score >= scoreParaGanar)
        {
            Ganar();
        }

        if (tiempoActual <= 0 && score < scoreParaGanar)
        {
            Perder();
        }
    }

    public void SumarPunto()
    {
        if (juegoTerminado == true)
        {
            return;
        }

        score++;
        scoreText.text = "Score: " + score;

        if (score >= scoreParaGanar)
        {
            Ganar();
        }
    }

    void Ganar()
    {
        juegoTerminado = true;

        winPanel.SetActive(true);
        gameOverPanel.SetActive(false);

        Time.timeScale = 0f;
    }

    void Perder()
    {
        juegoTerminado = true;

        gameOverPanel.SetActive(true);
        winPanel.SetActive(false);

        Time.timeScale = 0f;
    }
}