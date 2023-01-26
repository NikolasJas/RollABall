using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public GameObject collectable;
    public int collectablesCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        { 
            collectablesCount = 1;
            //if a collision with the player occurs, do this.  This can be used to load the next scene.
            Debug.Log("Level Finished");
            //next.gameObject.SetActive(true);
            Destroy(gameObject);
           
        }
    }
}
