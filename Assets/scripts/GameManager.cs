using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject panelWin;
    public GameObject panelGameOver;

    public int puntos = 0;
    public int puntosParaGanar = 6;

    public float tiempoLimite = 60f;
    private float tiempoActual;

    private bool juegoTerminado = false;

    void Start()
    {
        tiempoActual = tiempoLimite;

        panelWin.SetActive(false);
        panelGameOver.SetActive(false);
    }

    void Update()
    {
        if (juegoTerminado == false)
        {
            tiempoActual -= Time.deltaTime;

            if (puntos >= puntosParaGanar)
            {
                Ganar();
            }

            if (tiempoActual <= 0 && puntos < puntosParaGanar)
            {
                Perder();
            }
        }
    }

    public void SumarPunto()
    {
        if (juegoTerminado == false)
        {
            puntos++;

            if (puntos >= puntosParaGanar)
            {
                Ganar();
            }
        }
    }

    void Ganar()
    {
        juegoTerminado = true;
        panelWin.SetActive(true);
        panelGameOver.SetActive(false);

        Time.timeScale = 0f;
    }

    void Perder()
    {
        juegoTerminado = true;
        panelGameOver.SetActive(true);
        panelWin.SetActive(false);

        Time.timeScale = 0f;
    }
}