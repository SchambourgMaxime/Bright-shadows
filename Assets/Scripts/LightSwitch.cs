using UnityEngine;
using System.Collections;

public class LightSwitch : MonoBehaviour {

    bool wasGrounded;

	// Use this for initialization
	void Start () {
        wasGrounded = true;
	}
	
	// Update is called once per frame
    void Update()
    {
        Debug.Log(GetComponentInParent<CharacterController>().isGrounded + ", " + wasGrounded);

        

       if (GetComponentInParent<CharacterController>().isGrounded && !wasGrounded)
       {
           foreach (Light light in GetComponentsInChildren<Light>())
                light.enabled = true;
           wasGrounded = true;
       }

       if (Input.GetButtonDown("Jump") && GetComponentInParent<CharacterController>().isGrounded)
       {
           foreach (Light light in GetComponentsInChildren<Light>())
               light.enabled = false;
           wasGrounded = false;
       }
    }
}
