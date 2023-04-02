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
    [SerializeField] float timeToMelt = 10f;
    [SerializeField] GameObject father;
    BoxCollider2D myBoxCollider2D;
    Animator myAnimator;
    [SerializeField] SoundManager soundManager;
    bool isGrowing;

    void Awake()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        myBoxCollider2D = GetComponent<BoxCollider2D>();
        myAnimator = GetComponent<Animator>();
    }
    void Start()
    {
        isGrowing = false;
    }

    void Update()
    {
        Walk();
        if (IsMovingHorizontal())
        {
            if (IsFeetTouching("Ground"))
            {
                soundManager.PlayWalkClip();
            }
            FlipSprite();
        }
        else if (IsFeetTouching("Ground") && !myAnimator.GetBool("isJumping"))
        {
            soundManager.StopAudio();
        }
    }

    public void OnMoveFather(InputValue value)
    {
        moveInputValue = value.Get<Vector2>();
    }

    public void OnJumpFather(InputValue value)
    {
        if (value.isPressed && IsFeetTouching("Ground"))
        {
            myRigidBody2D.velocity += new Vector2(0f, jumpSpeed);
            myAnimator.SetBool("isJumping", true);
            soundManager.PlayJumpClip();
            Invoke("ResetIsJumping", 0.3f);
        }
    }

    void ResetIsJumping()
    {
        myAnimator.SetBool("isJumping", false);
    }

    void Walk()
    {
        Vector2 playerVelocity = new Vector2(moveInputValue.x * playerMoveSpeed, myRigidBody2D.velocity.y);
        myRigidBody2D.velocity = playerVelocity;

        myAnimator.SetBool("isWalking", IsMovingHorizontal());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SnowPiece Item")
        {
            soundManager.PlaySnowPieceClip();
            Destroy(other.gameObject, 0f);
            isGrowing = true;
        }
    }

    public bool GetIsGrowing()
    {
        return isGrowing;
    }

    public void ResetIsGrowing()
    {
        isGrowing = false;
    }

    void FlipSprite()
    {
        myRigidBody2D.transform.localScale = new Vector3(Mathf.Sign(myRigidBody2D.velocity.x), 1f, 0f);
    }

    bool IsMovingHorizontal()
    {
        return Mathf.Abs(myRigidBody2D.velocity.x) > Mathf.Epsilon;
    }

    bool IsFeetTouching(params string[] layers)
    {
        return myBoxCollider2D.IsTouchingLayers(LayerMask.GetMask(layers));
    }

    public void _SetActive(bool value, Transform transform)
    {
        moveInputValue = Vector2.zero;
        gameObject.transform.position = transform.position;
        gameObject.transform.localScale = transform.localScale;
        gameObject.SetActive(value);
    }

    public float GetTimeToMelt()
    {
        return timeToMelt;
    }

    public void PlayShrinkClipOnSM()
    {
        soundManager.PlayShrinkClip();
    }

    public void PlayGrowClipOnSM()
    {
        soundManager.PlayGrowClip();
    }
}

