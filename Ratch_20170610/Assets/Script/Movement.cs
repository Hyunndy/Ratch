using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]



public class Movement : MonoBehaviour {


    //----------------------------------------------------------
    // 아이템 매니저 생성
    //----------------------------------------------------------
    public ItemManager IM;
    public UIImage UI0, UI1, UI2, UI3, UI4;

    public Transform gameover;
    public Transform gameclear;

    public Animator anim;
    public Rigidbody Rig;
    public Collider P_Col;

    private AudioSource Music;

    Vector3 movement;
    Vector3 Rotation;

    float distToGround;

    float h = 0;
    float v = 0;
    public float speed = 10f;
    public float rotateSpeed = 10f;
    public float jumpPower = 5f;
    bool isJumping;
    bool grounded = false; // 땅에서만 점프할 수 있게

    
	// Use this for initialization

  	void Awake () {
       
        anim = GetComponent<Animator>();
        Rig = GetComponent<Rigidbody>();
        P_Col = GetComponent<Collider>();
        distToGround = P_Col.bounds.extents.y;
        Music = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

    //적 발견시 추적
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "eyes")
        {
            other.transform.parent.GetComponent<monster>().CheckSight();
        }
        if(other.gameObject.tag == "Monster")
        {
            Time.timeScale = 0;
            gameover.gameObject.SetActive(true);
            Music.volume = 0;
            SoundManager.instance.PlayGameOverSound();
        }
        if (other.gameObject.tag == "Fall")
        {
            Time.timeScale = 0;
            gameover.gameObject.SetActive(true);
            Music.volume = 0;
            SoundManager.instance.PlayGameOverSound();
        }

    }

    void Move(float h, float v)
    {
        float a = 0;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            a++;
            if (Input.GetKeyUp(KeyCode.UpArrow))
                a = 0;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            a++;
            if (Input.GetKeyUp(KeyCode.DownArrow))
                a = 0;
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            a++;
            if (Input.GetKeyUp(KeyCode.LeftArrow))
                a = 0;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            a++;
            if (Input.GetKeyUp(KeyCode.RightArrow))
                a = 0;
        }


        anim.SetFloat("Forward", a);
        //anim.SetFloat("Back", Input.GetAxisRaw("Vertical"));
        //anim.SetFloat("Forward", Input.GetAxisRaw("Horizontal"));
        movement.Set(h, 0, v);    
            

        movement = movement.normalized * speed * Time.deltaTime;

        Rig.MovePosition(transform.position + movement);
        
    }	


    void Turn()
    {
        if (h == 0 && v == 0)
            return;

        Quaternion newRotation = Quaternion.LookRotation(movement);

        Rig.rotation = Quaternion.Slerp(Rig.rotation, newRotation, rotateSpeed * Time.deltaTime);
    }
    // Update is called once per frame


    void Jump()
    {


        if (!isJumping)
            return;

        isJumping = false;
        
        Rig.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);




    }

 bool checkground()

 {
     RaycastHit hit;


     if(Physics.Raycast(transform.position, -Vector3.up, distToGround+0.1f))
     {
      
             //grounded = true;
             return true;
     }

        //grounded = false;
        return false;
     }


    private void OnCollisionEnter(Collision collision)
    {

        //----------------------------------------------------------
        // 기능: 적과의 충돌 부분 
        //----------------------------------------------------------

        if (collision.gameObject.name == "Enemy")
        {
            Rig.transform.position = new Vector3(-1.5f, 0.025f, -5.5f);  
        }





        //----------------------------------------------------------
        // 기능: 오브젝트들(열쇠, 아이템, 문)과 캐릭터 충돌시에 이벤트를 처리
        //----------------------------------------------------------




        string ObjectCollision = collision.transform.tag; // 캐릭터와 충돌한 오브젝트의 tag를 저장하는 string변수

        switch (ObjectCollision)
        {

            //--------------------------------------------------------------------------------------------
            // 캐릭터 - 아이템&열쇠 충돌부분
            //--------------------------------------------------------------------------------------------
            case "Key0":  // 열쇠0과 충돌 시,

                SoundManager.instance.PlayKeySound();
                collision.gameObject.SetActive(false); // 열쇠0과 충돌 후 열쇠0 사라지게함.
                IM.Get_KeyNo++; // 열쇠0을 얻었으니 열쇠얻은 수 +1
                Debug.Log("Key0 습득!");
                IM.Get_Key[0] = true; // 열쇠0의 습득여부를 True로 바꿔줌.
                UI1.ItemUI0_Change();
                break;

            case "Key1":

                SoundManager.instance.PlayKeySound();
                collision.gameObject.SetActive(false);
                IM.Get_KeyNo++;
                Debug.Log("Key1 습득!");
                IM.Get_Key[1] = true;
                UI2.ItemUI0_Change();


                break;

            case "Key2":

                SoundManager.instance.PlayKeySound();
                collision.gameObject.SetActive(false);
                IM.Get_KeyNo++;
                Debug.Log("Key2 습득!");
                IM.Get_Key[2] = true;
                UI3.ItemUI0_Change();
                break;

            case "Key3":

                SoundManager.instance.PlayKeySound();
                collision.gameObject.SetActive(false);
                IM.Get_KeyNo++;
                IM.Get_Key[3] = true;
                UI4.ItemUI0_Change();

                break;


            case "Item0":

                SoundManager.instance.PlayItemSound();
                collision.gameObject.SetActive(false);
                IM.Get_ItemNo++;
                Debug.Log("Item0 습득!");
                IM.Get_Item[0] = true;
                UI0.ItemUI0_Change();
                break;

            case "Item1":

                SoundManager.instance.PlayItemSound();
                collision.gameObject.SetActive(false);
                IM.Get_ItemNo++;
                Debug.Log("Item1 습득!");
                IM.Get_Item[1] = true;
                UI0.ItemUI1_Change();

                break;

            case "Item2":

                SoundManager.instance.PlayItemSound();
                collision.gameObject.SetActive(false);
                IM.Get_ItemNo++;
                Debug.Log("Item2 습득!");
                IM.Get_Item[2] = true;
                UI0.ItemUI2_Change();

                break;


            //--------------------------------------------------------------------------------------------
            // 캐릭터-문 충돌부분
            //--------------------------------------------------------------------------------------------

            case "Door0": // 문0과 충돌 시,


                if (IM.Get_Key[0] == true) // Key0의 습득여부가 True라면
                {
                    Debug.Log("Key0을 습득했기 때문에 문이 열린다.");

                    collision.gameObject.GetComponentInChildren<Animator>().SetBool("Open", true);
                    SoundManager.instance.PlayDoorSound();
                    StartCoroutine(WaitAlittle(collision));

                    //collision.gameObject.SetActive(false); // 문0을 사라지게함.
                }

                else //Key0을 습득하지 않았다면
                    Debug.Log("Key0을 모아오세요");

                break;


            case "Door1": // 문1과 충돌 시,


                if (IM.Get_Key[1] == true)
                {
                    Debug.Log("Key1을 습득했기 때문에 문이 열린다.");

                    collision.gameObject.GetComponentInChildren<Animator>().SetBool("Open", true);
                    SoundManager.instance.PlayDoorSound();
                    StartCoroutine(WaitAlittle(collision));
                    //collision.gameObject.SetActive(false);

                }

                else //Key1을 습득하지 않았다면
                    Debug.Log("Key1을 모아오세요");

                break;


            case "Door2": // 문2와 충돌 시,


                if (IM.Get_Key[2] == true)
                {
                    Debug.Log("Key2를 습득했기 때문에 문이 열린다.");
                    collision.gameObject.GetComponentInChildren<Animator>().SetBool("Open", true);
                    SoundManager.instance.PlayDoorSound();
                    StartCoroutine(WaitAlittle(collision));
                    //collision.gameObject.SetActive(false);

                }

                else //Key2을 습득하지 않았다면
                    Debug.Log("Key2를 모아오세요");

                break;

            case "Door3": // 문2와 충돌 시,


                if (IM.Get_Key[3] == true)
                {
                    Debug.Log("Key3를 습득했기 때문에 문이 열린다.");
                    collision.gameObject.GetComponentInChildren<Animator>().SetBool("Open", true);
                    SoundManager.instance.PlayDoorSound();
                    StartCoroutine(WaitAlittle(collision));
                    //collision.gameObject.SetActive(false);

                }

                else //Key2을 습득하지 않았다면
                    Debug.Log("Key3를 모아오세요");

                break;

            case "Door4": // 문2와 충돌 시,


                if (IM.Get_Key[3] == true)
                {
                    Debug.Log("Key3를 습득했기 때문에 문이 열린다.");
                    collision.gameObject.GetComponentInChildren<Animator>().SetBool("Open", true);
                    SoundManager.instance.PlayDoorSound();
                    StartCoroutine(WaitSideDoor(collision));
                    //collision.gameObject.SetActive(false);

                }

                else //Key2을 습득하지 않았다면
                    Debug.Log("Key3를 모아오세요");

                break;


            //--------------------------------------------------------------------------------------------
            // 다음스테이지로 가는 문과의 충돌부분
            //--------------------------------------------------------------------------------------------

            case "Finish_Door":
                if (IM.Get_KeyNo == 4 && IM.Get_ItemNo == 3) // 얻은 열쇠의 수와 아이템 수가 조건을 충족한다면,
                {
                    Debug.Log("열쇠와 아이템 모두 얻음");
                    collision.gameObject.GetComponentInChildren<Animator>().SetBool("Open", true);
                    SoundManager.instance.PlayDoorSound();
                    StartCoroutine(WaitFinishDoor(collision));
                    //collision.gameObject.SetActive(false);
                }
                else
                    Debug.Log("열쇠와 아이템 모두 못 얻음");
                break;

            case "Reach":
                //SceneManager.LoadScene("Title"); // 다음 씬으로 넘어갑니다.
                Time.timeScale = 0;
                gameclear.gameObject.SetActive(true);
                SoundManager.instance.PlayGameClearSound();
                Music.volume = 0;
                break;
        }


    }

    IEnumerator WaitAlittle(Collision collision)
    {
        if (IM.Get_Key[0] == true)
        {
            yield return new WaitForSeconds(1f);
            collision.gameObject.GetComponent<MeshCollider>().isTrigger = true;
            yield return new WaitForSeconds(1f);
            collision.gameObject.SetActive(false);
        }

        if (IM.Get_Key[1] == true)
        {
            yield return new WaitForSeconds(1f);
            collision.gameObject.GetComponent<MeshCollider>().isTrigger = true;
            yield return new WaitForSeconds(1f);
            collision.gameObject.SetActive(false);
        }

        if (IM.Get_Key[2] == true)
        {
            yield return new WaitForSeconds(1f);
            collision.gameObject.GetComponent<MeshCollider>().isTrigger = true;
            yield return new WaitForSeconds(1f);
            collision.gameObject.SetActive(false);
        }

        if (IM.Get_Key[3] == true)
        {
            yield return new WaitForSeconds(1f);
            collision.gameObject.GetComponent<MeshCollider>().isTrigger = true;
            yield return new WaitForSeconds(1f);
            collision.gameObject.SetActive(false);
        }

    }

    IEnumerator WaitFinishDoor(Collision collision)
    {
        if (IM.Get_KeyNo == 4 && IM.Get_ItemNo == 3)
        {
            yield return new WaitForSeconds(1f);
            collision.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            yield return new WaitForSeconds(1f);
            collision.gameObject.SetActive(false);
        }
    }

    IEnumerator WaitSideDoor(Collision collision)
    {
        if (IM.Get_Key[3] == true)
        {
            collision.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            yield return new WaitForSeconds(1f);
            collision.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

      // checkground();

        if (Input.GetButtonDown("Jump") && checkground())
        {
            isJumping = true;
            anim.SetTrigger("Jump");
        }
        
    }


    
    void FixedUpdate() // 물리를 사용하기 때문에 FixedUpdate에서 처리
    {

        Turn();
        Move(h,v);
        Jump();
	}



}
