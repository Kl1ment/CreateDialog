
using System;
using TMPro;
using UnityEngine;

public class Answer : MonoBehaviour
{
    private Replica _parent;

    [SerializeField] private TMP_InputField _inputFieldText;
    [SerializeField] private TMP_InputField _inputFieldConnection;

    private void Start()
    {
        _parent = GetComponentInParent<Replica>();
    }

    public void ValidateConnection()
    {
        try
        {
            int numReplica = Convert.ToInt16( _inputFieldConnection.text );

            if (numReplica <= MenagerReplicas.Instance.CountReplicas && numReplica >= 0)
            {
                _inputFieldConnection.image.color = new Color32(115, 255, 115, 255);
            }
            else
            {
                ErrorValidation();
            }

        }
        catch
        {
            ErrorValidation();
        }
    }

    public void UpdateConnection(int index)
    {
        if (_inputFieldConnection.text != "")
        {
            if (Convert.ToInt16(_inputFieldConnection.text) - 1 > index)
            {
                _inputFieldConnection.text = Convert.ToString((Convert.ToInt16(_inputFieldConnection.text) - 1));
            }
            else if (Convert.ToInt16(_inputFieldConnection.text) - 1 == index)
            {
                ErrorValidation();
            }
        }
    }

    private void ErrorValidation()
    {
        _inputFieldConnection.text = "";
        _inputFieldConnection.image.color = new Color32(255, 115, 115, 255);
    }

    public void Delet()
    {
        _parent.DeletAnswer(this);
        Destroy(gameObject);
    }

    public AnswerJSON GetAnswer()
    {
        return new AnswerJSON(_inputFieldText.text, Convert.ToInt16(_inputFieldConnection.text) - 1);
    }

    public void ChoiseReplica()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Replica replica = hit.transform.GetComponent<Replica>();

            if (replica != null)
            {
                _inputFieldConnection.text = Convert.ToString(replica.Number + 1);
            }
        }
    }

    public void ChangeConnection()
    {
        _inputFieldConnection.image.color = new Color32(170, 200, 255, 255);
    }
}

[Serializable]
public class AnswerJSON
{
    public string Text;
    public int Connect;

    public AnswerJSON(string text, int connect)
    {
        Text = text;
        Connect = connect;
    }
}
