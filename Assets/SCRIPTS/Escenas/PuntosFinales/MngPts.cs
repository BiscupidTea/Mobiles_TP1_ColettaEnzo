using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MngPts : MonoBehaviour 
{
	Rect R = new Rect();
	
	public float TiempEmpAnims = 2.5f;
	float Tempo = 0;
	
	public Vector2[] DineroPos;
	public Vector2 DineroEsc;
	public GUISkin GS_Dinero;
	
	public Vector2 GanadorPos;
	public Vector2 GanadorEsc;
	public Texture2D[] Ganadores;
	public GUISkin GS_Ganador;
	
	public GameObject Fondo;
	
	public float TiempEspReiniciar = 10;
	
	
	public float TiempParpadeo = 0.7f;
	float TempoParpadeo = 0;
	bool PrimerImaParp = true;
	
	public bool ActivadoAnims = false;
	
	Visualizacion Viz = new Visualizacion();

	public Image winnnerText;
	public Sprite winnner1;
	public Sprite winnner2;

	public TextMeshProUGUI Player1;
	public TextMeshProUGUI Player2;
	
	//---------------------------------//
	
	// Use this for initialization
	void Start () 
	{		
		SetGanador();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//PARA JUGAR
		if(Input.GetKeyDown(KeyCode.Space) || 
		   Input.GetKeyDown(KeyCode.Return) ||
		   Input.GetKeyDown(KeyCode.Alpha0))
		{
			SceneManager.LoadScene(0);
		}
		
		//CIERRA LA APLICACION
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}		
		
		
		TiempEspReiniciar -= Time.deltaTime;
		if(TiempEspReiniciar <= 0 )
		{
			SceneManager.LoadScene(0);
		}
		
		
		
		
		if(ActivadoAnims)
		{
			TempoParpadeo += Time.deltaTime;
			
			if(TempoParpadeo >= TiempParpadeo)
			{
				TempoParpadeo = 0;
				
				if(PrimerImaParp)
					PrimerImaParp = false;
				else
				{
					TempoParpadeo += 0.1f;
					PrimerImaParp = true;
				}
			}
		}
		
		
		
		if(!ActivadoAnims)
		{
			Tempo += Time.deltaTime;
			if(Tempo >= TiempEmpAnims)
			{
				Tempo = 0;
				ActivadoAnims = true;
			}
		}
		
		
	}
	
	void OnGUI()
	{
		if(ActivadoAnims)
		{
			SetDinero();
			SetCartelGanador();
		}
		
		GUI.skin = null;
	}
	
	//---------------------------------//
	
	
	void SetGanador()
	{
		switch(DatosPartida.LadoGanadaor)
		{
		case DatosPartida.Lados.Der:
			
			GS_Ganador.box.normal.background = Ganadores[1];
			
			break;
			
		case DatosPartida.Lados.Izq:
			
			GS_Ganador.box.normal.background = Ganadores[0];
			
			break;
		}
	}
	
	void SetDinero()
	{
		if (DatosPartida.LadoGanadaor == DatosPartida.Lados.Izq)
		{
            Player1.text = DatosPartida.PtsGanador.ToString();
            Player2.text = DatosPartida.PtsPerdedor.ToString();
        }
		else
		{
            Player1.text = DatosPartida.PtsPerdedor.ToString();
            Player2.text = DatosPartida.PtsGanador.ToString();
        }		
	}
	
	void SetCartelGanador()
	{
		if (DatosPartida.LadoGanadaor == DatosPartida.Lados.Izq)
		{
			winnnerText.sprite = winnner1;
		}
		else
		{
			winnnerText.sprite = winnner2;
        }
    }
	
	public void DesaparecerGUI()
	{
		ActivadoAnims = false;
		Tempo = -100;
	}
}
