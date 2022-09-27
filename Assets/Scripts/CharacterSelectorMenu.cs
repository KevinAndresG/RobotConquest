using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelectorMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI CoinText;
    [SerializeField] Image selector;
    [SerializeField] GameObject[] characterSelect;
    [SerializeField] Button selectButton;
    [SerializeField] Button buyButton;
    GameObject coinImage;
    GameObject coinValue;
    [SerializeField] Vector3 offsetButtons;
    int price;
    int index;

    void Start()
    {
        if (!PlayerPrefs.HasKey("CharacterSelected"))
        {
            PlayerPrefs.SetFloat("CharacterSelected", 0);
            Load();
        }
        else
            Load();
        CoinText.text = $"{PlayerPrefs.GetInt("TotalCoins")}";
        SoundController.Instance.Music(SceneManager.GetActiveScene().name);
    }
    public void X()
    {
        SceneManager.LoadScene("MainMenu");
        SoundController.Instance.PlayEffect(5);
    }
    public void Select(int characterIndex)
    {
        index = characterIndex;
        selector.transform.position = characterSelect[characterIndex].transform.position;
        if (characterSelect[characterIndex].transform.childCount > 0)
        {
            buyButton.gameObject.SetActive(true);
            buyButton.transform.position = characterSelect[characterIndex].transform.position + offsetButtons;
            coinImage = characterSelect[characterIndex].transform.GetChild(0).gameObject;
            if (coinImage.transform.childCount > 0)
            {
                coinValue = coinImage.transform.GetChild(0).gameObject;
                price = int.Parse(coinValue.GetComponent<Text>().text);

            }
        }
        else if (characterSelect[characterIndex].transform.childCount <= 0)
        {
            selectButton.gameObject.SetActive(true);
            selectButton.transform.position = characterSelect[characterIndex].transform.position + offsetButtons;
            buyButton.gameObject.SetActive(false);
        }
    }
    public void buyCharacter()
    {
        if (PlayerPrefs.GetInt("TotalCoins") >= price)
        {
            PlayerPrefs.SetInt("TotalCoins", (PlayerPrefs.GetInt("TotalCoins") - price));
            if (characterSelect[index].transform.GetChild(0).gameObject != null)
            {
                Destroy(characterSelect[index].transform.GetChild(0).gameObject);
                buyButton.gameObject.SetActive(false);
                selectButton.transform.position = characterSelect[index].transform.position + offsetButtons;
                Load();
            }
            selectButton.gameObject.SetActive(true);
        }
    }
    public void Load()
    {
        selector.transform.position = characterSelect[PlayerPrefs.GetInt("CharacterSelected")].transform.position;
        CoinText.text = $"{PlayerPrefs.GetInt("TotalCoins")}";
    }
    public void SelectCharacter()
    {

        PlayerPrefs.SetInt("CharacterSelected", index);
        selectButton.gameObject.SetActive(false);
    }
}
