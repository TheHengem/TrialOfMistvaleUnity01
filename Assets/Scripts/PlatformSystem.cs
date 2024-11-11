using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSystem : MonoBehaviour
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

    private IEnumerator OnTriggerEnter(Collider other)
{
    Debug.Log("Touched Platform");
    if(other.transform.tag == "Platform")
    {
        yield return new WaitForSeconds(1f);
        Destroy(other.gameObject);
        Debug.Log("DESTROYED PLATFORM");
    }
}
}
