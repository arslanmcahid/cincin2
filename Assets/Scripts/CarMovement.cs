using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float initialSpeed = 1f; // Ba�lang�� h�z�
    public float maxSpeed = 5f;    // Maksimum h�z
    public float acceleration = 0.5f; // �vmelenme
    private float currentSpeed;    // Anl�k h�z
    private bool isStopped = false;
    private Vector2 direction = Vector2.right; // Varsay�lan y�n

    void Start()
    {
        currentSpeed = initialSpeed;
    }

    void Update()
    {
        if (!isStopped)
        {
            // �vmelenme ile h�z� art�r
            currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, maxSpeed);

            // Y�n do�rultusunda hareket et
            transform.Translate((Vector3)direction * currentSpeed * Time.deltaTime, Space.World);
        }

        // Ekran�n d���na ��kan ara�lar� yok et
        if (IsOffScreen())
        {
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection; // Hareket y�n�n� ayarla
    }

    private bool IsOffScreen()
    {
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        return viewportPosition.x < -0.1f || viewportPosition.x > 1.1f || viewportPosition.y < -0.1f || viewportPosition.y > 1.1f;
    }

    public void StopCar()
    {
        isStopped = true; // Arac� durdur
    }

    public void ResumeCar()
    {
        isStopped = false; // Arac� tekrar hareket ettir
    }
}