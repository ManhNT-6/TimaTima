using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PopupResult : MonoBehaviour
{
        [SerializeField] private CanvasGroup popupResult;
        [SerializeField] private Text resultText;
        private bool isCorrect;
        private void Awake()
        {
                HidePopup();
        }

        public void SendResultCorrect()
        {
                isCorrect = true;
                ShowPopupResult();
        }

        public void SendResultWrong()
        {
                isCorrect = false;
                ShowPopupResult();
        }
        
        public void ShowPopupResult()
        {
                popupResult.gameObject.SetActive(true);
                resultText.text = isCorrect ? "Correct" : "Incorrect";
                resultText.color = isCorrect ? Color.green : Color.red;

                StartCoroutine(HidePopupCouroutine());
        }

        IEnumerator HidePopupCouroutine()
        {
                yield return new WaitForSeconds(2f);
                HidePopup();
        }
        
        private void HidePopup()
        {
                popupResult.gameObject.SetActive(false);
        }
}
