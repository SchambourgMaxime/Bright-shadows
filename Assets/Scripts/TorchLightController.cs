﻿using System;
using UnityEngine;
using System.Collections;
using System.Net.Sockets;

public class TorchLightController : MonoBehaviour
{

    public float upperLimitHeight = 2.0f;
    public float lowerLimitHeight = -2.0f;

    public float speed;

    public float delayDamage;

    private float cumulatedTime = 0;

    private float currentHeight;
    private Transform myTransform, parentTransform;

    public float lightDamageStrength = 1.0f;

	// Use this for initialization
	void Start ()
	{
	    currentHeight = 0.0f;
	    myTransform = transform;
	}

	// Update is called once per frame
	void Update ()
	{
	    Vector3 lookAtTarget = Vector3.forward*2;

	    currentHeight += Input.GetAxis("Mouse Y") * speed * Time.deltaTime;
		Debug.Log (currentHeight);
	    currentHeight = Mathf.Clamp(currentHeight, lowerLimitHeight, upperLimitHeight);

        lookAtTarget = myTransform.parent.TransformPoint(lookAtTarget + myTransform.localPosition);
	    lookAtTarget.y += currentHeight;

	    myTransform.LookAt(lookAtTarget);
	}

    void OnTriggerStay(Collider Other)
    {

        cumulatedTime += Time.deltaTime;

        if (cumulatedTime > delayDamage)
        {
            if (Other.gameObject.CompareTag("Enemy"))
            {
                Other.gameObject.GetComponent<EnemyBehaviour>().ReceiveLightDamage(lightDamageStrength);
            }

			Debug.Log("bim");

            cumulatedTime = 0;
        }

    }

}
