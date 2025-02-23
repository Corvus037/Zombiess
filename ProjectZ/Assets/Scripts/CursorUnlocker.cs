using UnityEngine;

public class CursorUnlocker : MonoBehaviour
{
    [Header("Configurações do Cursor")]
    public bool unlockOnStart = true; // Desbloquear ao iniciar?
    public CursorLockMode lockMode = CursorLockMode.None; // Tipo de travamento
    public bool visible = true; // Cursor visível?

    void Start()
    {
        if(unlockOnStart)
        {
            SetCursorState();
        }
    }

    void Update()
    {
        // Opcional: alternar com tecla (ex: ESC)
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCursor();
        }
    }

    public void SetCursorState()
    {
        Cursor.lockState = lockMode;
        Cursor.visible = visible;
    }

    public void ToggleCursor()
    {
        // Alterna entre estados
        Cursor.lockState = (Cursor.lockState == CursorLockMode.Locked) ? 
                          CursorLockMode.None : CursorLockMode.Locked;
                          
        Cursor.visible = !Cursor.visible;
    }
}