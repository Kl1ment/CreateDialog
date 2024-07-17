
using UnityEngine;

public class CreatorReplicas : MonoBehaviour
{
    [SerializeField] private Canvas _replica;

    public void CreateNewReplica(Vector2 position)
    {
        Canvas ReplicaCanvas = Instantiate(_replica);
        ReplicaCanvas.transform.position = position;

        Replica replica = ReplicaCanvas.GetComponent<Replica>();
        MenagerReplicas.Instance.AddReplica(replica);
    }
}
