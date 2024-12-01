using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float initialSpeed = 1f; // Baþlangýç hýzý
    public float maxSpeed = 5f;    // Maksimum hýz
    public float acceleration = 0.5f; // Ývmelenme
    private float currentSpeed;    // Anlýk hýz
    private bool isStopped = false;
    private Vector2 direction = Vector2.right; // Varsayýlan yön

    void Start()
    {
        currentSpeed = initialSpeed;
    }

    void Update()
    {
        if (!isStopped)
        {
            // Ývmelenme ile hýzý artýr
            currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, maxSpeed);

            // Yön doðrultusunda hareket et
            transform.Translate((Vector3)direction * currentSpeed * Time.deltaTime, Space.World);
        }

        // Ekranýn dýþýna çýkan araçlarý yok et
        if (IsOffScreen())
        {
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection; // Hareket yönünü ayarla
    }

    private bool IsOffScreen()
    {
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        return viewportPosition.x < -0.1f || viewportPosition.x > 1.1f || viewportPosition.y < -0.1f || viewportPosition.y > 1.1f;
    }

    public void StopCar()
    {
        isStopped = true; // Aracý durdur
    }

    public void ResumeCar()
    {
        isStopped = false; // Aracý tekrar hareket ettir
    }
}