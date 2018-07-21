using UnityEngine;
using System.Collections;

public class SoundScript : MonoBehaviour {

    public Activator activator;
    AudioSource sounder;
    public float offset;
    public float scalar;
    public float maxSpeed;
    float min;
    bool allowed;
    public float timeGap;
    float currTime;

    // Use this for initialization
    void Start () {
        //print("Initializing: " + transform.parent.name);
        sounder = GetComponent<AudioSource>();
        if (sounder == null)
        {
            Debug.Log("AudioSource is still null for object: " + transform.name);
        }
        min = -offset;
        allowed = true;
        currTime = Time.fixedTime;

        string fileName = transform.parent.name;
        //print(fileName);
        AudioClip sound = Resources.Load<AudioClip>(fileName);
        if (sound == null)
        {
            Debug.Log("Couldn't find resource, which is a problem.");
        }
        sounder.clip = sound;
        if (sounder.clip == null)
        {
            Debug.Log("We've got more problems.");
        }
	}
	
	// Sounds when key enters trigger zone
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
        {
            //print("Key entered trigger.");
            if (true) //(Time.fixedTime - currTime > timeGap)
            {
                //print("Passed time test.");
                currTime = Time.fixedTime;
                if (true)
                {
                    //print("Allowed to enter.");
                    allowed = false;
                    activator.ready = false;
                    double speed = other.GetComponent<Rigidbody>().velocity.magnitude;
                    //print("Detected speed: " + speed);
                    double value = scalar * speed - offset;
                    double vol = (value - min) / (maxSpeed - min);
                    if (sounder == null)
                    {
                        Debug.Log("BAD STUFF HAPPENED");
                    }
                    sounder.volume = (float) vol;
                    //print("Playing sound at volume: " + vol);
                    sounder.Play();
                }
            }
        }
    }

    // Releases lock when key leaves trigger zone
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Key")
        {
            allowed = true;
        }
    }
}
