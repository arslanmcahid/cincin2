using UnityEngine;

public class CarDetection : MonoBehaviour
{
    private CarMovement carMovement;

    void Start()
    {
        // Ana araç nesnesindeki CarMovement script'ine eriþ
        carMovement = GetComponentInParent<CarMovement>();
        //if (carMovement == null)
        //{
        //    Debug.LogError("CarMovement script bulunamadý! Lütfen aracýn ana nesnesinde CarMovement script'inin yüklü olduðundan emin olun.");
        //}
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger'a giren nesne: " + other.gameObject.name);

        if (other.CompareTag("Player")) // Kullanýcý (Cow1) algýlanýrsa
        {
            //Debug.Log("Kullanýcý (Cow1) algýlandý! Araç duruyor.");
            carMovement.StopCar(); // Aracý durdur
        }
        else
        {
            //Debug.Log("Algýlanan nesne Cow1 deðil, tag: " + other.tag);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Kullanýcý (Cow1) trigger alanýndan çýkarsa
        {
            //Debug.Log("Kullanýcý (Cow1) uzaklaþtý! Araç tekrar hareket ediyor.");
            carMovement.ResumeCar(); // Aracý tekrar hareket ettir
        }
    }
}