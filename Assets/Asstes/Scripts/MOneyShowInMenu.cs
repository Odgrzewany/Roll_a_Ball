using UnityEngine;

public class MOneyShowInMenu : MonoBehaviour {

    public UnityEngine.UI.Text CashShowerMenu;

    void Update () {
        CashShowerMenu.text = "$:" + Manager.Instance.Cash;
	}
}
