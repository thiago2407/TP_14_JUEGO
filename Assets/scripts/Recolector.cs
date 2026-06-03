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
        // Ignora al propio jugador
        if (other.transform.root == transform.root)
        {
            return;
        }

        Debug.Log("El Cube toco: " + other.gameObject.name);

        GameObject objetoRecolectable = BuscarColeccionable(other.transform);

        if (objetoRecolectable != null)
        {
            contador++;

            Debug.Log("Objeto destruido: " + objetoRecolectable.name);
            Debug.Log("Score: " + contador);

            Destroy(objetoRecolectable);

            ActualizarTexto();
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

    private void ActualizarTexto()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + contador;
        }
    }
}