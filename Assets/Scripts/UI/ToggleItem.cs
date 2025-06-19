using UnityEngine;
using UnityEngine.UI;

public class ToggleItem : MonoBehaviour{

    [SerializeField] private Image selectedImage;


    public void SetSprite(Sprite sprite){
        selectedImage.sprite = sprite;
    }

    private void Start(){
        
    }

    private void Update(){
        
    }

}
