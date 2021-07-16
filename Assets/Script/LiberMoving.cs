using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class LiberMoving : MonoBehaviour
{
    public float moveSpeed;
    public float nomalSpeed, runSpeed;

    private Animator anim;  // 애니메이터 불러오는 변수

    bool playerMoving;  // 움직이는지 여부
    Vector2 lastMove;  // 마지막 움직임 방향 확인

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMoving = false;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 4;
        }
        else
        {
            moveSpeed = 2;
        }

        //if (Input.GetKey(KeyCode.LeftShift))
            //moveSpeed = runSpeed;
        //else
            //moveSpeed = normalSpeed;

        if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }
        if (Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Vertical") < 0)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
}
