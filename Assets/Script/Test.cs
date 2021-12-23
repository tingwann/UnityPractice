using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    //public Vector3 Movedirection;
    //public Vector3 Movedirection2;
    //public Vector3 Movedirection3;
    //public Vector3 Movedirection4;
    [SerializeField] float MovingSpeed = 10f;
    MeshRenderer mr;
    void Awake()
    {
        Debug.Log("Awake");
    }
    void Start()
    {
        Debug.Log("Start");
        Transform t = GetComponent<Transform>();
         mr = GetComponent<MeshRenderer>();

        //t.position = Vector3.one;
        //transform.position = Vector3.one;      
    }
  

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
        //transform.localPosition += MovingSpeed * Time.deltaTime * Movedirection;
        //mr.material.color = new Color((int)Time.time % 2* 255f, 255f, 255f);
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += MovingSpeed * Time.deltaTime * Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += MovingSpeed * Time.deltaTime * Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += MovingSpeed * Time.deltaTime * Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += MovingSpeed * Time.deltaTime * Vector3.right;
        }
    }
}
