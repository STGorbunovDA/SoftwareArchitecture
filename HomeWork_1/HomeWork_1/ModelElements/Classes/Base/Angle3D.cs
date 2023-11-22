namespace HomeWork_1.ModelElements.Classes.Base
{
    public class Angle3D
    {
        // https://habr.com/ru/companies/unigine/articles/672930/
        public Point3D Point { get; set; }
        public Angle3D(Point3D point)
        {
            Point = point;
        }
    }
}
