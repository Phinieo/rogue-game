using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        if (target == null) {

            target = GameObject.Find("Character");

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y,-10f);
    }

}
