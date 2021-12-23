using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public float turnSpeed = 90f;
    private void OnTriggerEnter(Collider other)
    {
        //Check that the object we collided with is the player
        //if(other.gameObject.GetComponent<Obstacle>())
        if(other.gameObject.name != "viking")
        {
            return;
        }

        //Add to the Player's scare
        GameManager.inst.IncrementScore();
        //Destroy this coin object
        Destroy(gameObject);
    }
    void Start()
    {
        
            
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(turnSpeed * Time.deltaTime , 0 ,0);

    }
}
