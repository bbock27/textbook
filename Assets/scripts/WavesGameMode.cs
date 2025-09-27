using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WavesGameMode : MonoBehaviour
{

    [SerializeField] private Life playerLife;

    [SerializeField] private Life playerBaseLife;
    // Start is called before the first frame update
    void Start()
    {
        EnemiesManager.instance.onChanged.AddListener(CheckWinCondition);
        WavesManager.instance.onChanged.AddListener(CheckWinCondition);
    }

    void Awake()
    {
        playerLife.onDeath.AddListener(OnPlayerOrBaseDied);
        playerBaseLife.onDeath.AddListener(OnPlayerOrBaseDied);
    }

    void OnDestroy()
    {
        playerLife.onDeath.RemoveListener(OnPlayerOrBaseDied);
        playerBaseLife.onDeath.RemoveListener(OnPlayerOrBaseDied);
        
    }

    // Update is called once per frame
    void CheckWinCondition()
    {
        if (EnemiesManager.instance.enemies.Count <= 0 &&
            WavesManager.instance.waves.Count <= 0)
        {
            SceneManager.LoadScene("WinScene");
        }
        
    }

    void OnPlayerOrBaseDied()
    {
        SceneManager.LoadScene("LoseScene");
    }
}
