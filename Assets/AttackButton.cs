using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
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

    public void Attack()
    {
        Player P = GM.player.GetComponent<Player>();
        if (GM.target != null)
        {
            P.Use_Attack();
        }
    }

    public void set_target_to_first_enemy()
    {
        GM.target = GM.enemy1;
    }

    public void set_target_to_second_enemy()
    {
        GM.target = GM.enemy2;
    }
}
