using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using TMPro;
using Unity.Networking.Transport.Relay;
using Unity.Netcode.Transports.UTP;

public class RelayScript : MonoBehaviour
{
	[SerializeField] private GameObject input;
	[SerializeField] private GameObject createBut;
	[SerializeField] private GameObject joinBut;
	
	private async void Start(){
		await UnityServices.InitializeAsync();
		
		AuthenticationService.Instance.SignedIn += () => {
			Debug.Log("Signed In " + AuthenticationService.Instance.PlayerId);
		};
		await AuthenticationService.Instance.SignInAnonymouslyAsync();
	}
	
	public async void createRelay(){
		try {
			input.SetActive(false);
			createBut.SetActive(false);
			joinBut.SetActive(false);
			
			Allocation alloc = await RelayService.Instance.CreateAllocationAsync(2);
			
			string joinCode = await RelayService.Instance.GetJoinCodeAsync(alloc.AllocationId);
			Debug.Log("Relay join code: " + joinCode);
			
			RelayServerData relayServerData = new RelayServerData(alloc, "dtls");
			NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);
			NetworkManager.Singleton.StartHost();
			
		} catch(RelayServiceException e){
			Debug.Log(e);
		}
	}
	
	public async void joinRelay(){
		try {
			string code = input.GetComponent<TMP_InputField>().text;
			Debug.Log(code);
			input.SetActive(false);
			createBut.SetActive(false);
			joinBut.SetActive(false);
			
			Debug.Log("Joining Relay with code : " + code);
			JoinAllocation joinAlloc = await RelayService.Instance.JoinAllocationAsync(code);
			
			RelayServerData relayServerData = new RelayServerData(joinAlloc, "dtls");
			NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);
			NetworkManager.Singleton.StartClient();
			
		} catch (RelayServiceException e){
			Debug.Log(e);
		}
	}
}
