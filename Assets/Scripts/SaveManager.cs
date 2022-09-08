using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveManager
{
    public static void SaveGame(ProductCard figureModel, string fileName)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + fileName;

        FileStream stream = new FileStream(path, FileMode.Create);
        ItemData data = new ItemData(figureModel);
        binaryFormatter.Serialize(stream, data);
        stream.Close();
    }

    public static ItemData LoadGame(string fileName)
    {
        string path = Application.persistentDataPath + fileName;

        if (File.Exists(path))
        {
            var binaryFormatter = new BinaryFormatter();
            
            FileStream stream = new FileStream(path, FileMode.Open);

            ItemData data = binaryFormatter.Deserialize(stream) as ItemData;
            stream.Close();

            return data;
        }
        return null;
    }
}