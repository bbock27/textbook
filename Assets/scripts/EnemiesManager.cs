using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemiesManager : MonoBehaviour
{
    
    public static EnemiesManager instance;
    public UnityEvent onChanged;

    public List<Enemy> enemies;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("There can only be one instance of EnemiesManager", gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
        onChanged.Invoke();
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
        onChanged.Invoke();
    }
}
