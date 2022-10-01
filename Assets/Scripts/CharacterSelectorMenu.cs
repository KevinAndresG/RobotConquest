using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelectorMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI CoinText;
    [SerializeField] Image selector;
    [SerializeField] GameObject[] characters;
    [SerializeField] Button selectButton;
    [SerializeField] Button buyButton;
    GameObject coinImage;
    GameObject coinValue;
    [SerializeField] Vector3 offsetButtons;
    int price;
    int index;
    int characterSize;
    // GameObject leftArrow;
    // GameObject rightArrow;
    void Start()
    {
        if (!PlayerPrefs.HasKey("CharacterSelected") || !PlayerPrefs.HasKey("TotalCoins"))
        {
            if (!PlayerPrefs.HasKey("TotalCoins"))
            {
                PlayerPrefs.SetInt("TotalCoins", 0);
            }
            if (!PlayerPrefs.HasKey("CharacterSelected"))
            {
                PlayerPrefs.SetFloat("CharacterSelected", 0);
                index = 0;
            }
            Load();
        }
        else
            Load();
        SoundController.Instance.Music(SceneManager.GetActiveScene().name);
        characterSize = characters.Length;
    }
    public void X()
    {
        SceneManager.LoadScene("MainMenu");
        SoundController.Instance.PlayEffect(5);
    }
    public void Select(int characterIndex)
    {
        index = characterIndex;
        selector.transform.position = characters[characterIndex].transform.position + offsetButtons;
        if (characters[characterIndex].transform.childCount > 0)
        {
            buyButton.gameObject.SetActive(true);
            selectButton.gameObject.SetActive(false);
            buyButton.transform.position = characters[characterIndex].transform.position + offsetButtons;
            coinImage = characters[characterIndex].transform.GetChild(0).gameObject;
            if (coinImage.transform.childCount > 0)
            {
                coinValue = coinImage.transform.GetChild(0).gameObject;
                price = int.Parse(coinValue.GetComponent<Text>().text);

            }
        }
        else if (characters[characterIndex].transform.childCount <= 0)
        {
            buyButton.gameObject.SetActive(false);
            if (characterIndex == PlayerPrefs.GetInt("CharacterSelected"))
            {
                selectButton.gameObject.SetActive(false);
            }
            else
                selectButton.gameObject.SetActive(true);
            selectButton.transform.position = characters[characterIndex].transform.position + offsetButtons;
        }
    }
    public void buyCharacter()
    {
        if (PlayerPrefs.GetInt("TotalCoins") >= price)
        {
            PlayerPrefs.SetInt("TotalCoins", (PlayerPrefs.GetInt("TotalCoins") - price));
            if (characters[index].transform.GetChild(0).gameObject != null)
            {
                Destroy(characters[index].transform.GetChild(0).gameObject);
                PlayerPrefs.SetString(characters[index].name, "bought");
                buyButton.gameObject.SetActive(false);
                selectButton.gameObject.SetActive(true);
                selectButton.transform.position = characters[index].transform.position + offsetButtons;
                selector.transform.position = characters[index].transform.position + offsetButtons;
                CoinText.text = $"{PlayerPrefs.GetInt("TotalCoins")}";

            }
        }
    }
    void CharacterBuyied()
    {
        int ind = 1;
        while (ind < characters.Length)
        {
            switch (PlayerPrefs.GetString(characters[ind].name))
            {
                case "bought":
                    Destroy(characters[ind].transform.GetChild(0).gameObject);
                    break;
            }
            ind++;
        }
    }
    public void SelectCharacter()
    {

        PlayerPrefs.SetInt("CharacterSelected", index);
        selectButton.gameObject.SetActive(false);
    }
    public void Arrow(string arrow)
    {
        if (arrow == "Right")
        {
            if (index < characterSize)
            {
                index++;
                if (index >= characterSize)
                {
                    index = 0;
                }
                Select(index);
            }
        }
        else if (arrow == "Left")
        {
            if (index >= 0)
            {
                index--;
                if (index < 0)
                {
                    index = characterSize - 1;
                }
                Select(index);
            }
        }
    }
    public void Load()
    {
        CoinText.text = $"{PlayerPrefs.GetInt("TotalCoins")}";
        selector.transform.position = characters[PlayerPrefs.GetInt("CharacterSelected")].transform.position + offsetButtons;
        index = PlayerPrefs.GetInt("CharacterSelected");
        if (PlayerPrefs.HasKey("Lin") || PlayerPrefs.HasKey("Kag"))
        {
            CharacterBuyied();
        }
    }
}
