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
    var map = mapAsset.text.Split ("\n"[0]);
    var v = new Vector3 ();
    v.y = 1.0;
    var j_off = terrain.terrainData.size.z / 2.0;
    chosenPacMan=GameObject.FindGameObjectWithTag("Selection").GetComponent("SelectPacMan").ChosenPacMan;
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
                var ints=Instantiate(intersectionPrefab, v, Quaternion.identity);
                ints.transform.parent = cookieFolder.transform;
            }else if (map[j][i] == "I") {
            	var intersection=Instantiate(intersectionPrefab, v, Quaternion.identity);
            	intersection.transform.parent = cookieFolder.transform;
            	var cookie2=Instantiate (pelletPrefab, v, Quaternion.identity);
            	cookie2.transform.parent = cookieFolder.transform;
            } else if (map[j][i] == "P") {
            	var ghostPen=Instantiate(ghostPenIntersection, v, Quaternion.identity);
            	ghostPen.transform.parent = cookieFolder.transform;
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
