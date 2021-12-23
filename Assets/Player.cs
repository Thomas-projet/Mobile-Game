using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Animator animator;

    private bool is_on_CD = false;
    private float CD_time = 2.0f;
    private float CD_timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {

        if (is_on_CD)
        {
            Apply_CD();
        }
    }


    void Apply_CD()
    {
        CD_timer -= Time.deltaTime;

        if (CD_timer < 0.0f)
        {
            is_on_CD = false;
            animator.SetBool("Dodging", false);
        }

    }


    public void Use_Dodge()
    {
        if (is_on_CD)
        {

        }
        else
        {
            animator.SetBool("Dodging", true);
            is_on_CD = true;
            CD_timer = CD_time;


        }
    }
}
