using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    public Transform GameOverCanvas;
    public Vector3 v1;

    // Use this for initialization
    void Start () {
		
	}


    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Monster")
        {
            GameOverCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;
            
        }
    }

    

    // Update is called once per frame
    void Update () {
        
    }
}
