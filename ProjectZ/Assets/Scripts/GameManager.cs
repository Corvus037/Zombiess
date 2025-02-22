using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance { get; private set; }

    // Variáveis do jogador
    public int playerHealth = 100; 
    public int points = 500;       

    // Variáveis de round e tempo
    public int currentRound = 1;     // Round atual
    public float roundDuration = 60f; // Tempo de cada round em segundos (1 minuto padrão)
    public float roundTimer;        // Contador interno do tempo

    void Awake()
    {
        // Configura o singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
            roundTimer = roundDuration; // Inicia o timer com o tempo total
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Atualiza o timer a cada frame
        roundTimer -= Time.deltaTime;

        // Verifica se o tempo acabou
        if (roundTimer <= 0)
        {
            StartNewRound();
        }
    }

    // Método chamado quando o tempo do round acaba
    private void StartNewRound()
    {
        currentRound++; // Incrementa o round
        roundTimer = roundDuration; // Reinicia o timer
        Debug.Log($"Round {currentRound} iniciado!");

        // Adicione aqui lógicas extras no início de cada round (ex: spawnar mais inimigos)
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
        if (points < 0) points = 0;
    }

    // Método opcional para reiniciar o round manualmente
    public void ResetRoundTimer()
    {
        roundTimer = roundDuration;
    }
}
