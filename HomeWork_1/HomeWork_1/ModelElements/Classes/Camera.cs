using HomeWork_1.ModelElements.Classes.Base;
using HomeWork_1.ModelElements.Interfaces;

namespace HomeWork_1.ModelElements.Classes
{
    public class Camera : IRotate, IMove
    {
        public int _id = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public Point3D Location { get; set; }
        public Angle3D Angle { get; set; }

        public Camera(string name, Point3D location, Angle3D angle)
        {
            Id = _id++;
            Name = name;
            Location = location;
            Angle = angle;
        }


        public string Rotate(Angle3D angle)
        {
            return $"Вращаем: по X: {angle.Point.X}\n" +
                   $"Вращаем: по Y: {angle.Point.Y}\n" +
                   $"Вращаем: по Z: {angle.Point.Z}";
        }

        public string Rotate(Point3D point)
        {
            return $"Перемещаем: по X: {point.X}\n" +
                   $"Перемещаем: по Y: {point.Y}\n" +
                   $"Перемещаем: по Z: {point.Z}";
        }
        public override string ToString()
        {
            return "Какое-то описание";
        }
    }
}
