
using UnityEngine;

public class CreatorAnswer : MonoBehaviour
{
    [SerializeField] private GameObject _answerPrefab;

    public Answer AddAnswer()
    {
        GameObject newAnswer = Instantiate(_answerPrefab);
        newAnswer.transform.SetParent(transform);

        return newAnswer.GetComponent<Answer>();
    }
}
