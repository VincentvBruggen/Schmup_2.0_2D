using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour, IDamageable
{
    protected int hitpoints;
    protected GameObject powerUpDrop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame|
    void Update()
    {
        
    }
    public void TakeDamage(int amount)
    {
        hitpoints -= amount;

        if(hitpoints >= 0)
        {
            OnDeath();
        }
    }

    protected virtual void OnDeath()
    {
        Destroy(gameObject);
    }
}
