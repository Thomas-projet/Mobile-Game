using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunButton : MonoBehaviour
{
    private GameManager GM;


    // Start is called before the first frame update
    void Start()
    {

        GM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Stun()
    {
        Player P = GM.player.GetComponent<Player>(); ;
        P.Use_Stun();
    }

}
