using UnityEngine;

public class ActivarMemotest : MonoBehaviour
{
    public GameObject canvasMemotest;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasMemotest.SetActive(true);
        }
    }
}