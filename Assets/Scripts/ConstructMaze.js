var mapAsset : TextAsset;
var blockPrefab : Transform;
var pelletPrefab : Transform;
var superPrefab : Transform;
var terrain : Terrain;
//http://www.tosos.com/PacManClone.zip
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
                inst.transform.parent = transform;
            } else if (map[j][i] == ".") {
                Instantiate (pelletPrefab, v, Quaternion.identity);
            } else if (map[j][i] == "O") {
                Instantiate (superPrefab, v, Quaternion.identity);
            }
        }
    }
}
