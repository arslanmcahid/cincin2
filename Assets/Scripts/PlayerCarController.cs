using UnityEngine;

public class PlayerCarController : MonoBehaviour
{
    public float acceleration = 10f; // ivmelenme
    public float maxSpeed = 20f;     // Maksimum hiz
    public float turnSpeed = 50f;    // Donus hizi
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Hareket girdisi
        float moveInput = Input.GetAxis("Vertical"); // ileri/Geri
        float turnInput = Input.GetAxis("Horizontal"); // D�n��

        // Maksimum hiz kontrol
        if (rb.linearVelocity.magnitude < maxSpeed)
        {
            rb.AddForce(transform.up * moveInput * acceleration);
        }

        // araci dondur
        transform.Rotate(Vector3.forward * -turnInput * turnSpeed * Time.fixedDeltaTime);
    }
}