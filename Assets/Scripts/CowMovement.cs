using UnityEngine;

public class CowMovement : MonoBehaviour
{
    public float walkSpeed = 1f; // Yürüyüş hızı
    public float runSpeed = 3f;  // Koşu hızı
    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 movement;

    private bool isInCar = false; // Oyuncu araçta mı?
    private GameObject currentCar; // Oyuncunun bindiği araç

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isInCar)
        {
            // WASD ile hareket girdisi al
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            // Animasyon durumu belirle
            if (movement != Vector2.zero)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    animator.SetInteger("State", 2); // Koşu
                }
                else
                {
                    animator.SetInteger("State", 1); // Yürüyüş
                }
            }
            else
            {
                animator.SetInteger("State", 0); // Boşta
            }
        }
        else if (isInCar && currentCar != null)
        {
            // Araba kontrolü (W ve S ile hızlanma/yavaşlama, A ve D ile dönüş)
            float moveInput = Input.GetAxis("Vertical"); // İleri/Geri
            float turnInput = Input.GetAxis("Horizontal"); // Dönüş

            currentCar.transform.Translate(Vector3.right * moveInput * runSpeed * Time.deltaTime);
            currentCar.transform.Rotate(Vector3.forward * -turnInput * runSpeed * 20 * Time.deltaTime);
        }

        // Araçtan çıkma (F tuşuna basıldığında)
        if (Input.GetKeyDown(KeyCode.F) && isInCar)
        {
            ExitCar();
        }
    }

    void FixedUpdate()
    {
        if (!isInCar)
        {
            // Hareket et
            float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
            rb.linearVelocity = movement.normalized * currentSpeed;

            // Animasyon hızını ayarla
            UpdateAnimationSpeed(currentSpeed);
        }
    }

    private void UpdateAnimationSpeed(float currentSpeed)
    {
        // Hareket hızına göre animasyon hızını ölçeklendir
        float baseSpeed = walkSpeed; // Referans hız (örneğin yürüyüş hızı)
        animator.speed = currentSpeed / baseSpeed; // Animasyon hızı oranlanır
    }

    public void EnterCar(GameObject car)
    {
        isInCar = true;
        currentCar = car;

        // Oyuncuyu gizle
        GetComponent<SpriteRenderer>().enabled = false;
        rb.linearVelocity = Vector2.zero; // Hareketi durdur
        transform.position = car.transform.position; // Oyuncuyu arabanın içine yerleştir
    }

    public void ExitCar()
    {
        isInCar = false;
        currentCar = null;

        // Oyuncuyu görünür yap
        GetComponent<SpriteRenderer>().enabled = true;
        rb.linearVelocity = Vector2.zero; // Dışarı çıktığında hareketi sıfırla
    }
}
