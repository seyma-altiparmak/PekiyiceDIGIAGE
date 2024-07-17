using UnityEngine;
using UnityEngine.InputSystem;

public class MoveObject2D : MonoBehaviour
{
    public float pushForce = 50f; // Daha b�y�k itme kuvveti
    public float shakeDuration = 1.0f; // Daha uzun kamera sars�nt�s� s�resi
    public float shakeMagnitude = 0.01f; // Daha b�y�k kamera sars�nt�s� b�y�kl���
    public Camera mainCamera; // Ana kamera referans�

    private Rigidbody2D rb;
    private Vector3 originalCameraPosition;
    private float shakeTimeRemaining;

    private PlayerActions playerActions;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bile�enini al
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
        // Rastgele bir y�n se�
        Vector2 randomDirection = new Vector2(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        );

        // Daha b�y�k itme kuvvetini uygulay�n
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
