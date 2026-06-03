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
        Debug.Log("El Cube toco: " + other.gameObject.name);

        bool esCartuchera =
            other.CompareTag("Coleccionable") ||
            other.gameObject.name == "cartuchera2texture" ||
            other.gameObject.name.Contains("cartuchera2texture");

        if (esCartuchera)
        {
            contador++;

            Debug.Log("Cartuchera destruida. Score: " + contador);

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
            Debug.LogWarning("No se encontro scoreText. Arrastralo al campo Score Text del Cube.");
        }
    }
}