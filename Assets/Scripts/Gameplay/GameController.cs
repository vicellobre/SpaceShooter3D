using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Enemies")]
    [SerializeField]
    private GameObject[] hazards;
    [SerializeField]
    private Vector3 spawnValues;
    [SerializeField]
    private int hazardCount;
    [SerializeField]
    private float spawnWait, startWait, waveWait;

    [Header("Points")]
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text recordText;
    private string copyScoreText;
    private int score;
    private int record;
    

    [Header("GameOver")]
    [SerializeField]
    private GameObject restartGameObject;
    [SerializeField]
    private GameObject gameOverGameObject;
    [SerializeField]
    private GameObject HomeMenuGameObject;
    private bool restart, gameOver;

    private void Start() {
        UpdateSpawnValues();
        restart = gameOver = false;
        copyScoreText = scoreText.text + ": ";
        UpdateScore();
        Invoke("Record", 0.1f);
        StartCoroutine(SpawnWaves());

    }

    private void Update() {
        if (restart && Input.GetKeyDown(KeyCode.R))
            Restart();
    }

    private IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(hazards[Random.Range(0, hazards.Length)], spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver) break;
        }
    }

    private void UpdateSpawnValues()
    {
        Vector2 half = Utils.GetHalfDimensionsInWorldUnits();
        Vector3 spawValues = new Vector3(half.x - 0.7f, 0f, half.y + 6);
    }
    private void UpdateScore() {
        scoreText.text = copyScoreText + score.ToString();
    }

    private void EnableButtons()
    {
        restartGameObject.SetActive(true);
        HomeMenuGameObject.SetActive(true);
        restart = true;
    }

    private void Record()
    {
        record = PlayerPrefs.GetInt("HighScore", 0);
        if (record == 0)
        {
            scoreText.rectTransform.position = recordText.rectTransform.position;
            recordText.gameObject.SetActive(false);
        }
        else
        {
            recordText.text += ": " + record.ToString();
        }
    }

    private void NewRecord()
    {
        copyScoreText = LanguageManager.instance.GetLocalizedValue("NewBestScore") + ": ";
        scoreText.color = Color.yellow;
        recordText.color = Color.red;
    }
            
    private void SetHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }
    }

    public void AddScore(int value) {
        score += value;
        if (score > record && record > 0) NewRecord();
        UpdateScore();
    }

    public void GameOver() {
        gameOverGameObject.SetActive(true);
        gameOver = true;

        Invoke("SetHighScore", 1);
        Invoke("EnableButtons", 3);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HomeMenu()
    {
        MenuManager.GoToMenu(MenuName.HomeMenu);
    }
}
