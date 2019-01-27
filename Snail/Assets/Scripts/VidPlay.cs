using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class VidPlay : MonoBehaviour
{
	public string nextScene = "snail0";

	public float vidLength = 16.0f;

	VideoPlayer vid;

	float vidTime = 0.0f;

    void Start()
    {
        vid = GetComponent<UnityEngine.Video.VideoPlayer>();
        vid.Play();
    }

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		vidTime += Time.deltaTime;
		if ((vidTime > vidLength) || Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadSceneAsync(nextScene);
		}
	}
}