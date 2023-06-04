using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image ringHealthBar;
    public Image ringburnBar;
    public Image ringLayout;

    float doneLevel = 0;
    float burnLevel = 0;
    public float maxLevel = 95;

    float lerpSpeed;
    FoodController foodController;
    FoodBoomController foodBoomController;
    public bool isFat = false;

    private void Start()
    {
        if (isFat)
        {
            foodBoomController = GetComponent<FoodBoomController>();
        }
        else foodController = GetComponent<FoodController>();


    }

    private void Update()
    {
        if (isFat)
        {
            CookToDone(foodBoomController.cookLevel, ref doneLevel);
            DoneToBurnFat(foodBoomController.cookLevel, ref burnLevel);
        }
        else
        {
            CookToDone(foodController.cookLevel, ref doneLevel);
            DoneToBurn(foodController.cookLevel, ref burnLevel);
        }       

        ColorChanger();
        lerpSpeed = 3f * Time.deltaTime;
        HealthBarFiller();
    }

    void HealthBarFiller()
    {
        ringHealthBar.fillAmount = Mathf.Lerp(ringHealthBar.fillAmount, (doneLevel / maxLevel), lerpSpeed);
        ringburnBar.fillAmount = Mathf.Lerp(ringburnBar.fillAmount, (burnLevel / maxLevel), lerpSpeed);
        ringLayout.fillAmount = Mathf.Lerp(ringLayout.fillAmount, (doneLevel / maxLevel), lerpSpeed);
    }

    void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (doneLevel / maxLevel));
        Color burnColor = Color.Lerp(Color.green, Color.black, (burnLevel / maxLevel));
        ringHealthBar.color = healthColor;
        ringburnBar.color = burnColor;
    }

    public void CookToDone(float cal, ref float valueForEqual)
    {
        if (valueForEqual < 100) valueForEqual = cal * 2;
    }

    public void DoneToBurn(float cal, ref float valueForEqual)
    {
        if (cal > 50 && valueForEqual < 100) valueForEqual = (cal - 50) * 2;
    }

    public void DoneToBurnFat(float cal, ref float valueForEqual)
    {
        if (cal > 30 && valueForEqual < 60) valueForEqual = (cal - 30) * 2;
    }
}
