using UnityEngine;
using System.Collections;

/// <summary>
/// Define se a cena será uma cena de splash onde tem um tempo para sair
/// </summary>
public class SceneTimer : SceneBehaviour
{
    /// <summary>
    /// Tempo de transição entre as cenas
    /// </summary>
    [SerializeField]
    [Range(0.01f, 10.0f)]
    private float m_TimeToNextScene = 4.0f;

    /// <summary>
    /// Nome da próxima cena
    /// </summary>
    [SerializeField]
    private string m_SceneName;

    /// <summary>
    /// Nome da música de fundo se precisa tocar algo
    /// </summary>
    [SerializeField]
    private AudioClip m_ThemeMusic;

    /// <summary>
    /// Inicia o objeto
    /// </summary>
    void Start()
    {
        PlayMusic(m_ThemeMusic);
        StartCoroutine("NextScreen", m_TimeToNextScene);
    }

    /// <summary>
    /// Coroutine para trocar a cena depois de um periodo de tempo
    /// </summary>
    /// <param name="time">tempo de espera</param>
    /// <returns></returns>
    IEnumerator NextScreen(float time)
    {
        yield return new WaitForSeconds(time);
        LoadLevel(m_SceneName);
    }
}