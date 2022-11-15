using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UI;


public class RayParaHUD : MonoBehaviour
{
    //O gameobject OVERLAY � o objeto que ser� levado para a tela quando nosso mouse passar por cima de um collider
    public int camada=6;
    public GameObject overlay;
    //POSINICIAL � onde o objeto deve ir quando seu mouse n�o est� em cima de nada em particular
    private Vector3 posInicial;
    public TMP_Text nomePredio;
    public Image imagemPredio;
    public TMP_Text nivelPredio;
    public TMP_Text pricePredio;

    //OFFSET � um Vector3 usado para "arredar" a posi��o do nosso overlay, sen�o ele ficaria exatamente no centro do mouse
    //e n�o nos deixaria ver a constru��o
    [SerializeField]
    private Vector3 offset = new Vector3(95,110,0);

    private void Start()
    {
        //iniciamos PosInicial para algum lugar fora da tela
        posInicial = new Vector3(-1000,0,0);
    }

    void Update()
    {
        //Criamos um raycast e, caso ele colida com algo, enviamos as informa��es de colis�o para hit
        RaycastHit hit;
        //Nosso ray pega a posi��o do mouse na c�mera e o transforma em coordenadas X e Y
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Nosso ray bateu em algo 
        if (Physics.Raycast(ray, out hit))
        {
            GameObject go = hit.transform.gameObject;
            //Se o layer do objeto for 3... (obs.: em seu projeto, crie um layer para os objetos que voc� quer que recebam esse overlay)
            if (go.layer == camada) 
            {
                //...levamos nosso overlay at� esse objeto, com uma pequena diferen�a de posi��o que colocamos em OFFSET
                overlay.transform.position = Input.mousePosition + offset;
            } else
            {
                //do contr�rio escondemos o overlay novamente
                overlay.transform.position = posInicial;
            }
        }

        imagemPredio.sprite = GameController.Instance.predios[UIVariables.Instance.currentConst].UISpriteBuilding;
        nomePredio.text = GameController.Instance.predios[UIVariables.Instance.currentConst].nameBuilding;
        nivelPredio.text = GameController.Instance.predios[UIVariables.Instance.currentConst].nivel.ToString();
        if(GameController.Instance.predios[UIVariables.Instance.currentConst].nivel == 1){
            pricePredio.text = GameController.Instance.predios[UIVariables.Instance.currentConst].price.ToString();
        }
        if(GameController.Instance.predios[UIVariables.Instance.currentConst].nivel == 2){
            pricePredio.text = GameController.Instance.predios[UIVariables.Instance.currentConst].priceEvolution[0].ToString();
        }
        if(GameController.Instance.predios[UIVariables.Instance.currentConst].nivel == 3){
            pricePredio.text = GameController.Instance.predios[UIVariables.Instance.currentConst].priceEvolution[1].ToString();
        }

    }
}
