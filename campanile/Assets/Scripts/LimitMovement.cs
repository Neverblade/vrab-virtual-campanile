using UnityEngine;
using System.Collections;

public class LimitMovement : MonoBehaviour {

    public float maxUp;
    public float maxDown;
    float x, y, z;

	// Use this for initialization
	void Start () {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        float ny = transform.position.y;
        if (ny > y + maxUp)
        {
            transform.position = new Vector3(transform.position.x, y + maxUp, transform.position.z);
        }
        if (ny < y - maxDown)
        {
            transform.position = new Vector3(transform.position.x, y - maxDown, transform.position.z);
        }
	}
}
