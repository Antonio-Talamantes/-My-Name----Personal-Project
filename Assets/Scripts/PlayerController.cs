using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20.0f;
    private float horizontalInput;
    private float forwardInput;
    private float roatationSpeed = 5;
    public int playerHp;

    private float zBound = 6;
    private float xBound = 13;
    public float gZBound = 6;
    public float gXBound = 13;

    public bool onOverWorld;
    public bool die = false;
    public bool boomPlay = false;

    public GameObject me;
    public GameObject smoke;

    public UnityEngine.Camera camera1;
    public UnityEngine.Camera camera2;

    public Vector3 startPos;

    public ParticleSystem boom;

    public ButtonHandler bHandler;


    void Start()
    {
        playerHp = 30;
        startPos = transform.position;
        smoke.SetActive(false);
    }
    
    void Update()
    {
        if(playerHp <= 0)
        {             
            die = true;
           
            StartCoroutine(destroybb());
        }

        incresemovement();
        MovePlayer();
        ConstrainPlayerPosition();
    }
    void incresemovement()
    {
        zBound = gZBound;
        xBound = gXBound;
    }
    void MovePlayer() {
        if (onOverWorld == true)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");

            transform.Rotate(Vector3.up * roatationSpeed * horizontalInput);
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        }
       

    }

    private void OnCollisionEnter(Collision land)
    {
        if(land.gameObject.tag == "overworld")
        {
            onOverWorld = true;
            camera1.enabled = true;
            camera1.GetComponent<AudioListener>();
            camera2.enabled = false;
        }

        else

        {
            onOverWorld = false;
            camera1.enabled = false;
            camera2.enabled = true;
        }
    }
    void ConstrainPlayerPosition() {

        if (onOverWorld == true)

        {
            if (transform.position.z < -zBound)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
            }
            if (transform.position.z > zBound)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
            }
            if (transform.position.x < -xBound)
            {
                transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
            }
            if (transform.position.x > xBound)
            {
                transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
            }
        }
    }
   
    IEnumerator destroybb()
    {
        
        if (die == true)
        {           
            yield return new WaitForSeconds(1);
            boom.Play();
            Destroy(me);
           
           
        }
    }
    
    
}
