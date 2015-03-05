﻿using UnityEngine;
using System.Collections;

struct FlashlightData
{
    public float radius1;
    public float radius2;
    public float z1;
    public float z2;
    public float spotAngle;
    public float range;
    public float intensity;
}

public class PlayerController : MonoBehaviour
{

    public float walkSpeed = 5.0f;
    public float runSpeed = 7.0f;

    public float jumpSpeed = 15.0f;
    public float gravity = 10.0f;

    public Transform SocketPosition;
    public Transform TorchSpawnPosition;

    private int XP;
    public int level;

    public int palierLevelUp;

    private int life;
    public int baseLife;
    private int maxLife;

    private FlashlightData FSData;

    // Use this for initialization
    private void Start()
    {
        life = maxLife = baseLife;
        level = 1;

        UIManager.instance.AddHearts(maxLife);

        FSData.radius1 = 0.9f;
        FSData.z1 = 3.5f;

        FSData.radius2 = 0.5f;
        FSData.z1 = 2.0f;

        FSData.spotAngle = 30;
        FSData.range = 4;

        FSData.intensity = 0.5f;

        initiateFlashlight();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            level++;
            LevelUp();
        }
    }



    private void LevelUp()
    {
		if(level==4)
			UIManager.instance.WinGame();

        GameObject TorchLight = null;

        if (GetComponentInChildren<TorchLightController>() != null)
        {
            TorchLight = GetComponentInChildren<TorchLightController>().gameObject;
        }

        switch (level % 3)
        {
            case 0 :
                if (TorchLight != null)
                {
                    TorchLight.GetComponent<TorchLightController>().lightDamageStrength += 1.0f;
                }
                break;
            case 1 :
                maxLife += 1;
                break;
            case 2 :
                Light[] lightTab;

                Light backLight = null;

                lightTab = GetComponentsInChildren<Light>();

                for (int i = 0; i < lightTab.Length; i++)
                {
                    if (lightTab[i].gameObject.CompareTag("SpotLightPlayer"))
                        backLight = lightTab[i];
                }

                if (backLight != null)
                {
                    backLight.intensity += ((15/100)*backLight.intensity);
                    backLight.spotAngle += 10;
                }

                switch (level)
                {
                    case 2 :

                        FSData.radius1 = 0.9f;
                        FSData.z1 = 3.5f;

                        FSData.radius2 = 0.5f;
                        FSData.z1 = 2.0f;

                        FSData.spotAngle = 30;
                        FSData.range = 4;

                        FSData.intensity = 0.5f;

                        //TorchLight.GetComponents<SphereCollider>()[0].radius = 0.9f;
                        //TorchLight.GetComponents<SphereCollider>()[0].center = new Vector3(0.0f, 0.0f, 3.5f);

                        //TorchLight.GetComponents<SphereCollider>()[1].radius = 0.5f;
                        //TorchLight.GetComponents<SphereCollider>()[1].center = new Vector3(0.0f, 0.0f, 2.0f);

                        //lightTab = TorchLight.GetComponentsInChildren<Light>();

                        //if (lightTab[0].type == LightType.Spot)
                        //{
                        //    lightTab[0].spotAngle = 30;
                        //    lightTab[0].range = 4;
                        //}
                        //else
                        //{
                        //    lightTab[1].spotAngle = 30;
                        //    lightTab[1].range = 4;
                        //}

                        //lightTab[0].intensity = lightTab[1].intensity = 0.5f;

                        break;
                    case 5 :

                        FSData.radius1 = 1.3f;
                        FSData.z1 = 3.9f;

                        FSData.radius2 = 0.7f;
                        FSData.z1 = 2.0f;

                        FSData.spotAngle = 40;
                        FSData.range = 5;

                        FSData.intensity = 1.0f;

                        //TorchLight.GetComponents<SphereCollider>()[0].radius = 1.3f;
                        //TorchLight.GetComponents<SphereCollider>()[0].center = new Vector3(0.0f, 0.0f, 3.9f);

                        //TorchLight.GetComponents<SphereCollider>()[1].radius = 0.7f;
                        //TorchLight.GetComponents<SphereCollider>()[1].center = new Vector3(0.0f, 0.0f, 2.0f);

                        //lightTab = TorchLight.GetComponentsInChildren<Light>();

                        //if (lightTab[0].type == LightType.Spot)
                        //{
                        //    lightTab[0].spotAngle = 40;
                        //    lightTab[0].range = 4;
                        //}
                        //else
                        //{
                        //    lightTab[1].spotAngle = 40;
                        //    lightTab[1].range = 4;
                        //}

                        //lightTab[0].intensity = lightTab[1].intensity = 1.0f;
                        break;
                    case 8 :

                        FSData.radius1 = 1.7f;
                        FSData.z1 = 4.7f;

                        FSData.radius2 = 0.8f;
                        FSData.z1 = 2.2f;

                        FSData.spotAngle = 45;
                        FSData.range = 6;

                        FSData.intensity = 2.0f;

                        //TorchLight.GetComponents<SphereCollider>()[0].radius = 1.7f;
                        //TorchLight.GetComponents<SphereCollider>()[0].center = new Vector3(0.0f, 0.0f, 4.7f);

                        //TorchLight.GetComponents<SphereCollider>()[1].radius = 0.8f;
                        //TorchLight.GetComponents<SphereCollider>()[1].center = new Vector3(0.0f, 0.0f, 2.2f);

                        //lightTab = TorchLight.GetComponentsInChildren<Light>();

                        //if (lightTab[0].type == LightType.Spot)
                        //{
                        //    lightTab[0].spotAngle = 45;
                        //    lightTab[0].range = 6;
                        //}
                        //else
                        //{
                        //    lightTab[1].spotAngle = 45;
                        //    lightTab[1].range = 6;
                        //}

                        //lightTab[0].intensity = lightTab[1].intensity = 2.0f;
                        break;
                }
                break;
        }

        UIManager.instance.AddHearts(maxLife - life);

        life = maxLife;
    }

    private void initiateFlashlight()
    {
        GameObject TorchLight;

        if (GetComponentInChildren<TorchLightController>() != null)
        {
            TorchLight = GetComponentInChildren<TorchLightController>().gameObject;

            Light[] lightTab;

            TorchLight.GetComponents<SphereCollider>()[0].radius = FSData.radius1;
            TorchLight.GetComponents<SphereCollider>()[0].center = new Vector3(0.0f, 0.0f, FSData.z1);

            TorchLight.GetComponents<SphereCollider>()[1].radius = FSData.radius2;
            TorchLight.GetComponents<SphereCollider>()[1].center = new Vector3(0.0f, 0.0f, FSData.z2);

            lightTab = TorchLight.GetComponentsInChildren<Light>();

            if (lightTab[0].type == LightType.Spot)
            {
                lightTab[0].spotAngle = FSData.spotAngle;
                lightTab[0].range = FSData.range;
            }
            else
            {
                lightTab[1].spotAngle = FSData.spotAngle;
                lightTab[1].range = FSData.range;
            }

            lightTab[0].intensity = lightTab[1].intensity = FSData.intensity;
        }
    }

    public void GetItem(Transform item)
    {
		GameObject flashLight;

        if (GetComponentInChildren<TorchLightController>() == null)
        {
            Transform newItem = Instantiate(item.transform, TorchSpawnPosition.position, item.transform.rotation) as Transform;
            AnimationHandler animationHandler = GetComponentInChildren<AnimationHandler>();
            animationHandler.activateIK = true;
            newItem.parent = animationHandler.transform;
			//initiateFlashlight();
        }


    }

    public void loseLife(int lifeLost)
    {
        GameObject TorchLight;

        if (GetComponentInChildren<TorchLightController>() != null)
        {
            TorchLight = GetComponentInChildren<TorchLightController>().gameObject;

            if (Random.Range(0, 4) == 0)
            {
                Destroy(TorchLight);

                GetComponentInChildren<AnimationHandler>().activateIK = false;
            }
        }

        life -= lifeLost;

        for (int i = 0; i < lifeLost; i++)
            UIManager.instance.RemoveHeart();

        if (life <= 0)
            UIManager.instance.GameOver();
    }

    public void KillReward(int XPGagne)
    {
        XP += XPGagne;
        if (XP > level*palierLevelUp)
        {
            level++; // YEAH!

            LevelUp();

        }
    }

    public int getLife()
    {
        return life;
    }
}
