using System.Collections.Generic;
using UnityEngine;

public class BrushSkinSelectorScreen : MonoBehaviour
{
    public int m_IdSkin = 0;
    public Animation m_CurrentBrushSkinViewAnimation;
    public BrushSkinView m_CurrentBrushSkinView;
    public BrushSkinListView m_BrushSkinListView;

    private GameManager GameManager => GameManager.Instance;
    private List<SkinData> Skins => GameManager.m_Skins;

    private StatsManager m_StatsManager;

    private void Awake()
    {
        m_StatsManager = StatsManager.Instance;
        m_BrushSkinListView.OnClick += OnBrushSkinListElementClick;
    }

    private void OnEnable()
    {
        int favoriteSkin = Mathf.Min(m_StatsManager.FavoriteSkin, Skins.Count - 1);
        m_CurrentBrushSkinView.Set(Skins[favoriteSkin]);
        m_IdSkin = m_StatsManager.FavoriteSkin;
        m_BrushSkinListView.CreateBrushSkinListElements();
    }

    private void OnDisable()
    {
        m_BrushSkinListView.ClearBrushSkinListElements();
    }

    private void OnBrushSkinListElementClick(BrushSkinListElementView _BrushSkinElementView)
    {
        ChangeBrush(_BrushSkinElementView.SkinID);
    }

    private void ChangeBrush(int _NewBrush)
    {
        _NewBrush = Mathf.Clamp(_NewBrush, 0, Skins.Count);
        m_IdSkin = _NewBrush;
        GameManager.m_PlayerSkinID = m_IdSkin;
        m_CurrentBrushSkinView.Set(Skins[m_IdSkin]);
        m_CurrentBrushSkinViewAnimation.Play();
        m_StatsManager.FavoriteSkin = m_IdSkin;
        GameManager.SetColor(GameManager.ComputeCurrentPlayerColor(true, 0));
    }
}