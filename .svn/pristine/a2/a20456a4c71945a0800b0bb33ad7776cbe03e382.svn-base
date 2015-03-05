using UnityEngine;
using System.Collections;

public class ArchenemyBehavior : MonoBehaviour {
	public GameObject playerReference;
	public float movementSpeed;
	private bool touchedPlayer;
	// Use this for initialization
	void Start () {
		touchedPlayer = false;
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (playerReference.transform);
		transform.Translate (Vector3.forward * Time.deltaTime * movementSpeed);
	}

	void OnTriggerEnter(Collider collision){
		if (collision.CompareTag ("Player"))
			UIManager.instance.GameOver ();
	}

}
