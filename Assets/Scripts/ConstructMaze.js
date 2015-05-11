var mapAsset : TextAsset;
var blockPrefab : GameObject;
var pelletPrefab : GameObject;
var superPrefab : GameObject;
var intersectionPrefab: Transform;
var terrain : Terrain;
var classicpacman : Transform;
var tonguepacman : Transform;
var tophatpacman : Transform;
var blueGhost : Transform;
var redGhost : Transform;
var greenGhost : Transform;
var orangeGhost : Transform;
var cookieFolder: GameObject;
var wallFolder: GameObject;
var ghostPenIntersection: Transform;
var chosenPacman: int;
//http://www.tosos.com/PacManClone.zip
// D for door,
// G for ghost
// S for Pacman starting point
// U for super cookie and intersection
function Awake () {
    //var map = mapAsset.text.Split ("\n"[0]);
    var map = "XXXXXXXXXXXXXXXXXXXXXXXXXXXX\nXO.IX   XI.IX   XI...I....OX\nX.X.X   X.X.X   X.XXX.XXXX.X\nXI.IIX  X.X.XXXXX.X X.X  X.X\nX.XX.XXXII.IP....IX X.X  X.X\nX.XXI...IXXXDDXXX.XXX.XXXX.X\nX.XX.XXX.X  G   XI...I...IIX\nXI..I..IIXXXXXXXX.XXX.XXX.XX\nXXXX.XX.XXXISI.IX.XXX.X X.XX\nX  X.XX.XXX.X.XI.I...IXXX.XX\nX  X.XXI.IXI.I.IXXXXXI...IXX\nXXXXI..IX.X.XXX.X   XXXXX.XX\nXI..IXXXX.X.XXX.X   XI.IX.XX\nX.XX.X  X.XI...IX   X.X.X.XX\nX.XX.X  X.X.XXX.XXXXXI.I.IIX\nX.XX.X XII.IXXXI.....IXXXX.X\nXI..IX X.XXI.IX.XXXXX.X  X.X\nX.XX.X X.XX.X.X.X   X.XXXX.X\nX.XX.XXX.XXI.IX.XXXXXI....IX\nXO..I...IXX.XXII.....IXXXX.X\nX.XX.XXX.XX.XX.XXXXXX.X  X.X\nX.XXI...IXX.XX.XXXXXX.XXXX.X\nXI..IXXXI..I..I......I....OX\nXXXXXXXXXXXXXXXXXXXXXXXXXXXX".Split ("\n"[0]);
    var v = new Vector3 ();
    v.y = 1.0;
    var j_off = terrain.terrainData.size.z / 2.0;
    try{
    chosenPacMan=gameObject.FindGameObjectWithTag("Selection").GetComponent("SelectPacMan").getChosen();
    }
    catch(err){
    	print("SelectPacMan script not found");
    }
    
    	
    for (var j = 0; j < map.length; j ++) {
        v.z = (terrain.terrainData.size.z - j - j_off - 1) * 2;
        var i_off = terrain.terrainData.size.x / 2.0;
        for (var i = 0; i < map[j].length; i ++) {
            v.x = (-1 * terrain.terrainData.size.x / 2 + i + i_off) * 2 + i_off/4;
            if (map[j][i] == "X") {
                var inst = Instantiate (blockPrefab, v, Quaternion.identity);
                inst.transform.parent = wallFolder.transform;
            } else if (map[j][i] == ".") {
                var cookie=Instantiate (pelletPrefab, v, Quaternion.identity);
                 cookie.transform.parent = cookieFolder.transform;
            } else if (map[j][i] == "O") {
                var supercookie=Instantiate (superPrefab, v, Quaternion.identity);
                supercookie.transform.parent=cookieFolder.transform;
                Instantiate(intersectionPrefab, v, Quaternion.identity);
               
            }else if (map[j][i] == "I") {
            	Instantiate(intersectionPrefab, v, Quaternion.identity);
        
            	var cookie2=Instantiate (pelletPrefab, v, Quaternion.identity);
            	cookie2.transform.parent = cookieFolder.transform;
            } else if (map[j][i] == "P") {
            	Instantiate(ghostPenIntersection, v, Quaternion.identity);
            	var cookie3=Instantiate (pelletPrefab, v, Quaternion.identity);
            	cookie3.transform.parent = cookieFolder.transform;
            } else if (map[j][i] == "S") {
            if(chosenPacMan==1){
            	Instantiate (tophatpacman, v, Quaternion.identity);
            	}
            	else if(chosenPacMan==2) {
            	Instantiate (tonguepacman, v, Quaternion.identity);
            	}
            	else{
            	Instantiate (classicpacman, v, Quaternion.identity);
            	}
            } else if (map[j][i] == "G") {
            	Instantiate (blueGhost, v, Quaternion.identity);
            	Instantiate (redGhost, v, Quaternion.identity);
            	Instantiate (greenGhost, v, Quaternion.identity);
            	Instantiate (orangeGhost, v, Quaternion.identity);
            }
        }
    }
}
