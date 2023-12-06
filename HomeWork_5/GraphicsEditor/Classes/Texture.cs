using GraphicsEditor.Interfaces;

public class Texture : IEntity
{
    private static int _counter = 50000;
    private readonly int _id;

    static Texture()
    {
        _counter = 50000;
    }

    public Texture()
    {
        _id = ++_counter;
    }

    public int GetId()
    {
        return _id;
    }

    public override string ToString()
    {
        return $"Texture #{_id}";
    }
}