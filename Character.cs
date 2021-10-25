using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class Character : MonoBehaviour
{
    public int health = 100, mana = 100, stamina = 100;
    public int baseHealth, baseMana, baseStamina;
    public int healthRegen = 1, manaRegen = 1, staminaRegen = 1;
    public string characterName = "void";
    public List<Attack> attacks;
    public Attack selectedAttack;
    public GameObject body;
    public string bodyType;
    float myUpdate = 0;

    public void SetBody()
    {
        body = GameObject.FindGameObjectWithTag(bodyType);
        GameObject bodyInstance = Instantiate(body, transform.position, Quaternion.identity);
        bodyInstance.transform.SetParent(transform);
        bodyInstance.GetComponent<MeshRenderer>().enabled = true;
        foreach (MeshRenderer renderer in bodyInstance.GetComponentsInChildren<MeshRenderer>())
        {
            renderer.enabled = true;
        }
        gameObject.name = characterName;
        bodyInstance.name = bodyType;
    }

    public void Update()
    {
        if (selectedAttack == null && attacks.Count > 0)
        {
            selectedAttack = attacks.First();
        }
        if (Time.time > myUpdate + .025f )
        {
            if (stamina < baseStamina) stamina += staminaRegen;
            if (mana < baseMana) mana += manaRegen;
            myUpdate = Time.time;
        }


        UIElements._instance.setHealth(health);
        UIElements._instance.updateSelectedAttack(selectedAttack);
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public virtual void ReduceMana(int cost) {
        mana -= cost;
    }


}
