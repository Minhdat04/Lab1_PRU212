using UnityEngine;

public class DustBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Vaccum"))
        {
            FindObjectOfType<GameManager>().DustCollected();
            gameObject.SetActive(false);
        }
    }
}