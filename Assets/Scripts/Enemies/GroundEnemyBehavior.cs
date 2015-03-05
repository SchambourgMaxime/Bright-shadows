using UnityEngine;
using System.Collections;

public class GroundEnemyBehavior : EnemyBehaviour {

    public LayerMask raycastLayerMask;

	[SerializeField] private float movementSpeed;

    public float HealthPoints;
    public int damage;

    private bool dead;

    private float direction;

    public Transform spiderMesh;

    private Quaternion targetRotation;
    private Transform myTransform;

	// Use this for initialization
	void Start ()
	{
	    direction = 1.0f;
	    myTransform = transform;
	}
	
    void FixedUpdate()
    {
        RaycastHit hit;
        Debug.DrawRay(myTransform.position + Vector3.up, direction * transform.forward * 0.6f, Color.red);
        if (Physics.Raycast(myTransform.position + Vector3.up, direction * transform.forward, out hit, 0.6f, raycastLayerMask.value))
        {
            direction *= -1.0f;
            if (hit.collider.CompareTag("Player") && !dead)
                hit.collider.GetComponent<PlayerController>().loseLife(damage);
        }
            
    }

	// Update is called once per frame
    private void Update()
    {
        spiderMesh.localRotation = Quaternion.Slerp(spiderMesh.localRotation, targetRotation, 5.0f * Time.deltaTime);

        if (direction < 0.0f)
            targetRotation = Quaternion.Euler(new Vector3(0.0f, 180.0f, 0.0f));
        else
            targetRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));

        myTransform.Translate(direction * Vector3.forward * Time.deltaTime * movementSpeed);
    }

	public override float GetFearFactor()
	{
		return 0.0f;
	}

	public override void OnFearConquered()
	{

	}

    public override void ReceiveLightDamage(float damageValue)
    {
        HealthPoints -= damageValue;
        if (HealthPoints < 0 && !dead)
        {
            animation.Play("death" + Random.Range(1, 3));
            movementSpeed = 0;
            GetComponent<BoxCollider>().isTrigger = true;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
            dead = true;
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerController>().KillReward(1);
        }
    }
}
