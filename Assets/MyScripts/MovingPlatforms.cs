using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingPlatforms : MonoBehaviour
{
    public float min = 2f;
    public float max = 3f;
    public float extend = 10f;
    public float retract = 5f;	

    // Start is called before the first frame update
    void Start()
    {
        min = transform.position.x - retract;
        max = transform.position.x + extend;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * 2, max - min) + min, transform.position.y, transform.position.z);
    }
}
