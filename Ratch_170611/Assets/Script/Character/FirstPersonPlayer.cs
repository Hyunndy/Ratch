using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonPlayer : MonoBehaviour
{
    public float speed = 10f;

    Rigidbody rigidbody;
    Vector3 movement;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public bool Alive = true;
   


//---------------------------------------------------------------
// Player의 스크립트로 이동!
//---------------------------------------------------------------
 
    void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.name == "eyes")
        {
            Other.transform.parent.GetComponent<monster>().CheckSight();
        }
    }

    //이동 로직에 리지드바디를 쓰기 때문에 FixedUpdate을 사용
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Run(h, v);
    }

    void Run(float h, float v)
    {
        movement.Set(h, 0, v);
        movement = movement.normalized * speed * Time.deltaTime;

        rigidbody.MovePosition(transform.position + movement);
    }
   
}
