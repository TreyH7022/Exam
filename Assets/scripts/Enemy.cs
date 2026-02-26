using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 20;

    public void TakeDamage (int damage) {
        
        health -= damage;

        if (health <= 0) {
            GameManager.instance.WinGame();
            Destroy(gameObject);
        }
    }
}
