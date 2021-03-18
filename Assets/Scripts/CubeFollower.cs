using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFollower : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset = new Vector3(-5, 3);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
