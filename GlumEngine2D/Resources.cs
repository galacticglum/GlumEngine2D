namespace GlumEngine2D
{
    public static class Resources
    {
        public static T Load<T>(string filePath) where T : IResource<T>, new()
        {
             // TODO: Check for file path validity.

            return new T().Load(filePath);       
        } 
    }
}
