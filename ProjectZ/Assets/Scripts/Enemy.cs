using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    public Transform player; // Referência ao jogador (arraste no Inspector)
    public float speed = 5f;

    [Header("Configurações de Vida (Gerenciadas pelo GameManager)")]
    private int health; // Vida calculada pelo round atual

    void Start()
    {
        // Calcula a vida baseada no round atual
        health = GameManager.Instance.vidaBaseZumbi + 
                (GameManager.Instance.currentRound - 1) * GameManager.Instance.incrementoVidaPorRound;

        // Busca o jogador automaticamente se não estiver atribuído
        if (player == null)
        {
            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
            else
            {
                Debug.LogError("Jogador não encontrado! Atribua manualmente ou verifique a tag.");
            }
        }
    }

    void Update()
    {
        // Movimentação em direção ao jogador
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Colisão com o jogador
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.ReducePlayerHealth(40);
        }
        // Colisão com a bala
        else if (collision.gameObject.CompareTag("Bala"))
        {
            // Dano recebido
            health -= 10;

            // Destrói a bala
            Destroy(collision.gameObject);

            // Adiciona pontos (com verificação do perk)
            int pontos = GameManager.Instance.doublePointsAtivo ? 20 : 10;
            GameManager.Instance.AddPoints(pontos);

            // Verifica morte
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}