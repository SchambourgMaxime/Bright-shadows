using UnityEngine;
using System.Collections;

public class RandomSpawn : MonoBehaviour {
    public int nbSpawn=1;
    public LucioleBehavior luciole;
    public GameObject player;// Use this for initialization
	void Start () {
        for (int i = 0;i<nbSpawn;i++){
            float x = Random.Range(1.0f, 296.0f);
            float y = Random.Range(1.0f, 50.0f);
            float z = 5.0f;
            Vector3 spawnPosition = new Vector3(x-148,y,z); //spawnPosition
            float v = Random.Range(1.0f, 5.0f); //vitesse
            float l = Random.Range(10.0f, 50.0f); //vie
           // int id = Random.Range(1, 5); //id mob
            spawnNewMob(spawnPosition, v, l);
        }
	
	}

    private void spawnNewMob(Vector3 position, float speed, float life)
    {
        LucioleBehavior lulu = Instantiate(luciole, position, Quaternion.identity) as LucioleBehavior;
        lulu.create(speed, life, player);
    }


	// Update is called once per frame
	void Update () {
	
	}
}
