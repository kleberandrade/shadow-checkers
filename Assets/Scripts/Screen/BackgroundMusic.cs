using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour 
{
    [SerializeField]
    private AudioClip m_ThemeMusic;

    [SerializeField]
    private bool m_PlayOnStart;

    private SoundManager m_SoundManager;

	void Start () 
    {
        m_SoundManager = SoundManager.Instance;

        if (m_PlayOnStart)
             PlayMusic();
	}

    public void PlayMusic()
    {
       m_SoundManager.PlayMusic(m_ThemeMusic);
    }

    public void PlayMusic(AudioClip themeMusic)
    {
        m_ThemeMusic = themeMusic;
        PlayMusic();
    }
}
