using UnityEngine;
using UnityEngine.UI;

public class Jugger : MonoBehaviour
{
    [Header("Configurações do Perk")]
    public int custoPerk = 2500; 
    public int vidaExtra = 100; 
    public Image imagemPerk; 

    private bool perkAtivado = false;
    private bool playerPerto; // Verifica se o jogador está na área do perk

    void Update()
    {
        // Só verifica o input se o jogador estiver perto
        if (playerPerto && Input.GetKeyDown(KeyCode.F))
        {
            TentarComprarPerk();
        }
    }

    // Detecta quando o jogador entra na área do perk
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerPerto = true;
        }
    }

    // Detecta quando o jogador sai da área
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerPerto = false;
        }
    }

    private void TentarComprarPerk()
    {
        // Verifica proximidade + pontos + se o perk já foi ativado
        if (playerPerto && !perkAtivado && GameManager.Instance.points >= custoPerk)
        {
            perkAtivado = true;
            GameManager.Instance.playerHealth += vidaExtra;
            GameManager.Instance.RemovePoints(custoPerk);

            if (imagemPerk != null)
            {
                imagemPerk.gameObject.SetActive(true);
            }

            Debug.Log("Perk de vida ativado!");
        }
    }
}