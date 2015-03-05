﻿using UnityEngine;
using System.Collections;

public class FlyingEnemyBehavior : EnemyBehaviour {

    public static float fearRate { get; set; }
    
	[SerializeField] private float movementSpeed;
	
	// Use this for initialization
	void Start () {
        fearRate = _initialFearRate;
        Init();

		transform.eulerAngles = new Vector3(Random.Range(transform.eulerAngles.x-20.0f, transform.eulerAngles.x+20.0f), 90.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * Time.deltaTime * movementSpeed);
	}

	
	void OnCollisionEnter(Collision collision){
		GameObject collisionObject = collision.gameObject;
		if(collisionObject.CompareTag("Enemy") || collisionObject.CompareTag("Player"))
			Physics.IgnoreCollision (collision.collider, transform.collider);
		else if(collisionObject.CompareTag("Platform"))
			transform.eulerAngles = new Vector3(Random.Range(transform.eulerAngles.x+160.0f, transform.eulerAngles.x+200.0f), 90.0f, 0.0f);
		else
			transform.eulerAngles = new Vector3(Random.Range(collision.transform.forward.x-10.0f, collision.transform.forward.x+10.0f), 90.0f, 0.0f);
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
