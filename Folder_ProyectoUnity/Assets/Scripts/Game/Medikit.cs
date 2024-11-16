using System;

public class Medikit : Items
{
    public static event Action<int> health;

    private int medikit = 5;

    public void UserHealth()
    {
        health?.Invoke(medikit);
    }
}
