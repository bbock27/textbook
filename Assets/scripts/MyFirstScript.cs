using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstScript : MonoBehaviour
{

    public float speed;
    [SerializeField]
    private float speedPrivate;
    // Start is called before the first frame update
    void Start()
    {
        print("test start");
    }

    // Update is called once per frame
    void Update()
    {
        // print("test");
    }

    void OnDestroy(){
        print("destroy");
    }
}
