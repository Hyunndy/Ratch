using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//-----------------------------------------------------------
// 스크립트명 : DoorManager 
// 기능 : 특정 발판을 밟았을 때 문에 발생하는 이벤트(사라진다거나 열린다거나)를 관리함. 
// 작성자 : 유현지
//-----------------------------------------------------------

public class DoorManager : MonoBehaviour
{

    //-----------------------------------------------------------
    // 변수들
    //-----------------------------------------------------------

    public ItemManager IM; // 아이템매니저 불러옴
    public int DoorNo; // 문의 번호


    //-----------------------------------------------------------
    // 함수들
    //-----------------------------------------------------------


    //----------------------------------------------------------
    // 함수명 : InitDoor_No()
    // 기능 : 각각 문 오브젝트들에 번호를 부여한다.
    //      : 밑에있는 Unactive_Door() 함수에서 switch문으로 이벤트를 관리하기 위해
    //----------------------------------------------------------
    public void Init_DoorNo()
    {
        string Door = gameObject.tag; // 문 오브젝트의 tag를 string변수 Door에 저장한다.

        switch (Door)
        {
            case "Door0": // tag 이름이 Door0이라면
                DoorNo = 0; // Door_No를 0으로 설정한다.
                break;

            case "Door1":
                DoorNo = 1;
                break;

            case "Door2":
                DoorNo = 2;
                break;


        }
    }

    //----------------------------------------------------------
    // 함수명 : Door_event()
    // 기능 : InitDoor_No() 함수로 문 오브젝트에 부여된 번호로 switch문을 통해 문에 발생하는 이벤트를 관리한다. 
    //        (캐릭터가 발판을 밟는다던가 하는 이벤트)
    //        (열쇠를 가지고 문에 충돌했을 때 문이 사라지는 이벤트는 이 함수가 아님)
    //----------------------------------------------------------

    public void Door_event()
    {
        switch (DoorNo)
        {
            case 0: // 문번호가 0일 때

                if (IM.Get_Key[0] == true) // Itemmanager에서 선언된 Get_Key[0]==true이면, 즉 캐릭터가 tag가 Key0인 오브젝트와 충돌해서 열쇠를 먹었다면,
                {                          // SimpleCharacterControl에서 캐릭터가 key0 오브젝트와 충돌하면 Get_Key[0]을 true로 바꿔주는 처리를 해주었다.
                                           // Debug.Log("충돌");

                    //gameObject.SetActive(false);  //문을 사라지게 한다.
                }

                break;

            case 1:

                if (IM.Get_Key[1] == true)
                {
                    //Debug.Log("충돌2");
                    //gameObject.SetActive(false);
                }
                break;
        }


    }

    // Use this for initialization
    void Start()
    {
        DoorNo = 0;
        Init_DoorNo();
    }

    // Update is called once per frame
    void Update()
    {

        //Door_event();
    }
}
