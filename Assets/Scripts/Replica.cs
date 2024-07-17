
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Replica : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    private int _number = 0;

    [SerializeField] private TMP_InputField _inputFieldPhrase;
    [SerializeField] private GameObject _panelAnswers;
    [SerializeField] private TextMeshProUGUI _numberText;

    private CreatorAnswer _creatorAnswer;
    private List<Answer> _answers = new List<Answer>();

    private Vector3 _offset;

    public int Number => _number;

    private void Start()
    {
        _creatorAnswer = _panelAnswers.GetComponent<CreatorAnswer>();
    }

    public void AddAnswer()
    {
        _answers.Add(_creatorAnswer.AddAnswer());
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _offset = transform.position - mousePos;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0))
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + _offset;
        }
    }

    public void UpdateAnswerConnection(int index)
    {
        foreach (var answer in _answers)
        {
            answer.UpdateConnection(index);
        }
    }

    public void UpdateNumber(int number)
    {
        _number = number;
        _numberText.text = $"Реплика # {_number + 1}";
    }

    public void Delet()
    {
        MenagerReplicas.Instance.DeletedReplica(this);
        Destroy(gameObject);
    }

    public void DeletAnswer(Answer answer)
    {
        _answers.Remove(answer);
    }

    public ReplicaJSON GetReplica()
    {
        List<AnswerJSON> answerList = new List<AnswerJSON>();
        foreach (var answer in _answers)
        {
            answerList.Add(answer.GetAnswer());
        }

        return new ReplicaJSON(_inputFieldPhrase.text, answerList);
    }
}

[Serializable]
public class ReplicaJSON
{
    public string Phrase;
    public List<AnswerJSON> Answers;


    public ReplicaJSON(string text, List<AnswerJSON> answers)
    {
        Phrase = text;
        Answers = answers;
    }
}