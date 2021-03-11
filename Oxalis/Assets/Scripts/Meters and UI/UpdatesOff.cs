using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatesOff : MonoBehaviour
{
    float timer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.unscaledDeltaTime;
        if (timer < 0)
        {
            gameObject.SetActive(false);
            timer = 5f;
        }
    }
}
