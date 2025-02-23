using UnityEngine;
public class reiniciar : MonoBehaviour
{
    public void OnBotaoReiniciarClicado()
    {
        GameManager.Instance.ReiniciarJogo();
    }
}