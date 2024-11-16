using System;

public class SpeedBooster : Items
{
    public static event Action Speed;

    public void UserHealth()
    {
        Speed?.Invoke();
    }
}
