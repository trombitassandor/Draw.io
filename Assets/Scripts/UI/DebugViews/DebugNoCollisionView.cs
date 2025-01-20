public class DebugNoCollisionView : DebugToggleView
{
    protected override void OnToggleChanged(bool _isToggleOn)
    {
        GameManager.Instance.m_IsCollisionDisabled = _isToggleOn;
    }
}