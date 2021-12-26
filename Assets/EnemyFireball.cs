using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireball : MonoBehaviour
{
    private float speed = 5f;
    public Rigidbody2D rb;
    private int damage = 5;

    [SerializeField]
    private GameManager GM;
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        target = GM.player;

    }


    private void Update()
    {
        Vector2 dir = target.transform.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("Fireball hiinfo : " + hitInfo.name);

        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }

        Destroy(gameObject);

    }
}
