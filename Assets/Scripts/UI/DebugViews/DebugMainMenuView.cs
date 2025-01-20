public class DebugMainMenuView : DebugToggleView
{
    protected override void OnToggleChanged(bool _isToggleOn)
    {
        if (_isToggleOn)
        {
            MainMenuView.Instance.gameObject.SetActive(false);
            MainMenuView_old.Instance.gameObject.SetActive(true);
            MainMenuView_old.Instance.Transition(true);
        }
        else
        {
            MainMenuView_old.Instance.gameObject.SetActive(false);
            MainMenuView.Instance.gameObject.SetActive(true);
            MainMenuView.Instance.Transition(true);
        }
    }
}