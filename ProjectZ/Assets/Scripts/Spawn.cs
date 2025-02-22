using UnityEngine;
using System.Collections.Generic;


public class Spawn : MonoBehaviour
{
    // Prefab que será clonado
    public GameObject prefabParaSpawnar;

    // Lista de pontos de spawn (objetos vazios ou outros)
    public List<Transform> pontosDeSpawn;

    void Start()
    {
        // Verifica se o prefab foi atribuído
        if (prefabParaSpawnar == null)
        {
            Debug.LogError("Prefab não atribuído! Arraste um prefab para o campo 'Prefab Para Spawnar' no Inspector.");
            return;
        }

        // Verifica se há pontos de spawn
        if (pontosDeSpawn.Count == 0)
        {
            Debug.LogWarning("Nenhum ponto de spawn atribuído. Adicione objetos à lista 'Pontos De Spawn' no Inspector.");
            return;
        }

        // Cria um clone do prefab em cada ponto de spawn
        foreach (Transform ponto in pontosDeSpawn)
        {
            Instantiate(prefabParaSpawnar, ponto.position, ponto.rotation);
        }
    }
}