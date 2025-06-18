using UnityEngine;

public class TutorialImageController : MonoBehaviour
{
    public GameObject labImage;
    public GameObject officeImage;
    public GameObject hallwayImage;
    public GameObject introducingImage;

    public void ShowIntroducing()
    {
        labImage.SetActive(false);
        officeImage.SetActive(false);
        hallwayImage.SetActive(false);
        introducingImage.SetActive(true);
    }

    public void ShowLab()
    {
        hallwayImage.SetActive(false);
        labImage.SetActive(true);
        officeImage.SetActive(false);
        introducingImage.SetActive(false);
    }

    public void ShowOffice()
    {
        hallwayImage.SetActive(false);
        labImage.SetActive(false);
        officeImage.SetActive(true);
        introducingImage.SetActive(false);
    }

    public void ShowHallway()
    {
        labImage.SetActive(false);
        officeImage.SetActive(false);
        hallwayImage.SetActive(true);
        introducingImage.SetActive(false);
    }

    public void HideAll()
    {
        introducingImage.SetActive(false);
        hallwayImage.SetActive(false);
        labImage.SetActive(false);
        officeImage.SetActive(false);
    }
}
