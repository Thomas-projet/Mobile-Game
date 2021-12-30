using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform fire_point;
    public GameObject fireball_prefab;


    [SerializeField]
    private GameManager GM;


    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }

    public void set_target_to_first_enemy()
    {
        GM.target = GM.enemy1;
    }

    public void set_target_to_second_enemy()
    {
        GM.target = GM.enemy2;
    }


    public void use_fireball()
    {
        Debug.Log("use_fireball");
        Instantiate(fireball_prefab, fire_point.position, fire_point.rotation, GameObject.FindGameObjectWithTag("Canvas").transform);
    }

}
