using Cinemachine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Components
{
    public class SceneDataComponent : MonoBehaviour
    {
        private int _score = 0;
        private float _volume = 0.5f;

        public Canvas canvas;
        public Terrain terrain;
        public GameObject plantsParent;
        public GameObject collectedHarvestParent;
        [Header("Player")]
        public PlayerComponent playerComponent;
        public Transform playerSpawnPosition;
        public CinemachineVirtualCamera virtualCamera;
        [Header("Настройка джойстика")]
        public Image joystickBack;
        public Image joystickInner;
        public float innerJoystickOffset = 15;
        [Header("Урожай")]
        public List<GameObject> plantsPositions;
        [Header("Корзина")]
        public Basket basket;
        public int _harvestInBasket = 0;
        public int maxHarvestInBasket = 10;
        [Header("Кнопки")]
        public bool startCutting = false;
        [Header("UI")]
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI basketSizeText;
        public float moneyAddSpeed = 0.5f;
        public Vector3 punchForce = new Vector3(.5f, .5f, .5f);
        [Header("Home")]
        public Home home;
        public List<int> coinsToCreate = new List<int>();
        public float Volume
        {
            get => _volume;
            set { _volume = value;}
        }
        public int Score { 
            get => _score;
            set { _score = value; scoreText.text = _score.ToString(); }   
        }
        public int HarvestInBasket
        {
            get => _harvestInBasket;
            set { _harvestInBasket = value; basketSizeText.text = $"{_harvestInBasket}/{maxHarvestInBasket}"; }
        }
        private void Start()
        {
            scoreText.text = _score.ToString();
            basketSizeText.text = $"{_harvestInBasket}/{maxHarvestInBasket}";
        }
        public void StartCutting()
        {
                startCutting = true;
        }

    }
}