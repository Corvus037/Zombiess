using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance { get; private set; }

    // Variáveis do jogador
    public int playerHealth = 100; // Vida do jogador
    public int points = 500;       // Pontos do jogador

    void Awake()
    {
        // Configura o singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Opcional: mantém o GameManager entre cenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Método para reduzir a vida do jogador
    public void ReducePlayerHealth(int amount)
    {
        playerHealth -= amount;
        if (playerHealth <= 0)
        {
            playerHealth = 0;
            Debug.Log("Jogador morreu!");
        }
    }

    // Método para adicionar pontos
    public void AddPoints(int amount)
    {
        points += amount;
    }

    // Método para remover pontos
    public void RemovePoints(int amount)
    {
        points -= amount;
        if (points < 0)
        {
            points = 0;
        }
    }
}
