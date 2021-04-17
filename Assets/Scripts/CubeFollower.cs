using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFollower : MonoBehaviour
{

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).rotation = player.transform.rotation * Quaternion.Euler(15, 90, 0);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        transform.rotation = player.transform.rotation; // * Quaternion.Euler(15, 90, 0)
    }
}
