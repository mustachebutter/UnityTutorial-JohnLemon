using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IStatChange
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float damage = 10.0f;
    [SerializeField] private float health = 100.0f;

    public float Speed 
    {
        get { return speed; } 
        set
        {
            if(speed == value) return;
            speed = value;
            if(OnSpeedChange != null)
            {
                OnSpeedChange(speed);
            }
        }
    }
    public float Damage {get { return damage; } }
    public float Health {get { return health; } }

    public delegate void OnStatChangeDelegate(float newValue);
    public event OnStatChangeDelegate OnHealthChange;
    public event OnStatChangeDelegate OnDamageChange;
    public event OnStatChangeDelegate OnSpeedChange;

    public void ChangeStatOnCollectItem(ECollectItemType itemType, float amount)
    {
        switch (itemType)
        {
            case ECollectItemType.Health:
                health = Mathf.Clamp(health + amount, 0.0f, 100.0f);
                break;
            case ECollectItemType.Damage:
                damage = Mathf.Clamp(damage + amount, 0.0f, 100.0f);
                break;
            case ECollectItemType.Speed:
                Speed = Mathf.Clamp(speed + amount, 0.0f, 2.0f);
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
