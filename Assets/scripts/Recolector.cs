using UnityEngine;
using TMPro;

public class Recolector : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int contador = 0;

    private void Start()
    {
        if (scoreText == null)
        {
            GameObject texto = GameObject.Find("scoreText");

            if (texto != null)
            {
                scoreText = texto.GetComponent<TextMeshProUGUI>();
            }
        }

        ActualizarTexto();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coleccionable"))
        {
            contador++;

            Debug.Log("Recolectados: " + contador);

            Destroy(other.gameObject);

            ActualizarTexto();
        }
    }

    private void ActualizarTexto()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + contador;
        }
        else
        {
            Debug.LogError("No se encontro el objeto scoreText. Revisa el nombre o conectalo en el Inspector.");
        }
    }
}