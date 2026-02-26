using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject enemyPrefab;
    public int cultist = 40;

    public TMP_Text cultText;
    public TMP_Text enemyText;
    public TMP_Text gameState;

    private Enemy enemy;
    private float timer = 1.0f;
    private bool gameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject e = Instantiate(enemyPrefab, new Vector2(5,0), Quaternion.identity);
        enemy = e.GetComponent<Enemy>();

        UpdateUI();
        instance = this;
        enemyText.text = "Enemy HP: " + enemy.health;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver) return;

        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {
            enemy.TakeDamage(1);
            enemyText.text = "Enemy HP: " + enemy.health;
        }

        timer -= Time.deltaTime;

        if(timer <= 0) {
            cultist -= 2;
            if (cultist <= 0) {
                cultist = 0;
                LoseGame();
            }
            timer = 1.5f;
            UpdateUI();
        }
    }

    void UpdateUI() {
        cultText.text = "Cultsist HP: " + cultist;
    }

    public void WinGame() {
        gameOver = true;
        gameState.text = "You Win!";
    }

    void LoseGame () {
        gameState.text = "Game Over!";
    }
}
