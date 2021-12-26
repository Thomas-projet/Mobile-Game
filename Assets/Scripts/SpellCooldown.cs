using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCooldown : MonoBehaviour
{
    public GameObject img;
    [SerializeField]
    private Image image_CD;
    [SerializeField]
    private Text text_CD;

    

    public bool instant_skill = true;


    private bool is_on_CD = false;
    public float CD_time = 3.0f;
    private float CD_timer = 0.0f;


    private GameManager GM;
    public GameObject[] buttons_parent;

    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
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
            foreach (GameObject button in buttons_parent)
            {
                button.GetComponent<Button>().interactable = true;
            }
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
            if (instant_skill == false)
            {
                if (GM.player_is_using_a_skill)
                {
                    return;
                }
            }

            img.SetActive(true);
            is_on_CD = true;
            text_CD.gameObject.SetActive(true);
            CD_timer = CD_time;
            foreach (GameObject button in buttons_parent)
            {
                button.GetComponent<Button>().interactable = false;
            }


        }
    }

}
