using UnityEngine;

public class Recolector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root == transform.root)
        {
            return;
        }

        GameObject objetoRecolectable = BuscarColeccionable(other.transform);

        if (objetoRecolectable == null)
        {
            return;
        }

        GameManager gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
        {
            gameManager.SumarPunto();
        }
        else
        {
            Debug.LogError("No se encontro el GameManager en la escena.");
            return;
        }

        Debug.Log("Objeto recolectado: " + objetoRecolectable.name);

        Destroy(objetoRecolectable);
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
}