using Example.Scripts.Command;
using UnityEngine;
using UnityEngine.UI;

namespace Example.Scripts.UI
{
	public class GameStartPanel : MonoBehaviour
	{
		private void Start()
		{

			transform.Find("BtnStart").GetComponent<Button>().onClick.AddListener(() =>
			{
				gameObject.SetActive(false);

				new GameStartCommand().Execute();
			});
		}
	}
}