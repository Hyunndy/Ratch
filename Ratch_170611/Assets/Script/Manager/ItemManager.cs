using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

 //-----------------------------------------------------------
 // 스크립트명 : ItemManager 
 // 기능 : 아이템, 열쇠 습득 여부나 획득갯수를 관리.
 // 작성자 : 유현지
 //-----------------------------------------------------------

 
  //----------------------------------------------------------
  // 변수들
  //----------------------------------------------------------
    public int Get_KeyNo; //  열쇠 얻은 갯수

    public int Get_ItemNo; //  아이템 얻은 갯수

    public bool[] Get_Key = new bool[4]; 
    // 열쇠 습득 여부 ( 총 스테이지에서 제일 많은 열쇠가 3개일거같아서 임의로 3으로 지정 유니티 안에서 변경 가능)
    // 문1에 맞는 열쇠가 열쇠1이라서 습득 여부 필요

    public bool[] Get_Item = new bool[3]; // 아이템 습득 여부 

    //  public bool Get_Key1; // 열쇠1 습득 여부
    // public bool Get_Item1; // 아이템1 습득 여부
    //
    // public bool Get_Item2; // 아이템2 습득 여부
    //
    // public bool Get_Item3; // 아이템3 습득 여부

    // public bool Get_Key2; // 열쇠2 습득 여부
    // public bool Get_Key3; // 열쇠3 습득 여부


    //----------------------------------------------------------
    // 함수들
    //----------------------------------------------------------

    void Start()
    {

        Get_KeyNo = 0;
        Get_ItemNo = 0;

        for(int i=0; i<4; i++)
        {
            Get_Key[i] = false;

        }

        for (int i = 0; i < 3; i++)
        {
     
            Get_Item[i] = false;
        }

    }

   
}
