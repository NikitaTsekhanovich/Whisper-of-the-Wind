using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenController : MonoBehaviour
{
    [SerializeField] private GraphicRaycaster _loadingScreenBlockClick;
    [SerializeField] private Image _background;
    // [SerializeField] private Image _leafsBackground;
    [SerializeField] private TMP_Text _loadingText;
    [SerializeField] private Image _logo;
    private Coroutine _loadingTextAnimation;
    private const byte startGameEventCode = 1;

    public static LoadingScreenController Instance;

    private void Start() 
    {
        if (Instance == null)
        { 
            Instance = this; 
        } 
        else 
        { 
            Destroy(this);  
        }
    }
    
    public void ChangeScene(string nameScene)
    {
        Time.timeScale = 1f;

        _loadingScreenBlockClick.enabled = true;
        StartAnimationFade(nameScene);
    }

    private void StartAnimationFade(string nameScene)
    {
        _loadingTextAnimation = StartCoroutine(StartLoadingTextAnimation());
        _loadingText.DOFade(1f, 0.7f);
        _logo.DOFade(1f, 0.7f);
        // _leafsBackground.DOFade(1f, 0.7f);

        DOTween.Sequence()
            .Append(_background.DOFade(1f, 0.7f))
            .AppendInterval(1.5f)
            .AppendCallback(() => LoadScene(nameScene))
            .AppendInterval(0.3f)
            .OnComplete(() => EndAnimationFade());
    }

    private void LoadScene(string nameScene)
    {
        SceneManager.LoadSceneAsync(nameScene);
    }

    private void EndAnimationFade()
    {
        // _leafsBackground.DOFade(0f, 0.7f);
        _logo.DOFade(0f, 0.7f);
        _loadingText.DOFade(0f, 0.7f);

        DOTween.Sequence()
            .Append(_background.DOFade(0f, 0.7f))
            .AppendCallback(() => StopCoroutine(_loadingTextAnimation))
            .AppendCallback(() => _loadingScreenBlockClick.enabled = false)
            .AppendCallback(() => Time.timeScale = 1f);
    }

    private IEnumerator StartLoadingTextAnimation()
    {
        while (true)
        {
            _loadingText.text = $"Loading.";
            yield return new WaitForSeconds(0.3f);

            _loadingText.text = $"Loading..";
            yield return new WaitForSeconds(0.3f);

            _loadingText.text = $"Loading...";
            yield return new WaitForSeconds(0.3f);
        }
    }
}
