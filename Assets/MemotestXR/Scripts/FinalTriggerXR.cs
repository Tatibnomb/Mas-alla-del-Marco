using UnityEngine;

public class FinalTriggerXR : MonoBehaviour
{
    public GameObject memotestUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            memotestUI.SetActive(true);
        }
    }
}
