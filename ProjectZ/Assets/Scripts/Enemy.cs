using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    public int health = 100;

    void Start()
    {
        if (player == null)
        {
            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null) player = playerObj.transform;
            else Debug.LogError("Jogador não encontrado!");
        }
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.ReducePlayerHealth(40);
        }
        else if (collision.gameObject.CompareTag("Bala"))
        {
            health -= 10;
            Destroy(collision.gameObject);

            // Verifica se o perk de double points está ativo
            int pontos = GameManager.Instance.doublePointsAtivo ? 20 : 10;
            GameManager.Instance.AddPoints(pontos);

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    } 
}

