using UnityEngine;
using UnityEngine.InputSystem;

public class MoveObject2D : MonoBehaviour
{
    public float pushForce = 50f; // Daha büyük itme kuvveti
    public float shakeDuration = 1.0f; // Daha uzun kamera sarsýntýsý süresi
    public float shakeMagnitude = 0.01f; // Daha büyük kamera sarsýntýsý büyüklüðü
    public Camera mainCamera; // Ana kamera referansý

    private Rigidbody2D rb;
    private Vector3 originalCameraPosition;
    private float shakeTimeRemaining;

    private PlayerActions playerActions;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bileþenini al
        playerActions = new PlayerActions();
    }

    void OnEnable()
    {
        playerActions.PlayerInputs.Shake.performed += OnShake;
        playerActions.PlayerInputs.Enable();
    }

    void OnDisable()
    {
        playerActions.PlayerInputs.Shake.performed -= OnShake;
        playerActions.PlayerInputs.Disable();
    }

    private void OnShake(InputAction.CallbackContext context)
    {
        PushObject();
        StartCameraShake();
    }

    void Update()
    {
        if (shakeTimeRemaining > 0)
        {
            ShakeCamera();
        }
    }

    void PushObject()
    {
        // Rastgele bir yön seç
        Vector2 randomDirection = new Vector2(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        );

        // Daha büyük itme kuvvetini uygulayýn
        rb.AddForce(randomDirection * pushForce, ForceMode2D.Impulse);
    }

    void StartCameraShake()
    {
        shakeTimeRemaining = shakeDuration;
    }

    void ShakeCamera()
    {
        if (shakeTimeRemaining > 0)
        {
            mainCamera.transform.position = originalCameraPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            shakeTimeRemaining -= Time.deltaTime;
        }
        else
        {
            shakeTimeRemaining = 0f;
            mainCamera.transform.position = originalCameraPosition;
        }
    }
}
