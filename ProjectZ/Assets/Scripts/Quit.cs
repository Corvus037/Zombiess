using UnityEngine;

public class Quit : MonoBehaviour
{
    public void FecharJogo()
    {
        // Fecha o jogo (funciona apenas na build final)
        Application.Quit();

        // Para testar no Editor (opcional)
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
