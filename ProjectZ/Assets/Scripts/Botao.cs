using UnityEngine;
using UnityEngine.SceneManagement;

public class Botao : MonoBehaviour
{
    [Header("Configurações de Cena")]
    [Tooltip("Nome exato da cena que será carregada (veja em File > Build Settings)")]
    public string nomeDaCena; 

    public void CarregarCena()
    {
        // Verifica se a cena existe antes de carregar
        if(Application.CanStreamedLevelBeLoaded(nomeDaCena))
        {
            SceneManager.LoadScene(nomeDaCena);
        }
        else
        {
            Debug.LogError($"Cena '{nomeDaCena}' não encontrada! Adicione a cena nas Build Settings.");
        }
    }
}
