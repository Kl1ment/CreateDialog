
using System;
using System.Collections.Generic;

[Serializable]
public class SaveJSON
{
    public List<ReplicaJSON> Data;

    public SaveJSON(List<ReplicaJSON> dialog)
    {
        Data = dialog;
    }
}
