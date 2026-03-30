using Juanda.SoundSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageCooldownManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cooldownLabel;
    [SerializeField] private Slider cooldownProgressBar;
    [SerializeField] private float cooldownTimer;
    public  bool canSendMessage => currentCooldownTimer >= cooldownTimer; 
    private float currentCooldownTimer;
    private bool soundPlayed = false;

    void Awake()
    {
        currentCooldownTimer = cooldownTimer;
        cooldownProgressBar.maxValue = cooldownTimer;
        cooldownProgressBar.value = currentCooldownTimer;
        
    }
    void Update()
    {
        currentCooldownTimer+=Time.deltaTime;

        cooldownProgressBar.value = currentCooldownTimer;

        if(canSendMessage && !soundPlayed)
        {
            soundPlayed = true;
            SoundManager.instance.PlaySoundByName("Correct");
            cooldownLabel.text = "You can send a message!";
            cooldownLabel.color = Color.green;       
        }
    }

    public void OnMessageSent()
    {
        currentCooldownTimer = 0;
        soundPlayed = false;
        ShowCooldownEnabledLabel();
    }

    public void ShowCooldownEnabledLabel()
    {
        SoundManager.instance.PlaySoundByName("Error");
        cooldownLabel.text = "You cannot send a message now!";
        cooldownLabel.color = Color.red;
    }
}
