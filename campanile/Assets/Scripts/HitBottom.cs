using UnityEngine;
using System.Collections;

public class HitBottom : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
        {
            Debug.Log("Stopping key momentum.");
            other.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
}
