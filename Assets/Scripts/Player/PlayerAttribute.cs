using UnityEngine;
using UnityEngine.UI;

public class PlayerAttribute : MonoBehaviour
{
    public int power = 1;
    public float speed = 6f;
    public int health = 100;

    public int maxPower = 100;
    public float maxSpeed = 20f;
    public int maxHealth = 200;

    public Text powerText;
    public Text healthText;
    public Text speedText;

    void Start()
    {

    }

    void Update()
    {
        powerText.text = "P: " + power.ToString();
        healthText.text = "H: " + health.ToString();
        speedText.text = "S: " + speed.ToString();
    }

    void UpgradePower(int amount)
    {
        power += amount;
    }
}
