using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCooldown : MonoBehaviour
{

    [SerializeField]
    private Image image_CD;
    [SerializeField]
    private Text text_CD;

    public GameObject img;


    private bool is_on_CD = false;
    private float CD_time = 3.0f;
    private float CD_timer = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        text_CD.gameObject.SetActive(false);
        image_CD.fillAmount = 0.0f;
        img.SetActive(false);

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
            text_CD.gameObject.SetActive(false);
            image_CD.fillAmount = 0.0f;
            img.SetActive(false);
        }
        else
        {
            text_CD.text = Mathf.RoundToInt(CD_timer).ToString();
            image_CD.fillAmount = CD_timer / CD_time;
        }
    }


    public void Use_Spell()
    {
        if (is_on_CD)
        {
            //return false;

        }
        else
        {
            img.SetActive(true);
            is_on_CD = true;
            text_CD.gameObject.SetActive(true);
            CD_timer = CD_time;

            
        }
    }

}
