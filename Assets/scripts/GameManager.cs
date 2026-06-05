using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
        Time.timeScale = 1f;

        tiempoActual = tiempoLimite;
        score = 0;
        juegoTerminado = false;

        winPanel.SetActive(false);
        gameOverPanel.SetActive(false);

        scoreText.text = "Score: " + score;
        timerText.text = "Tiempo: " + Mathf.CeilToInt(tiempoActual);
    }

    void Update()
    {
        if (juegoTerminado)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                ReiniciarEscena();
            }

            return;
        }

        tiempoActual -= Time.deltaTime;
        timerText.text = "Tiempo: " + Mathf.CeilToInt(tiempoActual);

        if (tiempoActual <= 0 && score < scoreParaGanar)
        {
            Perder();
        }
    }

    public void SumarPunto()
    {
        if (juegoTerminado)
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

    void ReiniciarEscena()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}