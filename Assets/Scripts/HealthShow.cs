using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthShow : MonoBehaviour
{
    public Text eh;
    public Text ph;

    public Image image;

    public bool isNotShowing2;
    private bool myTurn;

   
   public ButtonHandler buttonH;
   public PlayerController pc;

    private void Start()
    {
       // buttonH = GameObject.FindObjectOfType<ButtonHandler>();
        pc = GameObject.FindObjectOfType<PlayerController>();
        eh = GameObject.Find("bad guy").GetComponent<Text>();
        ph = GameObject.Find("h").GetComponent<Text>();
    }
    void Update()
    {
        isNotShowing2 = pc.onOverWorld;
        myTurn = buttonH.yourTurn;
        on();

        healthBb();
    }
    public void on()
    {
        if (isNotShowing2 == true)
        {
            image.transform.localScale = new Vector3(0, 0, 0);
            
        }
        else if (isNotShowing2 == false)
        {
            image.transform.localScale = new Vector3(1, 1, 1);
            
        }
    }
    public void healthBb() 
    {
        if (myTurn == true)
        {
            ph.text = " " + pc.playerHp;
        }
        else if (myTurn == false)
        {
            eh.text = " " + buttonH.total;
        } 
    }
}
