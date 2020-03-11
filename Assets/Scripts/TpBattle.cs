using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpBattle : MonoBehaviour
{
    private int death = 1;
    public int enemyhp;

    public GameObject player;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject battleplane1;
    public GameObject battleplane2;
    public GameObject battleplane3;
    public GameObject overworld1;

    public ButtonHandler bHandler;
    public PlayerController playerC;

    public bool enemyDefeated;
    public bool lavaEnemy;
    public bool stoneEnemy;
    public bool grassEnemy;
    public bool op = false;

    public ParticleSystem boom1;
    public ParticleSystem boom2;
    public ParticleSystem boom3;
   
    void Start()
    {
        bHandler = GameObject.FindObjectOfType<ButtonHandler>();
        playerC = GameObject.FindObjectOfType<PlayerController>();
        enemyDefeated = false;
        lavaEnemy = false;
        stoneEnemy = false;
        grassEnemy = false;
    }
     void Update()
    {
        enemyhp = bHandler.eHp;

        if (bHandler.nextFight == 0)
        {
            enemyDefeated = true;
        }

        enemyded();
        running();
       
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy1")
        {           
            MovePlayerToBattlePlane1();
        }
        if (collision.gameObject.tag == "enemy2")
        {         
            MovePlayerToBattlePlane2();
        }
       if (collision.gameObject.tag == "enemy3")
        { 
            MovePlayerToBattlePlane3();
        }
        if (collision.gameObject.tag == "battlePlane1")
        {
            lavaEnemy = true;            
        }
       if (collision.gameObject.tag == "battlePlane2")
        {
            stoneEnemy = true;
        }
        if (collision.gameObject.tag == "battlePlane3")
        {
            grassEnemy = true;
        }
    }
    void enemyded()
    {
        
        if (enemyDefeated == true && lavaEnemy == true)
        {
            enemy1.SetActive(false);
            MovePlayerToOverworld1();
            bHandler.total = 15;
            bHandler.yourTurn = true;
            playerC.gZBound = 10;
            playerC.gXBound = 17;
            playerC.playerHp = 30;
            bHandler.nextFight = 50;
            lavaEnemy = false;
        }
       if (enemyDefeated == true && stoneEnemy == true)
        {
            enemy2.SetActive(false);
            MovePlayerToOverworld1();
            bHandler.total = 20;
            playerC.gZBound = 14;
            playerC.gXBound = 21;
            playerC.playerHp = 30;
            bHandler.nextFight = 50;
            stoneEnemy = false;
        }
        if (enemyDefeated == true && grassEnemy == true)
        {
            enemy3.SetActive(false);

            op = true; 
        }
    }
    void running()
    {
        if (bHandler.ran == true && lavaEnemy == true)
        {
            Vector3 enemyOffset = new Vector3(-5, 2, 5);

            enemy1.transform.position = overworld1.transform.position + enemyOffset;

            player.transform.position = playerC.startPos;
            bHandler.ran = false;
            playerC.playerHp = 30;
            bHandler.total = 10;
            bHandler.total = bHandler.total + Random.Range(0 , 3); 
        }

        if (bHandler.ran == true && stoneEnemy == true)
        {
            Vector3 enemyOffset = new Vector3(0, 1, 5);

            enemy2.transform.position = overworld1.transform.position + enemyOffset;

            player.transform.position = playerC.startPos;
            bHandler.ran = false;
            playerC.playerHp = 30;
            bHandler.total = 15;
            bHandler.total = bHandler.total + Random.Range(0, 3);
        }

        if (bHandler.ran == true && grassEnemy == true)
        {
            Vector3 enemyOffset = new Vector3(5, 1, 5);

            enemy3.transform.position = overworld1.transform.position + enemyOffset;

            player.transform.position = playerC.startPos;
            bHandler.ran = false;
            playerC.playerHp = 30;
            bHandler.total = 20;
            bHandler.total = bHandler.total + Random.Range(0, 2);
        }
    }
    void MovePlayerToOverworld1()
    {
        enemyDefeated = false;
        player.transform.position = playerC.startPos;
        
        
        
    }

    void MovePlayerToBattlePlane1()
    {
        Vector3 yOffset = new Vector3(0, .5f, 0);
        Vector3 enemyOffset = new Vector3(0, .5f, 10);

        Vector3 battlePlanePos = battleplane1.transform.position + yOffset;

        player.transform.position = battlePlanePos;
        enemy1.transform.position = battlePlanePos + enemyOffset;
    }

    void MovePlayerToBattlePlane2()
    {
        Vector3 yOffset = new Vector3(0, .5f, 0);
        Vector3 enemyOffset = new Vector3(0, .5f, 10);

        Vector3 battlePlanePos = battleplane2.transform.position + yOffset;

        player.transform.position = battlePlanePos;
        enemy2.transform.position = battlePlanePos + enemyOffset;
    }

    void MovePlayerToBattlePlane3()
    {
        Vector3 yOffset = new Vector3(0, .5f, 0);
        Vector3 enemyOffset = new Vector3(0, .5f, 10);

        Vector3 battlePlanePos = battleplane3.transform.position + yOffset;

        player.transform.position = battlePlanePos;
        enemy3.transform.position = battlePlanePos + enemyOffset;
    }
}

