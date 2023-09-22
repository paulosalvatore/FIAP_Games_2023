using System.Collections.Generic;
using UnityEngine;

public class ScenarioManager : MonoBehaviour
{
    [Header("External Dependencies")]
    [SerializeField]
    private Transform player;             // Referência à posição do jogador

    [SerializeField]
    private GameObject[] scenarioPrefabs; // Lista de prefabs dos cenários

    [Header("Scenario Config")]
    [SerializeField]
    private float distanceBetweenScenarios = 52f; // Distância entre cenários

    [SerializeField]
    private int numberOfScenariosAhead = 3; // Quantos cenários à frente do jogador para manter gerados

    [SerializeField]
    private float marginBeforeEnd = 10f;  // Margem de distância antes do final do cenário para gerar o próximo

    private int _currentScenarioIndex; // Índice do cenário atual que o jogador está
    private readonly List<GameObject> _activeScenarios = new(); // Lista de cenários ativos no jogo

    private void Start()
    {
        // Gera os cenários iniciais baseados no número definido
        for (int i = 0; i < numberOfScenariosAhead; i++)
        {
            GenerateScenario();
        }
    }

    private void Update()
    {
        // Se o jogador passar da metade do cenário atual, gera um novo
        if (player.position.z > _currentScenarioIndex * distanceBetweenScenarios - marginBeforeEnd)
        {
            GenerateScenario();
            DeleteOldestScenario();
        }
    }

    // Gera um novo cenário na cena
    private void GenerateScenario()
    {
        var scenarioPrefab = scenarioPrefabs[Random.Range(0, scenarioPrefabs.Length)]; // Seleciona um cenário aleatório
        var spawnPosition = new Vector3(0, 0, _currentScenarioIndex * distanceBetweenScenarios);
        var spawnedScenario = Instantiate(scenarioPrefab, spawnPosition, Quaternion.identity);
        _activeScenarios.Add(spawnedScenario);
        _currentScenarioIndex++;
    }

    // Deleta o cenário mais antigo para otimizar performance
    private void DeleteOldestScenario()
    {
        if (_activeScenarios.Count > numberOfScenariosAhead)
        {
            Destroy(_activeScenarios[0]);
            _activeScenarios.RemoveAt(0);
        }
    }
}
