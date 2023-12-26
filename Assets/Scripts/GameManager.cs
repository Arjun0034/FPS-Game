using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int enemiesAlive = 0;
    public int round = 0;

    public GameObject[] spawnpoints;
    public GameObject enemyPrefab;
    public GameObject endScreen;
    

    public Text roundNumber;
    public Text roundsSurvived;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesAlive == 0)
        {
            round++;
            NextWave(round);
            roundNumber.text = "Round: " + round.ToString();
        }
    }

    public void NextWave(int round)
    {
        for(var x = 0; x < round; x++)
        {

        GameObject spawnPoint = spawnpoints[Random.Range(0, spawnpoints.Length)];

        GameObject enemySpawned = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
        enemySpawned.GetComponent<enemyManager>().gameManager = GetComponent<GameManager>();
        enemiesAlive++;

        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        Cursor.lockState = CursorLockMode.Locked;
        endScreen.SetActive(false);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None ;
        endScreen.SetActive(true);
        roundsSurvived.text = round.ToString();
    }

   
}
