using UnityEngine;

public class CarDetection : MonoBehaviour
{
    private CarMovement carMovement;

    void Start()
    {
        // Ana ara� nesnesindeki CarMovement script'ine eri�
        carMovement = GetComponentInParent<CarMovement>();
        //if (carMovement == null)
        //{
        //    Debug.LogError("CarMovement script bulunamad�! L�tfen arac�n ana nesnesinde CarMovement script'inin y�kl� oldu�undan emin olun.");
        //}
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger'a giren nesne: " + other.gameObject.name);

        if (other.CompareTag("Player")) // Kullan�c� (Cow1) alg�lan�rsa
        {
            //Debug.Log("Kullan�c� (Cow1) alg�land�! Ara� duruyor.");
            carMovement.StopCar(); // Arac� durdur
        }
        else
        {
            //Debug.Log("Alg�lanan nesne Cow1 de�il, tag: " + other.tag);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Kullan�c� (Cow1) trigger alan�ndan ��karsa
        {
            //Debug.Log("Kullan�c� (Cow1) uzakla�t�! Ara� tekrar hareket ediyor.");
            carMovement.ResumeCar(); // Arac� tekrar hareket ettir
        }
    }
}