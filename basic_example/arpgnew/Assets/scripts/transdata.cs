 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transdata {
	private static transdata _Instance;
	public int have;
	public string Name;

		public static transdata Instance{
		get{ 
			if (_Instance == null) {
				_Instance = new transdata ();	
			}
			return _Instance;
		 }
		}

}
