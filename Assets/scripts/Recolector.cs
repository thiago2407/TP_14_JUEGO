using UnityEngine;
using TMPro;

public class Recolector : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject winPanel;

    private int contador = 0;
    private bool juegoGanado = false;

    private void Start()
    {
        Time.timeScale = 1f;

        // Busca el texto del score si no fue conectado desde el Inspector.
        if (scoreText == null)
        {
            GameObject texto = GameObject.Find("scoreText");

            if (texto != null)
            {
                scoreText = texto.GetComponent<TextMeshProUGUI>();
            }
        }

        // Al comenzar la partida, la pantalla de victoria queda oculta.
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }

        ActualizarTexto();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (juegoGanado)
        {
            return;
        }

        // Evita que el Cube se detecte a sí mismo o al FPSController.
        if (other.transform.root == transform.root)
        {
            return;
        }

        GameObject objetoRecolectable = BuscarColeccionable(other.transform);

        if (objetoRecolectable != null)
        {
            contador++;

            Destroy(objetoRecolectable);

            ActualizarTexto();

            Debug.Log("Score: " + contador);

            if (contador >= 6)
            {
                MostrarVictoria();
            }
        }
    }

    private GameObject BuscarColeccionable(Transform objetoTocado)
    {
        Transform actual = objetoTocado;

        while (actual != null)
        {
            if (actual.CompareTag("Coleccionable"))
            {
                return actual.gameObject;
            }

            actual = actual.parent;
        }

        return null;
    }

    private void MostrarVictoria()
    {
        juegoGanado = true;

        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("Falta conectar WinPanel en el script Recolector del Cube.");
        }

        Time.timeScale = 0f;

        Debug.Log("¡GANASTE!");
    }

    private void ActualizarTexto()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + contador;
        }
    }
}