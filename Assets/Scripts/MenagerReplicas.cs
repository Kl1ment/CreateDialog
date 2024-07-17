
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

[RequireComponent(typeof(SaveFile))]
public class MenagerReplicas : MonoBehaviour
{
    public static MenagerReplicas Instance;
    public int CountReplicas => _replicas.Count;
    
    private List<Replica> _replicas = new List<Replica>();

    private SaveFile _saveFile;


    private void Start()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;

        _saveFile = GetComponent<SaveFile>();
    }

    public void DeletedReplica(Replica replica)
    {
        int index = _replicas.IndexOf(replica);
        _replicas.RemoveAt(index);
        for (int i = 0;  i < _replicas.Count; i++)
        {
            if (i >= index)
            {
                _replicas[i].UpdateNumber(i);
            }
            _replicas[i].UpdateAnswerConnection(index);
        }
    }

    public void AddReplica(Replica replica)
    {
        replica.UpdateNumber(_replicas.Count);
        _replicas.Add(replica);
    }

    public void SaveFile()
    {
        List<ReplicaJSON> replicas = new List<ReplicaJSON>();

        foreach (Replica replica in _replicas)
        {
            replicas.Add(replica.GetReplica());
        }

        SaveJSON saveJson = new SaveJSON(replicas);

        string path = _saveFile.GetPath();
        string name = _saveFile.Name;
        string file = JsonUtility.ToJson(saveJson);

        if (path == "")
        {
            path = "Dialogs";
            Directory.CreateDirectory(path);
        }

        try
        {
            WriteFile(path, name, file);
        }
        catch
        {
                _saveFile.WrongPath();
        }
    }

    private void WriteFile(string path, string name, string file)
    {
        FileStream fileStrim = new FileStream($"{path}/{name}", FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStrim, Encoding.UTF8))
        {
            writer.Write(file);
        }

        _saveFile.DisActive();
    }
}