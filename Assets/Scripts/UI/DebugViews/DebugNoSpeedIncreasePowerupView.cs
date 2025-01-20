public class DebugNoSpeedIncreasePowerupView : DebugToggleView
{
    protected override void OnToggleChanged(bool _isToggleOn)
    {
        GameManager.Instance.m_IsSpeedIncreaseDisabled = _isToggleOn;
    }
}