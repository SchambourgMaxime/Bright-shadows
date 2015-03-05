using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    [SerializeField]
    private float _relaxSpeed = 20.0f;
    public Transform archenemy;
	private float _fearLevel;
	private bool _shatHimself;

    public float fearLevel
    {
        get { return _fearLevel; }
        set
        { 
            if (!_shatHimself)
                _fearLevel = value;
            if (_fearLevel >= 100.0f)
                _shatHimself = true;
			//game over
        }
    }
    public bool shatHimself { get { return _shatHimself; } }

	void Start () {
        _fearLevel = 0.0f;
        _shatHimself = false;
	}
	
	void Update () {

        if (archenemy == null)
            return;

        Vector3 vecDist = archenemy.position - this.transform.position;
        float distance = vecDist.magnitude;
        if (distance<=50)
            fearLevel = (100-100*distance/25)/2 ;
        //Debug.Log(_fearLevel);

        // Recover from fear
        if (!shatHimself)
        {
            if (fearLevel > 0.0f)
                fearLevel -= _relaxSpeed * Time.deltaTime;
            else if (fearLevel < 0.0f)
                fearLevel = 0.0f;
        }


//         if (shatHimself && fearLevel <= maxFear && GameMaster.instance.paused==false)
// 			fearLevel = fearLevel + fearSpeed;
// 		else if (fearLevel >= maxFear) {
// 			UIManager.instance.gameOver.SetActive (true);
// 		}
// 		else if (!shatHimself && fearLevel >= 0.0f && GameMaster.instance.paused==false) 
// 			fearLevel -= relaxSpeed * Time.deltaTime;
		//UIManager.instance.alpha = fearLevel * 2.55f / 100.0f;
	}

// 	void OnTriggerEnter(Collider collision){
// 		GameObject collisionObject = collision.gameObject;
// 
// 		if (collisionObject.CompareTag ("Enemy"))
// 			shatHimself = true;
// 	}
// 
// 	void OnTriggerExit(Collider collision){
// 		GameObject collisionObject = collision.gameObject;
// 		if (collisionObject.CompareTag ("Enemy"))
// 			shatHimself = false;
// 	}

}
