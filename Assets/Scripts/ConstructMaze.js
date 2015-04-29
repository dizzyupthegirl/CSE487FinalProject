var mapAsset : TextAsset;
var blockPrefab : Transform;
var pelletPrefab : Transform;
var superPrefab : Transform;

function Awake () {
    var map = mapAsset.text.Split ("\n"[0]);
    var v = gameObject.transform.position;
    v.y = 1.0;
    var j_off = map.length / 2.0;
    for (var j = 0; j < map.length; j ++) {
        v.z = (j - j_off) * 2 + 1;
        var i_off = map[j].length / 2.0;
        for (var i = 0; i < map[j].length; i ++) {
            v.x = (i - i_off) * 2 + 1;
            if (map[j][i] == "X") {
                var inst = Instantiate (blockPrefab, v, Quaternion.identity);
                inst.transform.parent = transform;
            } else if (map[j][i] == ".") {
                 var inst1 =Instantiate (pelletPrefab, v, Quaternion.identity);
                 inst1.transform.parent = transform;
            } else if (map[j][i] == "O") {
                 var inst2 =Instantiate (superPrefab, v, Quaternion.identity);
                 inst2.transform.parent = transform;
            }
        }
    }
}
