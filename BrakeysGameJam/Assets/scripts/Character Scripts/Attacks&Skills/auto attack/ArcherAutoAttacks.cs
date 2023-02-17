using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArcherAutoAttacks : MonoBehaviour
{
    private bool canattack;
    private HeroStats heroStats;
    public AutoAttackData attackData;
    public GameObject Projectile;
    public GameObject attackPoint;
   
    private float timer;
    private int currentDamage;
    private int numArrows ;
    public int AutoAttackLeve;
    [SerializeField]private float angleBetweenArrows = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        currentDamage = attackData.Damage;
        numArrows = attackData.ProjectileAmount;
        timer = TimeUntilAttack();
    }

    // Update is called once per frame
    void Update()
    {
        SummonRangedProjectile();
    }

    public void SummonRangedProjectile()
    {
        if (canattack)
        {
            SpawnArrows();
            canattack = false;
            timer = TimeUntilAttack();
        }
        else
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                canattack = true;
            }
        }

    }
    

    private float TimeUntilAttack()
    {
        timer = attackData.TimeUntileNextAttack - (attackData.AttackInterval - heroStats.GetAttackSpeed());

        return timer;
    }


    public void SetStatData(HeroStats heroStats)
    {
        this.heroStats = heroStats;
    }
    void SpawnArrows()
    {
        // Calculate the total angle of the spread of arrows
        float totalAngle = angleBetweenArrows * (numArrows - 1);

        // Calculate the starting angle for the first arrow
        float startingAngle = transform.eulerAngles.z - totalAngle / 2;

        // Spawn each arrow
        for (int i = 0; i < numArrows; i++)
        {
            // Calculate the angle for this arrow
            float angle = startingAngle + i * angleBetweenArrows;

            // Instantiate a new arrow from the prefab
            GameObject newArrow = Instantiate(Projectile);

            // Set the position of the new arrow to the spawner's position
            newArrow.transform.position = attackPoint.transform.position;

            // Set the rotation of the new arrow to match the angle
            newArrow.transform.eulerAngles = new Vector3(0, 0, angle);

            // Set the direction of the arrow's movement to the player's forward vector
            Vector2 arrowDirection = Quaternion.Euler(0, 0, angle) * Vector2.up;

            // Set the velocity of the arrow's rigidbody to the arrow direction times the arrow speed
            Rigidbody2D arrowRigidbody = newArrow.GetComponent<Rigidbody2D>();
            newArrow.GetComponent<arrowHitbox>().setDamade(currentDamage + heroStats.GetAttackDamage());
            arrowRigidbody.velocity = arrowDirection * attackData.ProjectileSpeed;
        }
    }

    

}
