using UnityEngine;

public class CharacterInformations : MonoBehaviour
{
    Animator anim;
    public int playerHealth;

    private bool isAlive;
    private void Start()
    {
        isAlive = true;
        anim = gameObject.GetComponent<Animator>();
    }

    public void GetDamage(int dmg)
    {
        print("Get Damage");
        playerHealth -= dmg;

        if (playerHealth < 1)
        {
            if (isAlive)
            {
                isAlive = false;
                //player dead
                anim.SetTrigger("isDead");
            }
        }
        else
        {
            //player alive
            anim.SetTrigger("isDamaged");
        }
    }
}
