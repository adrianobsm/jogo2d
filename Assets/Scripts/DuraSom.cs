using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuraSom : MonoBehaviour
{
    private float tempo = 1.5f;
    

    void Update()
    {
        tempo -= Time.deltaTime;    
        if(tempo<=0){
            Destroy(this.gameObject);
        }
    }
}
