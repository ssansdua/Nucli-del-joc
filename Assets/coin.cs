using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 90f;   
    [SerializeField] private float floatSpeed = 5f;      
    [SerializeField] private float floatHeight = 0.25f;  

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(1);
                Debug.Log("Coin collected! Score: " + GameManager.Instance.Score);
            }
            else
            {
                Debug.Log("Coin collected! (GameManager no encontrado)");
            }

            Destroy(gameObject);
        }
    }
}