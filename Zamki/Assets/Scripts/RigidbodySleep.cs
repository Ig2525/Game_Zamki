using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodySleep : MonoBehaviour
{

    
    void Start()
    {
        // Это заставит твердое тело Rigidbody стены Wall предполагать, что оно не должно никуда двигаться
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null) rb.Sleep();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
