using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Target AudioSources")]
    public AudioSource bgmSource;                       // ������� ��¿� ������ҽ�
    public AudioSource effectSource;                    // ȿ���� ��¿� ������ҽ�

    /// <summary>
    /// The Volume of bgm source
    /// </summary>
    private float bgmVolume = 0.5f;                     // ������� ����
    public float BGMVolume                              // ������� ����
    {
        get { return bgmVolume; }
        set {
            bgmVolume = value;
            bgmSource.volume = value;
        }
    }

    /// <summary>
    /// The Volume of effect source
    /// </summary>
    private float effectVolume = 0.5f;                  // ȿ���� ����
    public float EffectVolume                           // ȿ���� ����
    {
        get { return effectVolume; }
        set {
            effectVolume = value;
            effectSource.volume = value;
        }
    }

    /// <summary>
    /// Get BGM Source Playing
    /// </summary>
    public bool IsBGMPlaying {
        get {
            return bgmSource.isPlaying;
        }
    }

    /// <summary>
    /// Get Effect Source Playing
    /// </summary>
    public bool IsEffectPlaying {
        get {
            return effectSource.isPlaying;
        }
    }

    /// <summary>
    /// ���� �����ϴ� SoundManager ��ȯ. ���� �� ���� ����
    /// </summary>
    /// <returns></returns>
    public static AudioManager GetOrCreate(AudioSource bgmSource = null, AudioSource effectSource = null)
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        if (!audioManager)
        {
            GameObject _audioManager = new GameObject(typeof(AudioManager).Name);
            audioManager = _audioManager.AddComponent<AudioManager>();

            if (bgmSource == null)
            {
                GameObject _bgmSource = new GameObject("BGMSource");
                AudioSource _bgmSourceComponent = _bgmSource.AddComponent<AudioSource>();
                _bgmSourceComponent.playOnAwake = false;
                _bgmSourceComponent.mute = false;
                _bgmSourceComponent.loop = false;
                _bgmSource.transform.SetParent(_audioManager.transform);
                audioManager.bgmSource = _bgmSourceComponent;
            }
            else
            {
                bgmSource.loop = false;
                bgmSource.playOnAwake = false;
                audioManager.bgmSource = bgmSource;
            }

            if (effectSource == null)
            {
                GameObject _effectSource = new GameObject("EffectSource");
                AudioSource _effectSourceComponent = _effectSource.AddComponent<AudioSource>();
                _effectSourceComponent.playOnAwake = false;
                _effectSourceComponent.mute = false;
                _effectSourceComponent.loop = false;
                _effectSource.transform.SetParent(_audioManager.transform);
                audioManager.effectSource = _effectSourceComponent;
            }
            else
            {
                effectSource.loop = false;
                effectSource.playOnAwake = false;
                audioManager.effectSource = effectSource;
            }
        }

        return audioManager;
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        Initialize();
    }

    /// <summary>
    ///  �ʱ⼳��
    /// </summary>
    private void Initialize()
    {
        bgmSource.volume = BGMVolume;
        effectSource.volume = EffectVolume;
    }

    public void SetMuted(bool mute)
    {
        bgmSource.mute = mute;
        effectSource.mute = mute;
    }

    /// <summary>
    /// ������� Ŭ�� ����
    /// </summary>
    /// <param name="clip"></param>
    public void SetBGMClip(AudioClip clip)
    {
        bgmSource.clip = clip;
    }

    /// <summary>
    /// ������� ��ġ ����
    /// </summary>
    /// <param name="time"></param>
    public void SetBGMTime(float time)
    {
        bgmSource.time = time;
    }

    /// <summary>
    /// ������� ���� ����
    /// </summary>
    /// <param name="volume"></param>
    public void SetBGMVolume(float volume)
    {
        BGMVolume = volume;
    }

    /// <summary>
    /// ������� ���
    /// </summary>
    /// <param name="repeat">�ݺ� ����</param>
    public void PlayBGM(bool repeat = true)
    {
        if (!bgmSource.isPlaying && bgmSource.clip != null)
        {
            bgmSource.loop = repeat;
            bgmSource.Play();
        }
    }

    /// <summary>
    /// ������� ���
    /// </summary>
    /// <param name="clip">�������</param>
    /// <param name="repeat">�ݺ� ����</param>
    public void PlayBGM(AudioClip clip, bool repeat = true)
    {
        bgmSource.clip = clip;
        bgmSource.loop = repeat;
        bgmSource.Play();
    }

    /// <summary>
    /// ������� ���
    /// </summary>
    /// <param name="clip">�������</param>
    /// <param name="volume">����</param>z
    /// <param name="repeat">�ݺ� ����</param>
    public void PlayBGM(AudioClip clip, float volume, bool repeat = true)
    {
        BGMVolume = volume;

        bgmSource.clip = clip;
        bgmSource.loop = repeat;
        bgmSource.Play();
    }

    /// <summary>
    /// BGM �Ͻ�����
    /// </summary>
    public void PauseBGM()
    {
        bgmSource.Pause();
    }

    /// <summary>
    /// BGM �Ͻ����� ����
    /// </summary>
    public void ResumeBGM()
    {
        if (!bgmSource.isPlaying) bgmSource.Play();
        else bgmSource.UnPause();
    }

    /// <summary>
    /// BGM ����
    /// </summary>
    public void StopBGM()
    {
        bgmSource.Stop();
    }

    /// <summary>
    /// ȿ���� Ŭ�� ����
    /// </summary>
    /// <param name="clip"></param>
    public void SetEffectClip(AudioClip clip)
    {
        effectSource.clip = clip;
    }

    /// <summary>
    /// ȿ���� ��ġ ����
    /// </summary>
    /// <param name="time"></param>
    public void SetEffectTime(float time)
    {
        effectSource.time = time;
    }

    /// <summary>
    /// ȿ���� ���� ����
    /// </summary>
    /// <param name="volume"></param>
    public void SetEffectVolume(float volume)
    {
        EffectVolume = volume;
    }

    /// <summary>
    /// ȿ���� ���
    /// </summary>
    /// <param name="clip">ȿ����</param>
    public void PlayEffectSound(AudioClip clip)
    {
        effectSource.PlayOneShot(clip, EffectVolume);
    }

    /// <summary>
    /// ȿ���� ���
    /// </summary>
    /// <param name="clip">ȿ����</param>
    /// <param name="volume">����</param>
    public void PlayEffectSound(AudioClip clip, float volume)
    {
        effectSource.PlayOneShot(clip, volume);
    }

    /// <summary>
    /// ȿ���� �Ͻ�����
    /// </summary>
    public void PauseEffect()
    {
        effectSource.Pause();
    }

    /// <summary>
    /// ȿ���� �Ͻ����� ����
    /// </summary>
    public void ResumeEffect()
    {
        if (!effectSource.isPlaying) effectSource.Play();
        else effectSource.UnPause();
    }

    /// <summary>
    /// ȿ���� ����
    /// </summary>
    public void StopEffect()
    {
        effectSource.Stop();
    }
}