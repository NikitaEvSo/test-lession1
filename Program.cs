using Learning;
using static Learning.HitObject;
namespace Learning
{
    public class HitObject(int time, ObjectType objectType)
    {

        public enum ObjectType
        {
            Circle, Slider
        }
        public int Time { get; set; } = time;
        public ObjectType Type { get; set; } = objectType;
    }
}


#region firstTask
// public static class Program
//     {
//         public static void Main()
//         {

//             List<HitObject> objects = [new(9, ObjectType.Circle), new(19, ObjectType.Slider), new(20, ObjectType.Slider), new(15, ObjectType.Circle), new(11, ObjectType.Slider)];
//             var FilteredObjects =
//             // FilterAbove10(
//                 objects
//             // )
//             .OrderBy(it => it.Time).ToList<HitObject>();
//             FilteredObjects.ForEach(it => Console.WriteLine($"{it.Time}| {it.Type}"));
//             Console.WriteLine(FilteredObjects.CountBy(it => it.Type).First());
//             Console.WriteLine(FilteredObjects.CountBy(it => it.Type).Last());

//         }
//      public static List<HitObject> FilterAbove10(List<HitObject> objects)
//         {
//             return objects.FindAll(it => it.Time >= 10);
//         }    
//     }
#endregion
public static class Program
{
    public static async Task Main()
    {
        const string path = "/home/nikita/Документы/tests/HitObjects.txt";
        List<HitObject> objects = [new(9, ObjectType.Circle), new(19, ObjectType.Slider), new(20, ObjectType.Slider), new(15, ObjectType.Circle), new(11, ObjectType.Slider)];
        await SaveObjectsAsync(path, objects);
        var loaded = await LoadObjectsAsync(path);
        loaded.ForEach(it => Console.WriteLine($"{it.Time}| {it.Type}"));
    }
    public static async Task SaveObjectsAsync(string filePath, IEnumerable<HitObject> objects)
    {
        var content = objects.Select(it => $"{it.Time},{it.Type}");
        await File.WriteAllLinesAsync(filePath, content);
    }

    public static async Task<List<HitObject>> LoadObjectsAsync(string filePath)
    {
        List<HitObject> hitObjects = [];
        var content = await File.ReadAllLinesAsync(filePath);
        if (content != null)
        {
            content.ToList().ForEach(it =>
            {
                var currentObj = it.Split(',');
                hitObjects.Add(new(int.Parse(currentObj[0]), Enum.Parse<ObjectType>(currentObj[1])));
            }
            );
        }
        return hitObjects;
    }
}