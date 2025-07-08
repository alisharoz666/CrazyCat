using UnityEngine;

public class Key : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            KeyManager.Instance.AddKey();  // Update key count
            Destroy(gameObject);           // Remove the key
        }
    }
}
