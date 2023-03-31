using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DefaultSnowman : MonoBehaviour
{
    Vector2 moveInputValue;
    Rigidbody2D myRigidBody2D;
    [SerializeField] float playerMoveSpeed = 3f;
    [SerializeField] float jumpSpeed = 5f;
    BoxCollider2D myBoxCollider2D;

    void Awake()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        myBoxCollider2D = GetComponent<BoxCollider2D>();
    }
    void Start()
    {

    }

    void Update()
    {
        Walk();
        if (IsMovingHorizontal())
        {
            FlipSprite();
        }
    }

    void OnMove(InputValue value)
    {
        moveInputValue = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed && myBoxCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            myRigidBody2D.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void Walk()
    {
        Vector2 playerVelocity = new Vector2(moveInputValue.x * playerMoveSpeed, myRigidBody2D.velocity.y);
        myRigidBody2D.velocity = playerVelocity;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SnowPiece Item")
        {
            Destroy(other.gameObject, 0f);
            Debug.Log("Crescer");
        }
    }

    void FlipSprite()
    {
        myRigidBody2D.transform.localScale = new Vector3(Mathf.Sign(myRigidBody2D.velocity.x), 1f, 0f);
    }

    bool IsMovingHorizontal()
    {
        return Mathf.Abs(myRigidBody2D.velocity.x) > Mathf.Epsilon;
    }

}

