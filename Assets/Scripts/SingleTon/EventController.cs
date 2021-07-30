using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventController : MonoBehaviour
{
    public delegate void OntargetImageLost();
    public static event OntargetImageLost ON_TARGET_LOST;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTarGetLostEvnt(){
        ON_TARGET_LOST?.Invoke();
    }
    
}
