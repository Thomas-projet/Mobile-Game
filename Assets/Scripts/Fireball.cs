using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private float speed = 5f;
    public Rigidbody2D rb;
    public int damage = 40;

    [SerializeField]
    private GameManager GM;
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        target = GM.target;

    }


    private void Update()
    {
        Vector2 dir = target.transform.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("Fireball hiinfo : " + hitInfo.name);

        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
        
    }
}
