using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLoss : MonoBehaviour
{
    public GameObject lost;
    public GameObject winner;

    public PlayerController plyController;
    public TpBattle tpB;

    public bool trash;
    public bool toGud;

    void Start()
    {
        plyController = GameObject.FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        plyController = GameObject.FindObjectOfType<PlayerController>();
        tpB = GameObject.FindObjectOfType<TpBattle>();

        trash = plyController.die;
        toGud = tpB.op;

        suk();
        supa();
    }
    void suk()
    {
        if (trash == false)
        {
            lost.transform.localScale = new Vector3(0, 0, 0);

        }
      else  if (trash == true)
        {
            lost.transform.localScale = new Vector3(2, 1, 2);

        }
        
    }
    void supa()
    {
        if (toGud == false)
        {
            winner.transform.localScale = new Vector3(0, 0, 0);

        }
        else if (toGud == true)
        {
            winner.transform.localScale = new Vector3(4, 1, 4);

        }
    }
}
