using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    
void OnCollisionEnter(Collision col)
{
    
    if(col.gameObject.tag == "Platform")
    {
        //col.gameObject.transform.SetParent(gameObject.transform, true);
        transform.parent = col.gameObject.transform;
        Debug.Log("We are on a moving platform");
    }

}

void OnCollisionExit(Collision col)
{
    
    
    if(col.gameObject.tag == "Platform")
    {
        //col.gameObject.transform.parent = null;
        transform.parent = null;
    }

}
}
