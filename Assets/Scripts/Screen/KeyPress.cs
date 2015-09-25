using UnityEngine;
using System.Collections;

/// <summary>
/// Classe para tela de pressione qualquer tecla
/// </summary>
public class KeyPress : SceneBehaviour 
{
    [SerializeField] 
    private string m_NextSceneToLoad = string.Empty;
    
    [SerializeField]
    private AudioClip m_SoundAnyKeyDown;

    private bool m_KeyPressed = false;
	
	void Update () 
    {
        if (m_KeyPressed)
            return;

        if (!Input.anyKeyDown)
            return;
        
        m_KeyPressed = true;
        LoadLevelWithPlaySound(m_NextSceneToLoad, m_SoundAnyKeyDown);
	}
}
