using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CharachterController1 : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D myRigidbody;
    public float jumpSpeed;
    

    private Animator myAnim;
    // Start is called before the first frame update

    public Vector3 respawnPosition;
    public GameObject KillPlane;

    public HealthManager thehealthManager;

   

   

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        respawnPosition = transform.position;

        thehealthManager = FindObjectOfType<HealthManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f);
        }
        

        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
        }
        else
        {
            myRigidbody.velocity = new Vector3(0f, myRigidbody.velocity.y, 0f);
        }
        if (Input.GetButtonDown("Jump") && Mathf.Approximately(myRigidbody.velocity.y, 0f))
        {
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);
            myAnim.SetBool("Grounded", true);
        }
        if(myAnim.GetBool("Grounded") && Mathf.Approximately(myRigidbody.velocity.y, 0f))
        {
            myAnim.SetBool("Grounded", false);
        }
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        myAnim.SetFloat("Speed", Mathf.Abs(myRigidbody.velocity.x));
        KillPlane.transform.position = new Vector2(transform.position.x, KillPlane.transform.position.y);
    } 
    
    // Level Management kýsmý
    void OnTriggerEnter2D(Collider2D other)
    {

        
        //ölümü saðlayan mekanik
        if (other.tag == "KillPlane")
        {
            gameObject.SetActive(false);
            transform.position = respawnPosition;
            thehealthManager.Respawn();
        }
       
        else if (other.tag == "Checkpoint")
        {
            respawnPosition = other.transform.position;
        }
       
    }
    

}