using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public GameObject player;
    public GameObject target;
    public GameObject enemy1;
    public GameObject enemy2;

    public Transform position_first_skill;
    public Transform position_second_skill;
    public Transform position_third_skill;
    public Transform position_fourth_skill;

    public GameObject skill_1;
    public GameObject skill_2;
    public GameObject skill_3;
    public GameObject skill_4;


    public bool player_is_using_a_skill = false;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(skill_1, position_first_skill.position, position_first_skill.rotation, GameObject.FindGameObjectWithTag("Skill_1").transform);
        Instantiate(skill_2, position_second_skill.position, position_second_skill.rotation, GameObject.FindGameObjectWithTag("Skill_2").transform);
        Instantiate(skill_3, position_third_skill.position, position_third_skill.rotation, GameObject.FindGameObjectWithTag("Skill_3").transform);
        Instantiate(skill_4, position_fourth_skill.position, position_fourth_skill.rotation, GameObject.FindGameObjectWithTag("Skill_4").transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
