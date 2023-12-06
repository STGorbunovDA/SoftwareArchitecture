using GraphicsEditor.Classes;

public class Program
{
    public static void Main(string[] args)
    {
        Editor3D editor3D = new Editor3D();
        bool f = true;

        while (f)
        {
            Console.Clear();
            Console.WriteLine("*** МОЙ 3D РЕДАКТОР ***");
            Console.WriteLine("=======================");
            Console.WriteLine("1. Открыть проект");
            Console.WriteLine("2. Сохранить проект");
            Console.WriteLine("3. Отобразить параметры проекта");
            Console.WriteLine("4. Отобразить все модели проекта");
            Console.WriteLine("5. Отобразить все текстуры проекта");
            Console.WriteLine("6. Выполнить рендер всех моделей");
            Console.WriteLine("7. Выполнить рендер модели");
            Console.WriteLine("8. Добавить модель");
            Console.WriteLine("9. Удалить модель");
            Console.WriteLine("0. ЗАВЕРШЕНИЕ РАБОТЫ ПРИЛОЖЕНИЯ");
            Console.Write("Пожалуйста, выберите пункт меню: ");

            if (int.TryParse(Console.ReadLine(), out int no))
            {
                try
                {
                    switch (no)
                    {
                        case 0:
                            Console.WriteLine("Завершение работы приложения");
                            f = false;
                            break;
                        case 1:
                            Console.Write("Укажите наименование файла проекта: ");
                            string fileName = Console.ReadLine();
                            editor3D.OpenProject(fileName);
                            Console.WriteLine("Проект успешно открыт.");
                            break;
                        case 3:
                            editor3D.ShowProjectSettings();
                            break;
                        case 4:
                            editor3D.PrintAllModels();
                            break;
                        case 5:
                            editor3D.PrintAllTextures();
                            break;
                        case 6:
                            editor3D.RenderAll();
                            break;
                        case 7:
                            Console.Write("Укажите номер модели: ");
                            if (int.TryParse(Console.ReadLine(), out int modelNo))
                                editor3D.RenderModel(modelNo);
                            else Console.WriteLine("Номер модели указан некорректно.");
                            break;
                        case 8:
                            editor3D.AddModel();
                            break;
                        case 9:
                            Console.Write("Укажите номер модели: ");
                            if (int.TryParse(Console.ReadLine(), out int number))
                                editor3D.RemoveModel(number);
                            else Console.WriteLine("Номер модели указан некорректно.");
                            break;
                        default:
                            Console.WriteLine("Укажите корректный пункт меню.");
                            break;
                    }
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Укажите корректный пункт меню.");
            }
        }
    }
}