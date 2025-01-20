using System;
using System.Collections.Generic;
using UnityEngine;

public class BrushSkinListView : MonoBehaviour
{
    public BrushSkinListElementView m_BrushSkinListElementPrefab;
    public RectTransform m_BrushSkinListParent;
    public Action<BrushSkinListElementView> OnClick;

    private List<BrushSkinListElementView> m_BrushSkinListElements = new ();

    public void CreateBrushSkinListElements()
    {
        var skinsCount = GameManager.Instance.m_Skins.Count;

        for (var skinID = 0; skinID < skinsCount; ++skinID)
        {
            var brushSkinListElement = Instantiate(m_BrushSkinListElementPrefab, m_BrushSkinListParent);
            brushSkinListElement.Set(skinID);
            brushSkinListElement.OnClick += OnBrushSkinListElementClick;
            m_BrushSkinListElements.Add(brushSkinListElement);
        }
    }

    public void ClearBrushSkinListElements()
    {
        foreach (var brushSkinListElement in m_BrushSkinListElements)
        {
            brushSkinListElement.OnClick -= OnBrushSkinListElementClick;
            Destroy(brushSkinListElement.gameObject);
        }

        m_BrushSkinListElements.Clear();
    }

    private void OnBrushSkinListElementClick(BrushSkinListElementView _BrushSkinElementView)
    {
        OnClick?.Invoke(_BrushSkinElementView);
    }
}