var mapAsset : TextAsset;
var blockPrefab : GameObject;
var pelletPrefab : GameObject;
var superPrefab : GameObject;
var intersectionPrefab: Transform;
var terrain : Terrain;
var pacman : Transform;
var blueGhost : Transform;
var redGhost : Transform;
var greenGhost : Transform;
var orangeGhost : Transform;
var cookieFolder: GameObject;
var wallFolder: GameObject;
var ghostPenIntersection: Transform;
//http://www.tosos.com/PacManClone.zip
// D for door,
// G for ghost
// S for Pacman starting point
function Awake () {
    var map = mapAsset.text.Split ("\n"[0]);
    var v = new Vector3 ();
    v.y = 1.0;
    var j_off = terrain.terrainData.size.z / 2.0;
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
                
            } else if (map[j][i] == "I") {
            	Instantiate(intersectionPrefab, v, Quaternion.identity);
            	Instantiate (pelletPrefab, v, Quaternion.identity);
            } else if (map[j][i] == "P") {
            	Instantiate(ghostPenIntersection, v, Quaternion.identity);
            	Instantiate (pelletPrefab, v, Quaternion.identity);
            } else if (map[j][i] == "S") {
            	Instantiate (pacman, v, Quaternion.identity);
            } else if (map[j][i] == "G") {
            	//Instantiate (blueGhost, v, Quaternion.identity);
            	//Instantiate (redGhost, v, Quaternion.identity);
            	Instantiate (greenGhost, v, Quaternion.identity);
            	//Instantiate (orangeGhost, v, Quaternion.identity);
            }
        }
    }
}
