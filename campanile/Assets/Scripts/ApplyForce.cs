using UnityEngine;
using System.Collections;

public class ApplyForce : MonoBehaviour {

    public float thrust;
    public Rigidbody rb;
    public AudioSource sound;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("ApplyForce Update Pushed w/ Key Down");
            print("Force applied.");
            rb.AddForce(thrust, thrust, thrust, ForceMode.Impulse);
            sound.Play();
        }
	}
}
