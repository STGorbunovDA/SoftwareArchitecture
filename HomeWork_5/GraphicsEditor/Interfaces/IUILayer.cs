namespace GraphicsEditor.Interfaces
{
    internal interface IUILayer
    {
        void OpenProject(String fileName);
        void ShowProjectSettings();
        void SaveProject();
        void PrintAllModels();
        void PrintAllTextures();
        void RenderAll();
        void AddModel();
        void RemoveModel(int i);
    }
}
