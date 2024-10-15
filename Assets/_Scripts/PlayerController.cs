using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Main Player Values")]
    [SerializeField] float moveSpeed;

    [Header("Attack Values")]
    [SerializeField] int projectileCount;
    [SerializeField] float cooldown;
    [SerializeField] float projectileSpeed;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletPoint;

    [SerializeField] private bool isShooting = false;

    PlayerInputAsset inputActions;

    Rigidbody2D rb;

    Coroutine fullAutoCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        inputActions = new PlayerInputAsset();

        inputActions.Player.Enable();
        inputActions.Player.Move.performed += Movement;
        inputActions.Player.Move.canceled += StopMovement;
        inputActions.Player.Fire.performed += DoShoot;
        inputActions.Player.Fire.canceled += StopShoot;

        rb = GetComponent<Rigidbody2D>();
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Movement(InputAction.CallbackContext context)
    {
        Vector2 moveVector = context.ReadValue<Vector2>();
        moveVector.y = 0;
        Debug.Log(moveVector);

        rb.velocity = moveVector * moveSpeed;
    }
    private void StopMovement(InputAction.CallbackContext context)
    {
        rb.velocity = Vector2.zero;
    }

    private void DoShoot(InputAction.CallbackContext context)
    {
        fullAutoCoroutine = StartCoroutine(FullAuto());
    }

    private void StopShoot(InputAction.CallbackContext context)
    {
        StopCoroutine(fullAutoCoroutine);
    }

    private IEnumerator FullAuto()
    {
        while (true)
        {
            GameObject projectile = Instantiate(bullet, bulletPoint.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = Vector2.up * projectileSpeed;
            Destroy(projectile, 5f);

            yield return new WaitForSeconds(cooldown);
        }
    }
}  
