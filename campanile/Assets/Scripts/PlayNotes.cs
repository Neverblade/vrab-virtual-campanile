using UnityEngine;
using System.Collections;

public class PlayNotes : MonoBehaviour {

    public GameObject[] keys;
    public GameObject key;
    public float strength;
    public float intensity;

	// Update is called once per frame
	void Update () {
	    for (int i = 0; i < keys.Length; i++)
        {
            if (Input.GetKey("" + i))
            {
                keys[i].transform.Find("KeyObject").GetComponent<Rigidbody>().AddForce(0, -strength, 0, ForceMode.Force);
                MeshRenderer renderer = keys[i].transform.Find("KeyObject").GetComponent<MeshRenderer>();
                foreach (Material mat in renderer.materials)
                {
                    mat.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                    mat.EnableKeyword("_EMISSION");
                    mat.SetColor("_EmissionColor", Color.green);
                    mat.SetFloat("_EmissionMap", 10f);
                }
                DynamicGI.SetEmissive(renderer, Color.green * 10f);
                DynamicGI.UpdateMaterials(renderer);
                DynamicGI.UpdateEnvironment();
                print("Played: " + keys[i].name);
            }
        }
    }
}
