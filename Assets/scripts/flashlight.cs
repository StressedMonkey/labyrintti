using UnityEngine;
using UnityEngine.Events;

[DefaultExecutionOrder(100)]
public class flashlight : MonoBehaviour
{
    [SerializeField, Min(0f)] private float startingBatterySeconds = 90f;
    [SerializeField] private Transform viewTransform;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private UnityEvent onBatteryDepleted = new UnityEvent();

    private Vector3 viewPositionOffset;
    private Quaternion viewRotationOffset;
    private Light[] lights;
    private float[] initialLightIntensities;

    private static flashlight timerOwner;
    private static float remainingBatterySeconds;
    private static bool batteryDepleted;

    private void Awake()
    {
        if (viewTransform == null)
        {
            Transform[] playerTransforms = transform.root.GetComponentsInChildren<Transform>(true);
            foreach (Transform candidate in playerTransforms)
            {
                if (candidate.CompareTag("CinemachineTarget"))
                {
                    viewTransform = candidate;
                    break;
                }
            }
        }

        if (viewTransform == null)
        {
            Debug.LogError("Flashlight requires an assigned view transform or a CinemachineTarget in its hierarchy.", this);
            enabled = false;
            return;
        }

        viewPositionOffset = viewTransform.InverseTransformPoint(transform.position);
        viewRotationOffset = Quaternion.Inverse(viewTransform.rotation) * transform.rotation;

        lights = GetComponentsInChildren<Light>(true);
        initialLightIntensities = new float[lights.Length];
        for (int i = 0; i < lights.Length; i++)
        {
            initialLightIntensities[i] = lights[i].intensity;
        }

        if (timerOwner == null)
        {
            timerOwner = this;
            remainingBatterySeconds = startingBatterySeconds;
            batteryDepleted = false;
            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (timerOwner == this && !batteryDepleted)
        {
            remainingBatterySeconds = Mathf.Max(0f, remainingBatterySeconds - Time.deltaTime);
            if (remainingBatterySeconds <= 0f)
            {
                EndGame();
            }
        }

        float brightness = startingBatterySeconds > 0f
            ? Mathf.Clamp01(remainingBatterySeconds / startingBatterySeconds)
            : 0f;
        for (int i = 0; i < lights.Length; i++)
        {
            if (lights[i] != null)
            {
                lights[i].intensity = initialLightIntensities[i] * brightness;
            }
        }
    }

    private void LateUpdate()
    {
        transform.SetPositionAndRotation(
            viewTransform.TransformPoint(viewPositionOffset),
            viewTransform.rotation * viewRotationOffset);
    }

    public static bool AddBatteryTime(float seconds)
    {
        if (timerOwner == null || batteryDepleted || seconds <= 0f ||
            float.IsNaN(seconds) || float.IsInfinity(seconds))
        {
            return false;
        }

        remainingBatterySeconds += seconds;
        return true;
    }

    private void EndGame()
    {
        batteryDepleted = true;
        for (int i = 0; i < lights.Length; i++)
        {
            if (lights[i] != null)
            {
                lights[i].intensity = 0f;
            }
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        onBatteryDepleted.Invoke();
        Debug.Log("Game over: flashlight battery depleted.", this);
        Time.timeScale = 0f;
    }

    private void OnDestroy()
    {
        if (timerOwner == this)
        {
            timerOwner = null;
            remainingBatterySeconds = 0f;
            batteryDepleted = false;
            Time.timeScale = 1f;
        }
    }
}
