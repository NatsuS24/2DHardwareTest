using UnityEngine;
using System.Collections;
using System;

public class KPController : MonoBehaviour {
	private ArrayList ControllerUsers;

	void Awake(){
		this.ControllerUsers = new ArrayList();
	}

	void Start(){


	}

	void Update(){

		KPControlMagnitude mag = KPControlMagnitude.None;
		KPControlDirection dir = KPControlDirection.None;
		int pressure = PressureToInt();

		/* Foward Verticle */
		if (Input.GetKey (KeyCode.A)){
			dir = KPControlDirection.Up;
			mag = KPControlMagnitude.Slow;
		} else if (Input.GetKey (KeyCode.B)){
			dir = KPControlDirection.Up;
			mag = KPControlMagnitude.Medium;
		} else if (Input.GetKey (KeyCode.C)){
			dir = KPControlDirection.Up;
			mag = KPControlMagnitude.Fast;
		} 

		/* Diagonal Right Up */
		else if (Input.GetKey (KeyCode.D)){
			dir = KPControlDirection.DiagonalUpRight;
			mag = KPControlMagnitude.Slow;
		} else if (Input.GetKey (KeyCode.E)){
			dir = KPControlDirection.DiagonalUpRight;
			mag = KPControlMagnitude.Medium;
		} else if (Input.GetKey (KeyCode.F)){
			dir = KPControlDirection.DiagonalUpRight;
			mag = KPControlMagnitude.Fast;
		} 

		/* Right */
		else if (Input.GetKey (KeyCode.G)){
			dir = KPControlDirection.Right;
			mag = KPControlMagnitude.Slow;
		} else if (Input.GetKey (KeyCode.H)){
			dir = KPControlDirection.Right;
			mag = KPControlMagnitude.Medium;
		} else if (Input.GetKey (KeyCode.I)){
			dir = KPControlDirection.Right;
			mag = KPControlMagnitude.Fast;
		}

		/* Diagonal Right Down */
		else if (Input.GetKey (KeyCode.J)){
			dir = KPControlDirection.DiagonalDownRight;
			mag = KPControlMagnitude.Slow;
		} else if (Input.GetKey (KeyCode.K)){
			dir = KPControlDirection.DiagonalDownRight;
			mag = KPControlMagnitude.Medium;
		} else if (Input.GetKey (KeyCode.L)){
			dir = KPControlDirection.DiagonalDownRight;
			mag = KPControlMagnitude.Fast;
		}

		/* Down */
		else if (Input.GetKey (KeyCode.M)){
			dir = KPControlDirection.Down;
			mag = KPControlMagnitude.Slow;
		} else if (Input.GetKey (KeyCode.N)){
			dir = KPControlDirection.Down;
			mag = KPControlMagnitude.Medium;
		} else if (Input.GetKey (KeyCode.O)){
			dir = KPControlDirection.Down;
			mag = KPControlMagnitude.Fast;
		}

		/* Digonal Left Down */
		else if (Input.GetKey (KeyCode.P)){
			dir = KPControlDirection.DiagonalDownLeft;
			mag = KPControlMagnitude.Slow;
		} else if (Input.GetKey (KeyCode.Q)){
			dir = KPControlDirection.DiagonalDownLeft;
			mag = KPControlMagnitude.Medium;
		} else if (Input.GetKey (KeyCode.R)){
			dir = KPControlDirection.DiagonalDownLeft;
			mag = KPControlMagnitude.Fast;
		}
		/* Left */
		else if (Input.GetKey (KeyCode.S)){
			dir = KPControlDirection.Left;
			mag = KPControlMagnitude.Slow;
		} else if (Input.GetKey (KeyCode.T)){
			dir = KPControlDirection.Left;
			mag = KPControlMagnitude.Medium;
		} else if (Input.GetKey (KeyCode.U)){
			dir = KPControlDirection.Left;
			mag = KPControlMagnitude.Fast;
		}

		/* Diagonal left up */
		else if (Input.GetKey (KeyCode.V)){
			dir = KPControlDirection.Left;
			mag = KPControlMagnitude.Slow;
		} else if (Input.GetKey (KeyCode.W)){
			dir = KPControlDirection.Left;
			mag = KPControlMagnitude.Medium;
		} else if (Input.GetKey (KeyCode.X)){
			dir = KPControlDirection.Left;
			mag = KPControlMagnitude.Fast;
		}

		this.SendInputMessage(new KPControlComponent(dir, mag, pressure));

	}
	

	public void SetControllerUser(IKPController controllerUser){
		this.ControllerUsers.Add (controllerUser);
	}


	private void SendInputMessage(KPControlComponent component){
		foreach (object player in this.ControllerUsers){
			((IKPController) player).GetInputFromControl(component);

		}
	}

	private int PressureToInt(){
		if (Input.GetKey (KeyCode.Alpha0)) return 1;
		else if (Input.GetKey (KeyCode.Alpha1)) return 2;
		else if (Input.GetKey (KeyCode.Alpha2)) return 3;
		else if (Input.GetKey (KeyCode.Alpha3)) return 4;
		else if (Input.GetKey (KeyCode.Alpha4)) return 5;
		else if (Input.GetKey (KeyCode.Alpha5)) return 6;
		else if (Input.GetKey (KeyCode.Alpha6)) return 7;
		else if (Input.GetKey (KeyCode.Alpha7)) return 8;
		else if (Input.GetKey (KeyCode.Alpha8)) return 9;
		else if (Input.GetKey (KeyCode.Alpha9)) return 10;
		else if (Input.GetKey (KeyCode.Z)) return 11;
		return 0;
	}	

}



public enum KPControlMagnitude {
	Fast,
	Medium,
	Slow,
	None
};

public enum KPControlDirection {
	Up,
	Right,
	Down,
	Left,
	DiagonalUpRight,
	DiagonalUpLeft,
	DiagonalDownRight,
	DiagonalDownLeft,
	None
};

public class KPControlComponent{
	private KPControlDirection direction;
	private KPControlMagnitude magnitude;
	private int pressure;

	public KPControlComponent(KPControlDirection dir, KPControlMagnitude mag, int pressureVal){
		this.direction = dir;
		this.magnitude = mag;
		this.pressure = pressureVal;
	}

	public KPControlDirection Direction {
		get { return this.direction; }
	}
	public KPControlMagnitude Magnitude {
		get { return this.magnitude ;} 
	}
	public int Pressure {
		get { return this.pressure; }
	}
}







