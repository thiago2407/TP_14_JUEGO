using UnityEngine;
using TMPro;

public class Temporizador : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timer = 60f;

    private void Start()
    {
        MostrarTiempo();
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                timer = 0;
            }

            MostrarTiempo();
        }
    }

    private void MostrarTiempo()
    {
        int segundos = Mathf.CeilToInt(timer);
        timerText.text = "00:" + segundos.ToString("00");
    }
}