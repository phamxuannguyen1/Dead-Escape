using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PickupPistol : MonoBehaviour
{
  [SerializeField]  private float _thedistance;
    [SerializeField] private GameObject _actionDisplay;
    [SerializeField] private GameObject _actionText;
    [SerializeField] private GameObject _fakepistol;
    [SerializeField] private GameObject _realpistol;

    [SerializeField] private GameObject _guidearrow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _thedistance = ActionCasting.DistanceFromTarget;
    }
    private void OnMouseOver()
    {
        if(_thedistance <= 3)
        {
            _actionText.GetComponent<TMP_Text>().text = "";
            _actionDisplay.SetActive(true);
            _actionText.SetActive(true);
           
        }
        if(Input.GetButtonDown("Action"))
        {
            if (_thedistance <= 3)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                _actionDisplay.SetActive(false);
                _actionText.SetActive(false);
                _fakepistol.SetActive(false);
                _realpistol.SetActive(true);
                _guidearrow.SetActive(false);
            }
        }
    }
    private void OnMouseExit()
    {
        _actionDisplay.SetActive(false);
        _actionText.SetActive(false);
    }
}
