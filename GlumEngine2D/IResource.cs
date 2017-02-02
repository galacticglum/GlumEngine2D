namespace GlumEngine2D
{
    public interface IResource<out T>
    {
        T Load(string filePath);
    }
}
