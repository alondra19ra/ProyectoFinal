using System;
public class Shield : Items
{
    public static event Action shield;
    public void UserShield()
    {
        shield?.Invoke();
    }
}
