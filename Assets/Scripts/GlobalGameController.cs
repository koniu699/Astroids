using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalGameController : MonoBehaviour
{
    [SerializeField]
    int meteorsPerLevel;
    [SerializeField]
    int pointsPerMeteor;
    [SerializeField]
    Canvas gameOverCanvas;
    [SerializeField]
    Text pointsText;
    [SerializeField]
    Text gameOverText;
    [SerializeField]
    string gameOverString;

    static GlobalGameController instance;

    public static GlobalGameController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectsOfType<GlobalGameController>()[0];
            }
            return instance;
        }
    }

    List<MeteorSpawner> meteorSpawners = new List<MeteorSpawner>();
    List<MeteorController> meteorsInPlay = new List<MeteorController>();
    int gameLevel = 0;
    GameObject playerShip;
    ShipStatsController shipStats;

    private void Start()
    {
        pointsText.text = "0";
    }

    public void RegisterPlayer(GameObject player)
    {
        if (playerShip != null)
            return;
        playerShip = player;
        shipStats = playerShip.GetComponent<ShipStatsController>();
        playerShip.GetComponent<ShipLifeController>().onDeathAction += OnDeathAction;
    }

    public void RegisterMeteorSpawner(MeteorSpawner spawner)
    {
        meteorSpawners.Add(spawner);
    }

    public void RegisterMeteorInPlay(MeteorController meteor)
    {
        meteorsInPlay.Add(meteor);
    }

    public void RemoveMeteorFromPlay(MeteorController meteor)
    {
        if (meteorsInPlay.Contains(meteor))
        {
            meteorsInPlay.Remove(meteor);
            shipStats.AwardPoints(pointsPerMeteor);
            pointsText.text = shipStats.Points.ToString();
        }
        if (meteorsInPlay.Count <= 0)
        {
            foreach (var spawner in meteorSpawners)
            {
                spawner.MeteorCount += gameLevel * meteorsPerLevel;
                spawner.SpawnMeteors();
			}
            gameLevel++;
        }
    }

    void OnDeathAction()
    {
        gameOverText.text = string.Format(gameOverString, shipStats.Points.ToString());
        gameOverCanvas.gameObject.SetActive(true);
    }

    public void RestartGame()
	{
		meteorsInPlay = new List<MeteorController>();
		meteorSpawners = new List<MeteorSpawner>();
		playerShip = null;
		shipStats = null;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
