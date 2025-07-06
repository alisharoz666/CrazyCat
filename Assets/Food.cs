using UnityEngine;

public class Food : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer.sprite = FoodManager.Instance.GetRandomFood();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FoodManager.Instance.NotifyFoodEaten();
            Destroy(gameObject);

            // Notify the manager
        }
    }
}
