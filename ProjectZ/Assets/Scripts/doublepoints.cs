using UnityEngine;
using UnityEngine.UI;

public class DoublePointsPerk : MonoBehaviour // Nome da classe em CamelCase
{
    [Header("Configurações do Perk")]
    public int custoPerk = 2500; 
    public Image imagemPerk; 

    private bool perkAtivado = false;
    private bool playerPerto; // Verifica se o jogador está na área

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
        // Verifica proximidade + pontos + perk não ativado
        if (playerPerto && !perkAtivado && GameManager.Instance.points >= custoPerk)
        {
            perkAtivado = true;
            GameManager.Instance.doublePointsAtivo = true;
            GameManager.Instance.RemovePoints(custoPerk);

            if (imagemPerk != null)
            {
                imagemPerk.gameObject.SetActive(true);
            }

            Debug.Log("Perk de pontos dobrados ativado!");
        }
    }
}