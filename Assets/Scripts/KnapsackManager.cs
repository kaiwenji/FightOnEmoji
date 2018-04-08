using System.Collections;
using UnityEngine;
using System.Collections.Generic;
public class KnapsackManager : MonoBehaviour {
	private Dictionary<int,Item> ItemList=new Dictionary<int,Item>();
	private static KnapsackManager _instance;
	public static KnapsackManager Instance{ get { return _instance; } }
	public GridPanelUI GridPanelUI;
	void Awake(){
		
		_instance = this;
		load ();

	}
	public void StoreItem(int itemId){
		string itemname = "";
		if (!ItemList.ContainsKey (itemId)){
			return;
		}
		if (itemId == 0) {
			itemname = "fly";
		}
		if (itemId == 1) {
			itemname = "medicine";
		}
		Transform emptyGrid = GridPanelUI.Instance.GetEmptyGrid ();
		if (emptyGrid == null) {
			Debug.LogWarning ("the backpack is full！");
			return;
		}
		//print ("NONE");
		Item temp = ItemList [itemId];
		GameObject itemPrefab=Resources.Load<GameObject> ("Prefabs/Item");
		itemPrefab.GetComponent<ItemUI> ().UpdateImage (temp.Icon);
		GameObject itemGo=GameObject.Instantiate (itemPrefab);
		itemGo.transform.SetParent (emptyGrid);
		itemGo.transform.localPosition = Vector3.zero;
		itemGo.transform.localScale = Vector3.one;
		itemGo.GetComponent<UseTool> ().itemname = itemname;
	}
	private void load(){
		ItemList = new Dictionary<int, Item>();
		Item a1 = new Item (0, Resources.Load("Image/fly", typeof(Sprite)) as Sprite);
		Item a2 = new Item (1,  Resources.Load("Image/medicine", typeof(Sprite)) as Sprite);
		ItemList.Add (a1.Id, a1);
		ItemList.Add (a2.Id, a2);


	}
}
