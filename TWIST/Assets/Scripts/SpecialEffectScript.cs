using UnityEngine;
using System.Collections;

public class SpecialEffectScript : MonoBehaviour {

	public static SpecialEffectScript Instance;

    private GameObject ManagerGO;
    private GameManager Manager;

    public ParticleSystem PassaroEffectPrefab;
    public ParticleSystem CrystalEffectPrefab;

    void Awake() {
	
		if (Instance != null) {
		
			Debug.LogError("Existem multiplas instancias do script SpecialEffectScript");

		}

		Instance = this;
	
	}

    void Start() {
        ManagerGO = GameObject.Find("GameManager");
        Manager = ManagerGO.GetComponent<GameManager>();
    }




    public void PassarosEffect(Vector3 position) {
        InstantiateParticleSystem(PassaroEffectPrefab, position);
    }


    public void CrystalEffect(Vector3 position)
    {
        InstantiateParticleSystem(CrystalEffectPrefab, position);
    }

    

	private ParticleSystem InstantiateParticleSystem(ParticleSystem prefab, Vector3 position) {

		ParticleSystem newParticleSystem = Instantiate (
			prefab,
			position,
			Quaternion.identity) as ParticleSystem;

		Destroy (newParticleSystem.gameObject, newParticleSystem.startLifetime);

        return GetComponent<ParticleSystem>();
    }

}
