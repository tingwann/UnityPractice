using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    //public GameObject player;
    void Start()
    {
        //if(player.transform.position.y < -10)
        DontDestroyOnLoad(gameObject);
    }
}
