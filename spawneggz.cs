//Basic spawning method of eggs inside canvas

IEnumerator Spawn(){
    //get canvas component
		Canvas canvasComponent = GameObject.Find ("Canvas").GetComponent<Canvas> ();
		RectTransform recTrans = GameObject.Find ("Canvas").GetComponent<RectTransform> ();
    //Wait 2 seconds and show "start & go" on screen.
		GameObject go4= Instantiate (StartGo, new Vector3 (0, (recTrans.rect.height/2) - 250, 0), Quaternion.identity) as GameObject;
		go4.transform.SetParent (canvasComponent.gameObject.transform, false);
		yield return new WaitForSeconds(1);
		GameObject go3= Instantiate (StartGo2, new Vector3 (0, (recTrans.rect.height/2) - 250, 0), Quaternion.identity) as GameObject;
		go3.transform.SetParent (canvasComponent.gameObject.transform, false);
		yield return new WaitForSeconds(1);

		while (true) {
    //get positions for spawning eggs and bombs
			float pointX2 = (recTrans.rect.width / 2) - 30;
			float pointY2 = (recTrans.rect.height / 2) - 30;
			//bomb vector
			Vector3 spawnPosition2 = new Vector3 (Random.Range (-pointX2, pointX2), Random.Range (-pointY2, pointY2), 0);
			Quaternion spawnRotation2 = Quaternion.identity;
			
			while (i <randomInst && j==1) {
		  	float pointX = (recTrans.rect.width / 2) - 50;
	  		float pointY = (recTrans.rect.height / 2) - 30;
	  		//egg vector
		   	Vector3 spawnPosition = new Vector3 (Random.Range (-pointX, pointX), Random.Range (-pointY, pointY), 0);
		  	Quaternion spawnRotation = Quaternion.identity;
			
				GameObject go = Instantiate (egg, spawnPosition, spawnRotation) as GameObject;
				go.transform.SetParent (canvasComponent.gameObject.transform, false);
				
				//instantiate bomb
				i = i + 1;
				yield return new WaitForSeconds (0.2f);
				temptme = Time.time;
			}
			//make bomb
			if (Random.Range(1,20) > bombmake){
			//spawn bomb
				GameObject go2 = Instantiate (bomb, spawnPosition2, spawnRotation2) as GameObject;
				go2.transform.SetParent (canvasComponent.gameObject.transform, false);
			}
			j=0;
			//Instantiate bonus
			if (GameObject.Find(createNew) == null){
				j = 1 ;
				if (temptme > (Time.time-1)&& bonusHow == 0){
					GameObject go1= Instantiate (bonus, new Vector3 (0, (recTrans.rect.height/2) - 100, 0), Quaternion.identity) as GameObject;
					go1.transform.SetParent (canvasComponent.gameObject.transform, false);
					//add extra time and +score
					timead = timead +3;
					newScore sc = GameObject.Find("Score").GetComponent<newScore>();
					sc.Score=sc.Score + 500;
				}
			}
			yield return new WaitForSeconds (0.22f);
			i = 0;
			bonusHow=0;
		}
	}
