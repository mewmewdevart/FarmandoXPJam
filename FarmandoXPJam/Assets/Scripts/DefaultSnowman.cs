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
<<<<<<< HEAD
    [SerializeField] float timeToMelt = 10f;
    [SerializeField] GameObject father;
    BoxCollider2D myBoxCollider2D;
    Animator myAnimator;
    [SerializeField] SoundManager soundManager;
    bool isGrowing;
=======
    BoxCollider2D myBoxCollider2D;
>>>>>>> ff4d3c0 (.)

    void Awake()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        myBoxCollider2D = GetComponent<BoxCollider2D>();
<<<<<<< HEAD
        myAnimator = GetComponent<Animator>();
    }
    void Start()
    {
        isGrowing = false;
=======
    }
    void Start()
    {

>>>>>>> ff4d3c0 (.)
    }

    void Update()
    {
        Walk();
        if (IsMovingHorizontal())
        {
<<<<<<< HEAD
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
=======
            FlipSprite();
        }
    }

    void OnMove(InputValue value)
>>>>>>> ff4d3c0 (.)
    {
        moveInputValue = value.Get<Vector2>();
    }

<<<<<<< HEAD
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

=======
    void OnJump(InputValue value)
    {
        if (value.isPressed && myBoxCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            myRigidBody2D.velocity += new Vector2(0f, jumpSpeed);
        }
    }

>>>>>>> ff4d3c0 (.)
    void Walk()
    {
        Vector2 playerVelocity = new Vector2(moveInputValue.x * playerMoveSpeed, myRigidBody2D.velocity.y);
        myRigidBody2D.velocity = playerVelocity;
<<<<<<< HEAD

        myAnimator.SetBool("isWalking", IsMovingHorizontal());
=======
>>>>>>> ff4d3c0 (.)
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SnowPiece Item")
        {
<<<<<<< HEAD
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

=======
            Destroy(other.gameObject, 0f);
            Debug.Log("Crescer");
        }
    }

>>>>>>> ff4d3c0 (.)
    void FlipSprite()
    {
        myRigidBody2D.transform.localScale = new Vector3(Mathf.Sign(myRigidBody2D.velocity.x), 1f, 0f);
    }

    bool IsMovingHorizontal()
    {
        return Mathf.Abs(myRigidBody2D.velocity.x) > Mathf.Epsilon;
    }

<<<<<<< HEAD
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
=======
>>>>>>> ff4d3c0 (.)
}

