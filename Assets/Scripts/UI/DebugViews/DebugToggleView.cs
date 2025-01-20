using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public abstract class DebugToggleView : MonoBehaviour
{
    private Toggle m_Toggle;

    private void Awake()
    {
        m_Toggle = GetComponent<Toggle>();
        m_Toggle.onValueChanged.AddListener(OnToggleChanged);
    }

    private void OnDestroy()
    {
        m_Toggle.onValueChanged.RemoveListener(OnToggleChanged);
    }

    protected abstract void OnToggleChanged(bool _isToggleOn);
}
