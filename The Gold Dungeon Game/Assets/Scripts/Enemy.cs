using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFacingRight())
        {
            myRigidBody.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            myRigidBody.velocity = new Vector2(-moveSpeed, 0f);
        }

    }
    bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), 1f);

    }
    //private void FlipSprite()
    //{
    //    if (myUpperBody.IsTouchingLayers(LayerMask.GetMask("Ground")))
    //    {
    //        print(count);
    //        if (count % 2 == 0)
    //        {
    //            sign = -sign;
    //        }
    //        bool enemyHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
    //        if (enemyHasHorizontalSpeed)
    //        {
    //            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
    //        }
    //        count += 1;
    //    }
    //    //for horizontal

    //}

}
