using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    protected int hitpoints;
    protected GameObject powerUpDrop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void TakeDamage(int damage)
    {
        hitpoints -= damage;

        if(hitpoints >= 0)
        {
            OnDeath();
        }
    }

    protected virtual void OnDeath()
    {

    }
}
