using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update

    public static CameraController instance;
    public float moveSpeed;
    public Transform target;

    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x,target.position.y,transform.position.z),moveSpeed*Time.deltaTime);
        }
        
        
    }

    public void ChangeTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
