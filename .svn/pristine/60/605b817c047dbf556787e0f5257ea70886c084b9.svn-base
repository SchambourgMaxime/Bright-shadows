using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

    public GameObject ItemGiven;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider Other)
    {
        GameObject toucher = Other.gameObject;
        if(toucher.CompareTag("Player"))
        {
            toucher.GetComponent<PlayerController>().GetItem(ItemGiven.transform);
            //Destroy(this.gameObject);
        }
    }
}
