using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject CheckPoint1;
    public GameObject CheckPoint2;
    private GameObject SpawnPoint;
    public Text DeathCountText;
    private int DeathCount;
    
    
    void Start()
    {
        SpawnPoint = CheckPoint1;
        DeathCount = 0;
        SetDeathCountText();
    }

    // Destroy everything that enters the trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")|| other.gameObject.CompareTag("Undestroyable Enemy"))
        {
            transform.position = SpawnPoint.transform.position;//(where you want to teleport)
            DeathCount += 1;
            SetDeathCountText();
        }

        if (other.gameObject.CompareTag("Checkpoint"))
        {
            SpawnPoint = other.gameObject;//(Change the teleport)
        }

    }

    void SetDeathCountText()
    {
        DeathCountText.text = "Deaths: " + DeathCount.ToString();
    }
}