using UnityEngine;
using System.Collections;

public class EnemyFearZone : MonoBehaviour
{

    public float fearConquerRate { get; set; }

    private Transform _transform;
    private bool _playerNearby = false;
    private PlayerStats _playerStats;
    private Transform _player;
    private bool _isScary;
    private float _fearZoneRadius;
    private EnemyBehaviour _behaviour;
    private float _conqueredPercentage;
	private float damageToCourage;

    void Start () {
        _isScary = true;
        _transform = transform;
        _fearZoneRadius = _transform.localScale.x * 0.5f;
        _behaviour = _transform.parent.GetComponent<EnemyBehaviour>();
		if (!_behaviour)
			Debug.Log ("piwi");
        _conqueredPercentage = 0.0f;
	}
	
	void Update () {
	    if (_playerNearby && _isScary)
        {
            _conqueredPercentage += fearConquerRate * Time.deltaTime;



            /*renderer.material.color = new Color(renderer.material.color.r,
                renderer.material.color.g,
                renderer.material.color.b,
                1.0f - _conqueredPercentage * 0.01f);*/
            if (_conqueredPercentage >= 100.0f)
            {
                _isScary = false;
                _behaviour.OnFearConquered();
            }

            Scare();
        }
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") == false)
            return;

		//collider.gameObject.GetComponent<PlayerController> ().loseLife (damageToCourage * Time.deltaTime);

        _playerStats = collider.GetComponent<PlayerStats>();
        _player = collider.transform;
        _playerNearby = true;
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") == false)
            return;

        _playerNearby = false;
    }

    void Scare()
    {
        float distanceFactor = (_fearZoneRadius - (_transform.position - _player.position).magnitude) / _fearZoneRadius;
        _playerStats.fearLevel = _playerStats.fearLevel + (_behaviour.GetFearFactor() * distanceFactor * Time.deltaTime);
    }

}
