using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSystem : MonoBehaviour
{
    private int spellcount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
{
    Debug.Log("item");
    if(other.transform.tag == "pickup")
    {
        Destroy(other.gameObject);
        spellcount = spellcount +1;
        Debug.Log(spellcount);
    }
}
}
