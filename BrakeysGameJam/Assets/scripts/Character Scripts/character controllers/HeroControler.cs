using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HeroControler :MonoBehaviour,IDamagable
{
    public HeroStats heroStats { get; private set; }

    protected GameInput input;
    private Rigidbody2D RB2D;
    public  CharacterData characterData;
    public AbilityIconeData skilliconData;
    public LevelSystemController levelSystem { get; private set; }
    private bool isdead;

    protected virtual void Awake()
    {
        heroStats = new HeroStats(characterData);

    }
    protected virtual void Start()
    {
        LoadData();
        levelSystem= GetComponent<LevelSystemController>();
        levelSystem.levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
    }
    private void OnDisable()
    {
        levelSystem.levelSystem.OnLevelChanged -= LevelSystem_OnLevelChanged;

    }

    private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
    {
        heroStats.levelStatincrease();
    }

    public  void LoadData()
    {
        input = GetComponent<GameInput>();
        RB2D = GetComponent<Rigidbody2D>();
    }
    
   
    public  void Movement(int speed)
    {
        RB2D.velocity = new Vector2(input.GetMovementInput().x * speed, input.GetMovementInput().y *speed);

    }
    public void AttackDirection(GameObject autoattack)
    {
        float angle = Mathf.Atan2(input.GetMousePosition().y, input.GetMousePosition().x) * Mathf.Rad2Deg;
        angle -= 90f;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        autoattack.transform.rotation = Quaternion.Slerp(autoattack.transform.rotation, rotation, 20* Time.deltaTime);

        
    }
    public void GetAngle()
    {

    }
 
   
    public virtual void AbilityOne()
    {

    }
    public virtual void AbilityTwo()
    {

    }

    void IDamagable.TakeDamage(int damage)
    {
        heroStats.TakeDamage(damage);
        if(heroStats.GetHealth() <= 0 && !isdead)
        {
            

        }

    }

    void IDamagable.Recover(int Amount)
    {
    }
}
