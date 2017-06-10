using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class monster : MonoBehaviour {

    public GameObject Player;
    public Transform Eyes;

    private NavMeshAgent Nav;
    private Animator Anim;
    private string State = "idle";
    private bool Alive = true;
    private float Wait = 0f;
    private bool HighAlert = false;
    private float Alertness = 20f;


	// Use this for initialization
	void Start () {
        Nav = GetComponent<NavMeshAgent>();
        Anim = GetComponent<Animator>();
        

        //몬스터의 초기 애니메이션 속도와 이동속도
        Nav.speed = 1.2f;
        Anim.speed = 1.2f;
	}

    //플레이어를 볼수 있는지 확인
    public void CheckSight()
    {
        if(Alive)
        {
            RaycastHit RayHit;
            if(Physics.Linecast(Eyes.position, Player.transform.position, out RayHit))
            {
                print("hit " + RayHit.collider.gameObject.name);
                //그게 플레이어 일때
                if (RayHit.collider.gameObject.name == "Player")
                {
                    
                    if (State != "kill")
                    {
                        State = "chase";
                        Nav.speed = 1.5f;
                        Anim.speed = 1.5f;
                    }
                }
            }
        }
    }

	// Update is called once per frame
	void Update () {
        

        Debug.DrawLine(Eyes.position, Player.transform.position, Color.green);
        if (Alive)
        {
            Anim.SetFloat("velocity", Nav.velocity.magnitude);
            if(State == "idle")
            {
                //랜덤 위치로 이동
                Vector3 randomPos = Random.insideUnitSphere * Alertness;
                NavMeshHit navHit;
                NavMesh.SamplePosition(transform.position + randomPos, out navHit, 20f, NavMesh.AllAreas);

                //플레이어 주변 위치로 이동
                if(HighAlert)
                {
                    NavMesh.SamplePosition(Player.transform.position + randomPos, out navHit, 20f, NavMesh.AllAreas);
                    //each time, lose awareness of player general position
                    Alertness += 10f;
                    
                    if (Alertness > 20f)
                    {
                        HighAlert = false;
                        Nav.speed = 1.2f;
                        Anim.speed = 1.2f;
                    }
                }

                Nav.SetDestination(navHit.position);
                State = "walk";
            }
            //walk
            if(State == "walk")
            {
                CheckSight();
                if (Nav.remainingDistance <= Nav.stoppingDistance && !Nav.pathPending)
                {
                    State = "search";
                    Wait = 1.5f;
                }
            }
            //search
            if(State == "search")
            {
                if(Wait > 0f)
                {
                    CheckSight();
                    Wait -= Time.deltaTime;
                    transform.Rotate(0f, 120f * Time.deltaTime, 0f);
                }
                else
                {
                    State = "idle";
                }
            }
            //chase
            if(State == "chase")
            {
                Nav.destination = Player.transform.position;
                //lose sight of player
                float distance = Vector3.Distance(transform.position, Player.transform.position);
                if(distance > 3f)
                {
                    State = "hunt";
                }
            }
            
            //hunt
            if(State == "hunt")
            {
              CheckSight();

                if (Nav.remainingDistance <= Nav.stoppingDistance && !Nav.pathPending)
                {
                    State = "search";
                    Wait = 5f;
                    HighAlert = true;
                    Alertness = 5f;
                    CheckSight();
                }
            }
            //Nav.SetDestination(Player.transform.position);
        }
	}

    

    
}
