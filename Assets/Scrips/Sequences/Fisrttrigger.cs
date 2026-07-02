
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Fisrttrigger : MonoBehaviour
{
   [SerializeField] private GameObject _playerScrips;
    [SerializeField] private GameObject _textbox;
    [SerializeField] private GameObject _guidearrow;
    private void OnTriggerEnter(Collider other)
    {
        _playerScrips.GetComponent<FirstPersonMovement>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(Fisrttrigger1());
    }
    IEnumerator Fisrttrigger1()
    {
        _textbox.GetComponent<TMP_Text>().text = "Hãy nhìn phía trước kìa, có thứ gì đó";
        yield return new WaitForSeconds(2.0f);
        _textbox.GetComponent<TMP_Text>().text = "";
        _playerScrips.GetComponent<FirstPersonMovement>().enabled = true;
        _guidearrow.SetActive(true);
    }
}
