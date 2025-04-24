using System.Collections.Generic;
using UnityEngine;

public class MainMenuCanvasManager : MonoSingleton<MainMenuCanvasManager>
{
    [SerializeField] private List<CanvasGroup> List_CanvasGroups;

    private int currentPage;
    void Start()
    {
        Init();
    }

    void Init()
    {
        for (int i = 0; i < List_CanvasGroups.Count; i++)
        {
            if (List_CanvasGroups[i].gameObject.activeSelf)
            {
                currentPage = i;
                break;
            }
        }
    }

    void ChangePage(CanvasGroup currentPage, CanvasGroup newPage)
    {
        currentPage.interactable = false;
        currentPage.blocksRaycasts = false;
        currentPage.alpha = 0;
        currentPage.gameObject.SetActive(false);
        newPage.gameObject.SetActive(true);
        newPage.interactable = true;
        newPage.blocksRaycasts = true;
        newPage.alpha = 1;
    }
    
    public void GoToOtherPage(CanvasGroup canvasGroup)
    {
        int index = currentPage;
        for (int i = 0; i < List_CanvasGroups.Count; i++)
        {
            if (List_CanvasGroups[i] == canvasGroup)
            {
                currentPage = i;
                break;
            }
        }
        ChangePage(List_CanvasGroups[index], canvasGroup);
    }
    
    public void GoToOtherPageWithHisIndex(int index)
    {
        ChangePage(List_CanvasGroups[currentPage], List_CanvasGroups[index]);
        currentPage = index;
    }
}
