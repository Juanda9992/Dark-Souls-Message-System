using Juanda.SoundSystem;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundClick : MonoBehaviour
{
    [SerializeField] private Button _button;

    void Start()
    {
        _button.onClick.AddListener(()=>SoundManager.instance.PlaySoundByName("UI Click"));
    }
}
