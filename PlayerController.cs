using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	Rigidbody rb;
    public Text hpText;
    int hp;
    public GameObject bullet;
    GameObject bulletClone;
    Rigidbody rbClone;
    

    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody>();
         hp = 100;
    }

    // Update is called once per frame
    void Update()
    {
        float moveVertical = Input.GetAxis("Vertical");
    	float moveHorizontal = Input.GetAxis("Horizontal");
        transform.Rotate(0, moveHorizontal * 3f, 0);
    	rb.AddForce(transform.forward * moveVertical * 50f);
    	rb.AddForce(transform.right * moveHorizontal * 50f);

          if(Input.GetKeyDown("space"))
        {
            bulletClone = Instantiate(bullet, new Vector3(transform.position.x,transform.position.y,transform.position.z), Quaternion.identity);
            rbClone = bulletClone.GetComponent<Rigidbody>();
            rbClone.AddForce(transform.forward*100f);
        }
    }
     void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            hp = hp - 6;
            Debug.Log(hp);
            hpText.text = "HP: " + hp;

            if(hp <= 0)
            {
                SceneManager.LoadScene(0);
                hp = 100;
            }
        } 
    }
}
