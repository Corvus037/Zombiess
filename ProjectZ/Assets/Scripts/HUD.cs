using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    // Referências aos textos
    public TextMeshProUGUI textoVida;
    public TextMeshProUGUI textoPontos;
    public TextMeshProUGUI textoRound; // Novo campo para o round
    public TextMeshProUGUI textoTempo; // Novo campo para o tempo

    void Update()
    {
        // Acessa os dados do GameManager
        int vida = GameManager.Instance.playerHealth;
        int pontos = GameManager.Instance.points;
        int round = GameManager.Instance.currentRound;
        int tempoRestante = Mathf.CeilToInt(GameManager.Instance.roundTimer); // Arredonda para cima

        // Atualiza todos os textos
        textoVida.text = "Life: " + vida.ToString();
        textoPontos.text = "Points: " + pontos.ToString();
        textoRound.text = "Round: " + round.ToString();
        textoTempo.text = "Time: " + tempoRestante.ToString() + "s"; // Ex: "Tempo: 45s"
    }
}

