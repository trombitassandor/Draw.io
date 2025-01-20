using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BrushSkinListElementView : MonoBehaviour
{
    public BrushSkinView m_BrushMainMenu;

    public int SkinID { get; private set; }

    public Action<BrushSkinListElementView> OnClick;
    
    private Button m_Button;

    private void Awake()
    {
        m_Button = GetComponent<Button>();
        m_Button.onClick.AddListener(InvokeClick);
    }

    private void OnDestroy()
    {
        m_Button.onClick.RemoveListener(InvokeClick);
    }

    public void Set(int _SkinID)
    {
        SkinID = _SkinID;

        var skin = GameManager.Instance.m_Skins[_SkinID];
        m_BrushMainMenu.Set(skin);
    }

    private void InvokeClick()
    {
        OnClick?.Invoke(this);
    }
}