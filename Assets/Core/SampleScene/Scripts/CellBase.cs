using UnityEngine;


public class CellBase : MonoBehaviour {

    public Material normalMaterial;
    public Material highlighMaterial;
    public Material killMaterial;

    private Renderer m_Renderer;

    private enum Type
    {
        Normal,
        Highlight,
        Kill
    }

    private Type myType = Type.Normal;

    public void SetAsPossibleDestination()
    {
        SetHighlightMaterial();
        myType = Type.Highlight;
    }

    public void SetAsKillPawnDestination()
    {
        SetKillMaterial();
        myType = Type.Kill;
    }

    public void SetAsNormal()
    {
        SetNormalMaterial();
        myType = Type.Normal;
    }

    private void Start()
    {
        m_Renderer = GetComponent<Renderer>();
        SetAsNormal();
    }

    private void SetNormalMaterial()
    {
        m_Renderer.material = normalMaterial;
    }

    private void SetHighlightMaterial()
    {
        m_Renderer.material = highlighMaterial;
    }

    private void SetKillMaterial()
    {
        m_Renderer.material = killMaterial;
    }
}
