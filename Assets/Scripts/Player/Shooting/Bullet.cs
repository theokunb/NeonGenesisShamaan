using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed, maxLifeTime, damage = 1;

    float lifeTime = 0;

    float direction;

    bool isMove = true;

    SpriteRenderer sprite;

    void Start()
    {

    }

 
    void Update()
    {
        if (isMove)
        {
            lifeTime += Time.deltaTime;
            transform.position += transform.right * speed * Time.deltaTime;
        }

        if (lifeTime >= maxLifeTime)
        {
            Death();
        }
    }

    public void SetDirection(float direction)
    {
        transform.eulerAngles = new Vector3(0, 0, direction);
    }

    public void Death()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gameObject = collision.gameObject;

        Damageble damageble = gameObject.GetComponent<Damageble>();

        if (damageble != null)
            damageble.Damage(damage);


        Death();
    }
}
