public class PowerUp_SpeedIncrease : PowerUp
{
    public float m_Factor = 50f;

    public override void OnPlayerTouched(Player _Player)
    {
        base.OnPlayerTouched(_Player);

        _Player.IncreaseSpeed(m_Factor, m_Duration);
    }
}