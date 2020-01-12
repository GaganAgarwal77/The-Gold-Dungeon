using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    CapsuleCollider2D myBody;
    BoxCollider2D myFeet;
    float gravityScaleAtStart;
    bool isAlive = true;

    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(0f, 100f);
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBody = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigidBody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return; }
        
            Run();
            Jump();
            FlipSprite();
            Climb();
            StartCoroutine(Die());
            var currentSceneIndex = SceneManager.GetActiveScene().name;
            if (currentSceneIndex == "Final")
            {
            FindObjectOfType<GameSession>().Endgame();
        }

    }
    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");// value is between -1 to +1
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", playerHasHorizontalSpeed);

    }

    private void Jump()
    {
        if (CrossPlatformInputManager.GetButtonDown("Jump") && myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {

            Vector2 jumpVelocity = new Vector2(0, jumpSpeed);
            myRigidBody.velocity += jumpVelocity;


        }
    }

    private void Climb()
    {
        if (myFeet.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            float controlThrow = CrossPlatformInputManager.GetAxis("Vertical");

            Vector2 climbVelocity = new Vector2(myRigidBody.velocity.x, controlThrow * climbSpeed);
            myRigidBody.velocity = climbVelocity;
            myRigidBody.gravityScale = 0f;

            bool playerHasVerticalSpeed = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;
            myAnimator.SetBool("Climbing", playerHasVerticalSpeed);
        }
        else
        {
            myAnimator.SetBool("Climbing", false);
            myRigidBody.gravityScale = gravityScaleAtStart;
        }

    }






    private void FlipSprite()
    {
        //for horizontal
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)   
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }

        ////for vertical
        //bool playerHasVerticalSpeed = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;
        //if (playerHasVerticalSpeed)
        //{
        //    transform.localScale = new Vector2(1f, Mathf.Sign(myRigidBody.velocity.y));
        //}
    }

    IEnumerator Die()
    {
        if (myBody.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            isAlive = false;
            myAnimator.SetTrigger("Dying");
            GetComponent<Rigidbody2D>().velocity = deathKick;
            yield return new WaitForSecondsRealtime(1f);
            FindObjectOfType<GameSession>().PlayerDeath();
            //yield return new WaitForSecondsRealtime(2f);
            //SceneManager.LoadScene(5);
        }


    }

}
