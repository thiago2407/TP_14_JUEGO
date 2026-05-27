using UnityEngine;

public class Recolector : MonoBehaviour
{
    int contador = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coleccionable"))
        {
            contador++;

            Debug.Log("Objetos recolectados: " + contador);

            Destroy(other.gameObject);
        }
    }
}