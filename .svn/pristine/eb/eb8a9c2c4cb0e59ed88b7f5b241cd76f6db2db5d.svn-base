using UnityEngine;
using System.Collections;

public abstract class EnemyBehaviour : MonoBehaviour {

    [SerializeField]
    protected float _initialFearRate = 50.0f;
    [SerializeField]
    private float _fearConquerRate = 10.0f;

    public abstract float GetFearFactor();
    public abstract void OnFearConquered();
    public abstract void ReceiveLightDamage(float damageValue);

    protected void Init()
    {
        GetComponentInChildren<EnemyFearZone>().fearConquerRate = _fearConquerRate;
    }

}
