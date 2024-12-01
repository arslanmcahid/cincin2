using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject carPrefab; // Araç prefab
    //public Vector2[] directions; // Her spawn noktasý için yön
    public Transform[] spawnPoints; // noktalar
    public float spawnInterval = 5f; // süre

    void Start()
    {
        InvokeRepeating("SpawnCar", 0f, spawnInterval);
    }

    void SpawnCar()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        GameObject newCar = Instantiate(carPrefab, spawnPoint.position, Quaternion.identity);

        CarMovement carMovement = newCar.GetComponent<CarMovement>();

        if (spawnPoint == spawnPoints[0])
        {
            carMovement.SetDirection(Vector2.right);
            newCar.transform.rotation = Quaternion.Euler(0, 0, -90); 
        }
        else if (spawnPoint == spawnPoints[1])
        {
            carMovement.SetDirection(Vector2.left);
            newCar.transform.rotation = Quaternion.Euler(0, 0, 270);
        }
    }





}