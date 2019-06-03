using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
	public Transform Player;
	public NavMeshAgent Agent;
 

    // Start is called before the first frame update
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
       
    }

    // Update is called once per frame
    void Update()
    {
         Agent.SetDestination(Player.transform.position);
         Debug.Log(ScoreText.score);
         
    }
     void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            ScoreText.score++;

            if(ScoreText.score >= 3)
            {
            SceneManager.LoadScene(2); 
            ScoreText.score = 0;
            }
        } 
    }
}
