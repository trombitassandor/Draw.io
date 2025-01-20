using System.Collections.Generic;
using UnityEngine;

public class CanvasMeshMaterialHandler : MonoBehaviour
{
    public CanvasRenderer m_CanvasRenderer;
    public Mesh m_Mesh;
    public Material[] m_Materials;

    public void SetMeshAndMaterials()
    {
        m_CanvasRenderer.SetMesh(m_Mesh);
        m_CanvasRenderer.materialCount = m_Materials.Length;

        for (int i = 0; i < m_Materials.Length; i++)
        {
            m_CanvasRenderer.SetMaterial(m_Materials[i], i);
        }
    }
}