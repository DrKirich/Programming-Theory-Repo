using UnityEngine;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Material[] materials;
    [SerializeField] private Stuff[] stuffPrefabs;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverPanel;
    private float xRange = 8;
    private float yPosition = 7;
    private float spawnWaitTime = 2;
    public bool isGameActive = true;
    private int score;

    public Material[] Materials // Encapsulation
    {
        get { return materials; }
    }

    private void Awake()
    {
        if (Instance != null)
            return;

        Instance = this;
    }
    private void Start()
    {
        AddScore(0);
        StartCoroutine(SpawnStuff());
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        isGameActive = false;
        gameOverPanel.SetActive(true);
    }

    private IEnumerator SpawnStuff()
    {
        while (isGameActive)
        {
            int random = Random.Range(0, stuffPrefabs.Length);
            Instantiate(stuffPrefabs[random], new Vector3(Random.Range(-xRange, xRange), yPosition), stuffPrefabs[random].transform.rotation);

            yield return new WaitForSeconds(spawnWaitTime);
        }
    }
}
