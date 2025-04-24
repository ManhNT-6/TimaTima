using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PopupResult : MonoBehaviour
{       
        [SerializeField] private Text resultText;
        private bool isCorrect;

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
                var mainMenu = FindObjectOfType<MainMenuCanvasManager>();
                mainMenu.GoToOtherPageWithHisIndex(3);
                resultText.text = isCorrect ? "Correct" : "Incorrect";
                resultText.color = isCorrect ? Color.green : Color.red;

                StartCoroutine(HidePopupCouroutine(mainMenu));
        }

        IEnumerator HidePopupCouroutine(MainMenuCanvasManager mainMenu)
        {
                yield return new WaitForSeconds(2f);
                mainMenu.GoToOtherPageWithHisIndex(2);
        }
        
}
