using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ビープ音プレイヤー
/// </summary>
public class BeepSoundPlayer : MonoBehaviour
{
    /// <summary>
    /// デバッグモード。Bキーでビープ音を鳴らす。Bキーを離すと音が止まる
    /// </summary>
    [SerializeField] private bool isDebug = false;

    /// <summary>
    /// ビープ音を鳴らすかどうか。鳴らす場合はtrue。ただしisDebugがtrueの場合はこの値は無視される
    /// </summary>
    [SerializeField] private bool isOn = false;
    public bool IsOn
    {
        get { return isOn; }
        set { isOn = value; }
    }

    /// <summary>
    /// ビープ音の周波数 
    /// </summary>
    [SerializeField] private float frequency = 440.0f;
    public float Frequency
    {
        get { return frequency; }
        set { frequency = value; }
    }

    /// <summary>
    /// ビープ音の音量
    /// </summary>
    [SerializeField] private float volume = 1.0f;
    public float Volume
    {
        get { return volume; }
        set { volume = value; }
    }

    private AudioSource audioSource;
    private float phase = 0.0f;
    private float sampleRate = 48000f;

    void Start()
    {
        phase = 0f;
        sampleRate = AudioSettings.outputSampleRate;
        
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = 0.0f;
        audioSource.Play(); // volumeだけで再生停止を制御するため、Play()したままにしておく
    }

    void Update()
    {
        sampleRate = AudioSettings.outputSampleRate;

        float gain = 0.0f;
        if (isDebug)
        {
            if (Input.GetKey(KeyCode.B))
            {
                gain = volume;
            }
        }
        else
        {
            if (isOn)
                gain = volume;
        }

        audioSource.volume = gain;
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        float step =  frequency / sampleRate;
        for (int s = 0; s < data.Length; s += channels)
        {
            float o = Mathf.Sin(phase * Mathf.PI * 2.0f); // sine wave
            o = Mathf.Sign(o); // square wave

            for (int c = 0; c < channels; ++c)
                data[s + c] = o; 
            
            phase += step;
            if(phase > 1.0f)
                phase = 0.0f;
        }
    }
}