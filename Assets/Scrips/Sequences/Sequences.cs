using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;

public class Sequences : MonoBehaviour
{
    public GameObject _playerScrips;
    public GameObject _facescreenIn;
    public GameObject _textbox;

    private void Start()
    {
        _playerScrips.GetComponent<FirstPersonMovement>().enabled = false;

        StartCoroutine(ScencePlayer());
    }
    IEnumerator ScencePlayer()
    {
        yield return new WaitForSeconds(1.6f);
        _facescreenIn.SetActive(false);
        _textbox.GetComponent<TMP_Text>().text ="Tôi cần phải rời khỏi đây";
        yield return new WaitForSeconds(2.0f);
        _textbox.GetComponent<TMP_Text>().text ="";
        _playerScrips.GetComponent<FirstPersonMovement>().enabled = true;

    }
}
