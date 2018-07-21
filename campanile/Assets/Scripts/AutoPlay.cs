using UnityEngine;
using System.Collections;

public class AutoPlay : MonoBehaviour {

    public float timeSpace;
    GameObject key;
    Rigidbody rb;
    float delta;

	// Use this for initialization
	void Start () {
        key = transform.Find("KeyObject").gameObject;
        rb = key.GetComponent<Rigidbody>();
        delta = Time.time;
	}

    public void play(float thrust)
    {
        if (Time.time - delta > timeSpace)
        {
            Debug.Log("Forced applied. Val: " + thrust);
            rb.AddForce(0, -thrust, 0, ForceMode.Impulse);
            delta = Time.time;
        }
        
    }
}
