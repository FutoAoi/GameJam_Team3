using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider seSlider;

    void Start()
    {
        //スライダーを動かした時の処理を登録
        bgmSlider.onValueChanged.AddListener(SetAudioMixerBGM);
        seSlider.onValueChanged.AddListener(SetAudioMixerSE);

        SetAudioMixerBGM(bgmSlider.value);
        SetAudioMixerSE(seSlider.value);
    }

    //BGM
    public void SetAudioMixerBGM(float value)
    {
        float volume = Mathf.Lerp(-80f, 0f, value / 10f);

        audioMixer.SetFloat("BGM", volume);

        Debug.Log($"BGM:{volume}");
    }

    //SE
    public void SetAudioMixerSE(float value)
    {
        float volume = Mathf.Lerp(-80f, 0f, value / 10f);

        audioMixer.SetFloat("SE", volume);

        Debug.Log($"SE:{volume}");
    }
}
