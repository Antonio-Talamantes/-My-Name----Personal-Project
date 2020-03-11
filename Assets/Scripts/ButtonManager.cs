using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject[] buttonList;
    private Vector3 hide = new Vector3(0, 0, 0);
    private Vector3 appear = new Vector3(2, 2, 2);


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideButton ()
    {
        
        foreach(GameObject btn in buttonList)
        {
            btn.transform.localScale = hide;
        }
    }

   public void AppearButton ()
    {
        foreach (GameObject btn in buttonList)
        {
            btn.transform.localScale = appear;
        }
    }
}
