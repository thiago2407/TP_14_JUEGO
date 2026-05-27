using UnityEngine;

public class Recolector : MonoBehaviour
{
    int contador = 0;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Toque: " + other.gameObject.name);

        if (other.CompareTag("Coleccionable"))
        {
            contador++;
            Debug.Log("Recolectados: " + contador);
            Destroy(other.gameObject);
        }
    }
}