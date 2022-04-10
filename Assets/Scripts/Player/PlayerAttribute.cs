using UnityEngine;
using UnityEngine.UI;

public class PlayerAttribute : MonoBehaviour
{
    int minPower = 2;
    public int maxPower = 8;
    float minSpeed = 3f;
    public float maxSpeed = 10f;
    public int maxHealth = 1000;
    private int _power = 2;
    private float _speed = 3f;
    private int _health = 300;

    public int power
    {
        get { return _power; }
        set
        {
            _power = value;
            if (value < minPower) _power = minPower;
            if (value > maxPower) _power = maxPower;
        }
    }
    public float speed
    {
        get { return _speed; }
        set
        {
            _speed = value;
            if (value < minSpeed) _speed = minSpeed;
            if (value > maxSpeed) _speed = maxSpeed;
        }
    }

    public int health
    {
        get { return _health; }
        set
        {
            _health = value;
            if (value > maxHealth) _health = maxHealth;
        }
    }


    public Text powerText;
    public Text healthText;
    public Text speedText;

    void Start()
    {
    }

    void Update()
    {
        if (health <= 0)
            health = 0;
        powerText.text = $"P: {_power} / {maxPower}";
        healthText.text = $"H: {_health} / {maxHealth}";
        speedText.text = $"S: {_speed} / {maxSpeed}";
    }

    void UpgradePower(int amount)
    {
        power += amount;
    }
}
