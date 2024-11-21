public interface IToolUser
{
    void SetHammer(Hammer hammer);
    void SetSaw(Saw saw);
}

public class Hammer
{
    public void Use()
    {
        Console.WriteLine("Using hammer.........");
    }
}

public class Saw
{
    public void Use()
    {
        Console.WriteLine("Using saw.........");
    }
}

public class Builder : IToolUser
{
    private Hammer _hammer;
    private Saw _saw;


    public void SetHammer(Hammer hammer)
    {
        _hammer = hammer;
    }

    public void SetSaw(Saw saw)
    {
        _saw = saw;
    }

    public static void Main(string[] args)
    {
        Builder builder = new Builder();
        Hammer hammer = new Hammer();
        Saw saw = new Saw();

        builder.SetHammer(hammer);
        builder.SetSaw(saw);
        builder.BuildNow();
    }

    void BuildNow()
    {
        _hammer.Use();
        _saw.Use();
        Console.WriteLine("House build success");
    }
}