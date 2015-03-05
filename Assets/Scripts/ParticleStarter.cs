using UnityEngine;
using System.Collections;

public class ParticleStarter : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // START DAT FUCKING PARTICLES
        GetComponent<ParticleSystem>().Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
