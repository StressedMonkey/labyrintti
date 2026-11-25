using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BatteryPickup : MonoBehaviour
{
    [SerializeField, Min(0.1f)] private float batterySeconds = 30f;

    private bool collected;

    private void Awake()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (collected || !other.CompareTag("Player"))
        {
            return;
        }

        if (!flashlight.AddBatteryTime(batterySeconds))
        {
            return;
        }

        collected = true;
        Destroy(gameObject);
    }
}
