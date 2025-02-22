using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player; // Transform do jogador, deve ser atribuído no Inspector
    public float speed = 5f; // Velocidade de movimento do inimigo
    public int health = 100; // Vida inicial do inimigo

    void Start()
    {
        // Verifica se o player foi atribuído; se não, tenta encontrá-lo pela tag
        if (player == null)
        {
            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
            else
            {
                Debug.LogError("Jogador não encontrado! Atribua o jogador no Inspector ou verifique a tag 'Player'.");
            }
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Calcula a direção do inimigo em relação ao jogador
            Vector3 direction = (player.position - transform.position).normalized;
            // Move o inimigo em direção ao jogador
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica colisão com o jogador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reduz a vida do jogador em 40 através do GameManager
            GameManager.Instance.ReducePlayerHealth(40);
        }
        // Verifica colisão com a bala
        else if (collision.gameObject.CompareTag("Bala"))
        {
            // Reduz a vida do inimigo em 10
            health -= 10;
            // Destroi a bala
            Destroy(collision.gameObject);
            // Adiciona 10 pontos ao GameManager
            GameManager.Instance.AddPoints(10);
            // Se a vida do inimigo chegar a zero, destrói o inimigo
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
