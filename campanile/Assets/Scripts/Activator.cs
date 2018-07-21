using UnityEngine;
using System.Collections;

public class Activator : MonoBehaviour {

    public bool ready;

	// Use this for initialization
	void Start () {
        this.ready = false;
	}

    // Allows sound to activate upon entry
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
        {
            Debug.Log("Entered activation zone.");
            ready = true;
        }
        
    }

    // Deactivates sound on exit
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Key")
        {
            Debug.Log("Exited activation zone.");
            ready = false;
        }
    }
}
