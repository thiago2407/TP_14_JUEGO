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
        // Asegura que la partida empiece sin estar congelada.
        Time.timeScale = 1f;

        contador = 0;
        juegoGanado = false;

        // Busca el texto del score si no fue conectado manualmente.
        if (scoreText == null)
        {
            GameObject texto = GameObject.Find("scoreText");

            if (texto != null)
            {
                scoreText = texto.GetComponent<TextMeshProUGUI>();
            }
            else
            {
                Debug.LogError("No se encontro el objeto scoreText.");
            }
        }

        // Oculta la pantalla de victoria al iniciar.
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("No conectaste WinPanel en el componente Recolector del Cube.");
        }

        ActualizarTexto();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si ya se gano, no sigue recolectando objetos.
        if (juegoGanado)
        {
            return;
        }

        // Evita que el Cube detecte al propio FPSController.
        if (other.transform.root == transform.root)
        {
            return;
        }

        GameObject objetoRecolectable = BuscarColeccionable(other.transform);

        // Si el objeto tocado no es coleccionable, no hace nada.
        if (objetoRecolectable == null)
        {
            return;
        }

        contador++;

        Debug.Log("Objeto recolectado: " + objetoRecolectable.name);
        Debug.Log("Score: " + contador);

        Destroy(objetoRecolectable);

        ActualizarTexto();

        // Solamente al llegar a 6 puntos aparece el WinPanel.
        if (contador >= 6)
        {
            MostrarVictoria();
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
            Debug.LogError("No se puede mostrar la victoria porque WinPanel no esta conectado.");
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