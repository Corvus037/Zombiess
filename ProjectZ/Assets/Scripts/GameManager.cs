using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance { get; private set; }

    [Header("Configurações do Jogador")]
    public int playerHealth = 100;
    public int points = 500;

    [Header("Configurações de Round")]
    public int currentRound = 1;
    public float roundDuration = 60f;
    public  float roundTimer;
    public bool doublePointsAtivo = false;

    [Header("Configurações dos Zumbis")]
    public int vidaBaseZumbi = 100;
    public int incrementoVidaPorRound = 50;

    [Header("Gerenciamento de Cenas")]
    public string nomeCenaGameOver = "GameOver";
    public string nomeCenaPrincipal = "MainScene"; // Nome da sua cena principal

    void Awake()
    {
        // Configuração do singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            ResetarEstadoDoJogo(); // Reset inicial
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Novo método para resetar todos os valores
    public void ResetarEstadoDoJogo()
    {
        playerHealth = 100;
        points = 500;
        currentRound = 1;
        roundTimer = roundDuration;
        doublePointsAtivo = false;
    }

    void Update()
    {
        roundTimer -= Time.deltaTime;

        if (roundTimer <= 0)
        {
            StartNewRound();
        }
    }

    void StartNewRound()
    {
        currentRound++;
        roundTimer = roundDuration;
        Debug.Log($"Round {currentRound} iniciado!");
    }

    public void ReducePlayerHealth(int amount)
    {
        playerHealth -= amount;
        
        if (playerHealth <= 0)
        {
            playerHealth = 0;
            CarregarCenaGameOver();
        }
    }

    void CarregarCenaGameOver()
    {
        if (!string.IsNullOrEmpty(nomeCenaGameOver))
        {
            if (Application.CanStreamedLevelBeLoaded(nomeCenaGameOver))
            {
                SceneManager.LoadScene(nomeCenaGameOver);
            }
            else
            {
                Debug.LogError($"Cena '{nomeCenaGameOver}' não está nas Build Settings!");
            }
        }
        else
        {
            Debug.LogError("Nome da cena de game over não definido!");
        }
    }

    // Método para reiniciar o jogo completamente
    public void ReiniciarJogo()
    {
        ResetarEstadoDoJogo();
        SceneManager.LoadScene(nomeCenaPrincipal);
    }

    public void AddPoints(int amount)
    {
        points += amount;
    }

    public void RemovePoints(int amount)
    {
        points = Mathf.Max(points - amount, 0);
    }

    public void ResetRoundTimer()
    {
        roundTimer = roundDuration;
    }
}