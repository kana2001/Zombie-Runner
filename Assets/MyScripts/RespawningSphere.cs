using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RespawningSphere : MonoBehaviour
{
    public GameObject SpawnPoint;

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
        if (other.gameObject.CompareTag("Box"))
        {
            transform.position = SpawnPoint.transform.position;//(where you want to teleport)
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            transform.position = SpawnPoint.transform.position;//(where you want to teleport)
        }

    }
}
