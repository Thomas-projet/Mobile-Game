using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballButton : MonoBehaviour
{
    private GameManager GM;
    public GameObject fireball_prefab;

    // Start is called before the first frame update
    void Start()
    {

        GM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Use_fireball()
    {
        Debug.Log("use_fireball");
        if (GM.target!=null)
        {
            Instantiate(fireball_prefab, GM.player.GetComponent<Player>().fire_point.position, GM.player.GetComponent<Player>().fire_point.rotation, GameObject.FindGameObjectWithTag("Canvas").transform);
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
