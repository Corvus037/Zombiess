using UnityEngine;
using System.Collections.Generic;

public class Spawn : MonoBehaviour
{
    public GameObject prefabParaSpawnar;
    public List<Transform> pontosDeSpawn;
    public float intervaloDeSpawn = 10f; // Intervalo entre spawns

    void Start()
    {
        // Validações iniciais
        if (prefabParaSpawnar == null)
        {
            Debug.LogError("Prefab não atribuído no Inspector!");
            return;
        }

        if (pontosDeSpawn.Count == 0)
        {
            Debug.LogWarning("Nenhum ponto de spawn atribuído!");
            return;
        }

        // Inicia o spawn repetido
        InvokeRepeating("SpawnarObjetos", 0f, intervaloDeSpawn);
    }

    void SpawnarObjetos()
    {
        // Spawna em todos os pontos configurados
        foreach (Transform ponto in pontosDeSpawn)
        {
            Instantiate(prefabParaSpawnar, ponto.position, ponto.rotation);
        }
    }
}