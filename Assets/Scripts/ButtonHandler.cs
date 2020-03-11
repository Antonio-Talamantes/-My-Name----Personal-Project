using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{


    public Button button;
    public Button button2;

    

    public Text bSpin;
    public Text wave;
    public Text heal;
    public Text run;

    public int total;
    public int eHp;
    public int hold;
    public int eAtk;
    public int ww;
    public int health;
    public int nextFight = 50;

    public ParticleSystem water;
    public ParticleSystem p;
    public ParticleSystem lavaBall;
    public ParticleSystem earthQ;
    public ParticleSystem grass;
    public ParticleSystem bspin;

    private PlayerController pController;
    private ButtonManager buttonManager;
    private HealthShow hs;
    private TpBattle tp;


    public bool yourTurn = true;
    public bool isNotShowing1;
    public bool ran;
    public bool changeSize;
    public bool ded;
    private bool press = true;
    private bool thing = true;

    public void Start()
    {
        total = 10;
        eHp = total;
        ran = false;

        pController = GameObject.FindObjectOfType<PlayerController>();
        buttonManager = GameObject.FindObjectOfType<ButtonManager>();
        hs = GameObject.FindObjectOfType<HealthShow>();
        tp = GameObject.FindObjectOfType<TpBattle>();

        bSpin = GameObject.Find("BallSpin").GetComponent<Text>();
        wave = GameObject.Find("Wave").GetComponent<Text>();
        heal = GameObject.Find("Heal").GetComponent<Text>();
        run = GameObject.Find("Run").GetComponent<Text>();


    }

    public void Update()
    {
       
        ded = pController.die;

        isNotShowing1 = pController.onOverWorld;
       
        show();

    }

    public void show()
    {
       

        if (isNotShowing1 == true)
        {
            buttonManager.HideButton();

            changeSize = false;

            button2.transform.localScale = new Vector3(0, 0, 0);
        }

        else if (eHp >= 1 && isNotShowing1 == false && changeSize == false && press == true && tp.op == false)
        {
            buttonManager.AppearButton();
            changeSize = true;
           
        }


        else if (eHp <= 0 && isNotShowing1 == false && changeSize == true && press == true && tp.op == false)
            {           
            buttonManager.HideButton();
            button2.transform.localScale = new Vector3(4, 4, 4);
            changeSize = false;          
            }

        else if (ded == true)
        {
            press = false;
            buttonManager.HideButton();
            button2.transform.localScale = new Vector3(0, 0, 0);
        }

        if (isNotShowing1 == false && tp.op == true)
        {
            buttonManager.HideButton();

            button2.transform.localScale = new Vector3(0, 0, 0);
        }
    }
    public void Button1()
    {
        if (yourTurn == true)
        {
            yourTurn = false;

            countdownbs();
          

            bSpin.text = "It's";
            wave.text = "The";
            heal.text = "opponent";
            run.text = "turn";
        }
    }
    public void Button2()
    {
        if (yourTurn == true)
        {
            yourTurn = false;

            countdownww();
          

            bSpin.text = "It's";
            wave.text = "The";
            heal.text = "opponent";
            run.text = "turn";
        }
    }
    public void Button3()
    {
        if (yourTurn == true)
        {
            yourTurn = false;

            countUp();
           

            bSpin.text = "It's";
            wave.text = "The";
            heal.text = "opponent";
            run.text = "turn";
        }
    }
    public void Button4()
    {
        if (yourTurn == true)
        {
            ran = true;
            Debug.Log("hola");

        }
    }
    public void Button5()
    {
        nextFight = nextFight - 50;
        yourTurn = true;

        bSpin.text = "Ball Spin";
        wave.text = "Water Wave";
        heal.text = "Heal";
        run.text = "Run";
       
    }
    
  
    private void countdownbs()
    {
        bspin.Play();
        total = total - 2;
        eHp = total;
        StartCoroutine(EnemyFire());
      
    }
    private void countdownww()
    {
        water.Play();
        ww = Random.Range(0, 5);
        total = total - ww;
        eHp = total;
        StartCoroutine(EnemyFire());
    }
    private void countUp()
    {
        p.Play();
        health = Random.Range(1, 5);
        pController.playerHp = pController.playerHp + health;
        StartCoroutine(EnemyFire());
    }

    IEnumerator EnemyFire() 
    {
        if (eHp >= 1)
        {
            eAtk = Random.Range(0, 6);
            yield return new WaitForSeconds(2);

            pController.playerHp = pController.playerHp - eAtk;
            yourTurn = true;

            lavaBall.Play();
            earthQ.Play();
            grass.Play();

          //  StartCoroutine(effect());

            bSpin.text = "Ball Spin";
            wave.text = "Water Wave";
            heal.text = "Heal";
            run.text = "Run";           
        }  
      
    }
   
   /* IEnumerator effect()
    {
        if (ded == true)
        {
            yield return new WaitForSeconds(.1f);
            bang.Play();
        }
    }*/
}