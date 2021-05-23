using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fight : MonoBehaviour
{
    [SerializeField]

    public float health = 100;
    public float damage = 10;
    public float speedAttack = 1f;
//    public Image bar;
    private float e_damage, e_speedAttack;
    private float startHealth;
    private string tagEnemy;
    // Start is called before the first frame update
    void Start()
    {
        startHealth = health;
        if (gameObject.tag == "mob_enemy") //Определение тега врага
            tagEnemy = "mob_player";
        else
            tagEnemy = "mob_enemy";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //       bar.fillAmount = health / startHealth; // Вычисляется отношение нынешнего здоровья к общему
        if (health <= 0)
        {
            Destroy(gameObject); //Если хп закончилось, объект уничтожается
            Debug.Log("-1");
        }
    }

    void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.gameObject.tag == tagEnemy) //Нужно всем мобам (злым и хорошим) задать тег 'mob'
            StartCoroutine(ToDamage(enemy));
    }

    void OnCollisionExit2D(Collision2D enemy)
    {
        if (enemy.gameObject.tag == tagEnemy)
            StopAllCoroutines();
    }

    private IEnumerator ToDamage(Collision2D enemy)
    {
        e_damage = enemy.gameObject.GetComponent<Fight>().damage; //Урон противника
        e_speedAttack = enemy.gameObject.GetComponent<Fight>().speedAttack; //Скорость атаки противника
        while (health > 0)
        {
            health -= e_damage; //Обьект получает теряет хп равный урону противника
            
            yield return new WaitForSeconds(e_speedAttack); //Обьект получает удар со скоростью удара противника
        }
    }

}
