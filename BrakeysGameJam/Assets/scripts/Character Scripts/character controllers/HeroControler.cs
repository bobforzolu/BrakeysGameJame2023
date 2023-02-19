using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class HeroControler :MonoBehaviour,IDamagable
{
    public HeroStats heroStats { get; private set; }
    public event EventHandler OnPlayerDeath;

    protected GameInput input;
    private Rigidbody2D RB2D;
    public  CharacterData characterData;
    public AbilityIconeData skilliconData;
    private HeroHealthVisual healthVisual;
    public LevelSystemController levelSystem { get; private set; }
    protected bool isdead;
    public bool ispaused;

    protected virtual void Awake()
    {
        heroStats = new HeroStats(characterData);

    }
    protected virtual void Start()
    {
        LoadData();
        ispaused= false;
        levelSystem= GetComponent<LevelSystemController>();
        levelSystem.levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
        healthVisual = GetComponentInChildren<HeroHealthVisual>();
        healthVisual.SetHeroStats(heroStats);
        input.playerInputActions.player.pause.performed += Pause_performed;
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (!ispaused)
        {
            CharacterManager.instance.PauseMenue.SetActive(true);
            Time.timeScale= 0f;
        }
        else if(ispaused)
        {
            CharacterManager.instance.PauseMenue.SetActive(false);
            Time.timeScale = 1.0f;
        }

    }

    private void OnDisable()
    {
        levelSystem.levelSystem.OnLevelChanged -= LevelSystem_OnLevelChanged;

    }

    private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
    {
        heroStats.levelStatincrease();
    }
    protected virtual void Update()
    {
        if(isdead) return;
        heroStats.RecoverEnergy();
        heroStats.RecoverHealth();
    }

    public  void LoadData()
    {
            OnPlayerDeath += HeroControler_OnPlayerDeath;
        input = GetComponent<GameInput>();
        RB2D = GetComponent<Rigidbody2D>();
    }
    
   
    public  void Movement(float speed)
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
    private void OnDestroy()
    {
        OnPlayerDeath -= HeroControler_OnPlayerDeath;
    }
    

    private void HeroControler_OnPlayerDeath(object sender, EventArgs e)
    {
        Destroy(gameObject);
        
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("hit by of : " +damage);
        heroStats.TakeDamage(damage);
        if (heroStats.GetHealth() <= 0 && !isdead )
        {
            isdead = true;

            OnPlayerDeath?.Invoke(this, null);

        }
    }

    public void Recover(int Amount)
    {
        throw new NotImplementedException();
    }
}
