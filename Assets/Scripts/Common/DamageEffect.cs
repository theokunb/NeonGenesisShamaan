using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    [SerializeField]
    int maxCountFrame = 20;

    [SerializeField]
    Color damageColor;

    Damageble damageble;
    //SliderController healthBar;

    SpriteRenderer sprite;

    int count = 0;
    void Start()
    {
        damageble = GetComponent<Damageble>();
        damageble.OnCharacterTakeDamageEvent += Damageble_OnCharacterTakeDamageEvent;
        sprite = GetComponentInChildren<SpriteRenderer>();

        //healthBar = GameObject.Find("HealthBar").GetComponent<SliderController>();
    }

    private void Damageble_OnCharacterTakeDamageEvent(object obj)
    {
        //healthBar.SetHealth(damageble.HitPoint);
        //FindObjectOfType<AudioManager>().Play("PlayerHit");
        StartCoroutine(TakeDamageAnim());
    }


    IEnumerator TakeDamageAnim()
    {
        float step = 0;

        while (count <= maxCountFrame)
        {
            count++;
            step += 10 * Time.deltaTime;
            sprite.color = Color.Lerp(sprite.color, damageColor, step);

            yield return null;
        }
        count = 0;
        sprite.color = Color.white;
    }
}
