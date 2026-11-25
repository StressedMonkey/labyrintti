using UnityEngine;

// pelaaja kerää avaimen ja ovi häviää
public class KeyPickup : MonoBehaviour
{
    public GameObject doorToOpen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(doorToOpen);
            Destroy(gameObject);
        }
    }
}