using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform fire_point;
    public GameObject fireball_prefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("coucou");
        }
        
    }

    public void use_fireball()
    {
        Debug.Log("use_fireball");
        Instantiate(fireball_prefab, fire_point.position, fire_point.rotation, GameObject.FindGameObjectWithTag("Canvas").transform);

    }

}
