using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerMovement : MonoBehaviour
{
    #region Fields
    [SerializeField] PLayerStats player;
    Rigidbody2D body;
    Animator animator;
    float horizontal;
    float vertical;
    Vector2 movementDirection;
    #endregion
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player.position = body.position;
    }

    // Update is called once per frame
    void Update()
    {
        MovmentInput();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void MovmentInput()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        movementDirection = new Vector2(horizontal, vertical).normalized;
        animator.SetFloat("Horizontal", movementDirection.x);
        animator.SetFloat("Speed", movementDirection.sqrMagnitude);
    }
    private void Move()
    {
        body.velocity = movementDirection * player.speed * Time.fixedDeltaTime;
        player.position = body.position;
    }
}
