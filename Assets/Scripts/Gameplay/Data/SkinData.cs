using UnityEngine;

[CreateAssetMenu(fileName = "Skin", menuName = "Data/Skin", order = 1)]
public class SkinData : ScriptableObject
{
    public ColorData Color;
    public BrushData Brush;
}