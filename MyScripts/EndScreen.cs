using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public string levelToLoad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Use"))
        {
            Application.LoadLevel(levelToLoad);
        }

        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }

    }
}
