using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnDeath : MonoBehaviour
{
    
    public int amount = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        var life = GetComponent<Life>();
        life.onDeath.AddListener(GivePoints);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GivePoints()
    {
        ScoreManager.instance.amount += amount;
    }

    void OnDestroy()
    {
        var life = GetComponent<Life>();
        life.onDeath.RemoveListener(GivePoints);
    }
}
