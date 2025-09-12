using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject spawnLoaction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKey(KeyCode.Mouse0)){
        //     GameObject bullet = Instantiate(bulletPrefab, spawnLoaction.transform.position, spawnLoaction.transform.rotation);
        // }
    }

    public void OnFire(){
        GameObject clone = Instantiate(bulletPrefab, spawnLoaction.transform.position, spawnLoaction.transform.rotation);
    }
}
