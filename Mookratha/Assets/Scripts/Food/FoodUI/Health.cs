using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image ringHealthBar;
    public Image ringburnBar;

    float health = 0;
    float maxHealth = 100;
    float burn = 0;
    float maxBurn = 100;

    float lerpSpeed;
    FoodController foodController;

    private void Start()
    {
        foodController = GetComponent<FoodController>();
    }

    private void Update()
    {
        Cook(foodController.cookLevel,ref health);
        Cook(foodController.burnLevel,ref burn);
        ColorChanger();
        lerpSpeed = 3f * Time.deltaTime;
        HealthBarFiller();
    }

    void HealthBarFiller()
    {
        ringHealthBar.fillAmount = Mathf.Lerp(ringHealthBar.fillAmount, (health / maxHealth), lerpSpeed);
        ringburnBar.fillAmount = Mathf.Lerp(ringburnBar.fillAmount, (burn / maxBurn), lerpSpeed);
    }

    void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (health / maxHealth));
        Color burnColor = Color.Lerp(Color.green, Color.black, (burn / maxBurn));
        ringHealthBar.color = healthColor;
        ringburnBar.color = burnColor;
    }

    public void Cook(float cal, ref float valueForEqual)
    {
        valueForEqual = cal;
    }
}
