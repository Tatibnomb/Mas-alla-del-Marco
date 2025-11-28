using UnityEngine;

public class ActivarMemotest : MonoBehaviour
{
    public GameObject memotestCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            memotestCanvas.SetActive(true);
            Debug.Log("Memotest activado");
        }
    }
}