using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamager : MonoBehaviour
{
    public int damage = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Life life = other.GetComponent<Life>();
        
        if (life != null)
        {
            life.amount -= damage;
            Debug.Log("damage dealt to", other.gameObject);
        }
    }
}
