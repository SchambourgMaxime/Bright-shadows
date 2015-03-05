﻿using UnityEngine;
using System.Collections;

public class SpiderBehavior : EnemyBehaviour {

    public static float fearRate { get; set; }

	[SerializeField] private float movementSpeed;
	private bool isForward;
	private Vector3 currentDirection;
	private bool playerInSight;
	private float initialY;
	private bool beenDownYet;
	[SerializeField] private float minYDescente;
	[SerializeField] private float upDownSpeed;

	// Use this for initialization
	void Start () {
        fearRate = _initialFearRate;
        Init();
		initialY = transform.position.y;
		beenDownYet = false;
        // fuck
	}
	
	// Update is called once per frame
	void Update () {

		//transform.eulerAngles=new Vector3(0.0f, 90.0f, 0.0f); //c'est dégueulasse, mais sinon l'araignée tombe

		if (!playerInSight) {
				transform.Translate (Vector3.forward * Time.deltaTime * movementSpeed);
		} else {
			if(transform.position.y > minYDescente && !beenDownYet){
				transform.Translate (Vector3.down * upDownSpeed);
				if (transform.position.y<= minYDescente){
					beenDownYet=true;
				}
			}
			else if(transform.position.y < initialY){
				transform.Translate (Vector3.up * upDownSpeed);
				if(transform.position.y>= initialY){
					beenDownYet=false;
					playerInSight=false;
				}

			}
		}
	}
	

	
	void OnCollisionEnter(Collision collision){
		GameObject collisionObject = collision.gameObject;
		if (collisionObject.CompareTag ("Enemy") || collisionObject.CompareTag ("Player"))
			Physics.IgnoreCollision (collision.collider, transform.collider);


	}

	void OnTriggerEnter(Collider collision){
		GameObject collisionObject = collision.gameObject;
		if (collisionObject.CompareTag ("Player"))
			playerInSight = true;
	}

    public override float GetFearFactor()
    {
        return fearRate;
    }

    public override void OnFearConquered()
    {
        // Do some shit like decrease fear rate
    }

    public override void ReceiveLightDamage(float damageValue)
    {
        
    }
}
