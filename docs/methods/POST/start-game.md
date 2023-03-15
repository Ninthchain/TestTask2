<h1>StartGame</h1>

<h2>Info</h2>
<p>The methods creates <b>POST</b> request to start game. It includes creation and insertion session info into database </p>

<h4>Params</h4>
<span>id1</span> : <em><b style = "color: #017dc1">INT</b></em> - <b>The player 1 id</b>
<span>id2</span> : <em><b style = "color: #017dc1">INT</b></em> - <b>The player 2 id</b>

<h4>Examples</h4>

<table>
    <thead>
        <tr>
            <th>Request</th>
            <th>Response</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td><b style="color: #2a9bda" >POST</b> /GameApi/StartGame-<b>id1=</b>44&<b>id2=</b>44</td>
            <td><p>{<br>"contentType": null,"serializerSettings": null,"statusCode": 200,
  <br>"value": <br>{<br>
    "gameId": "DSWYHCQIIA",
    "id1Token": "X",
    "id2Token": "O"
  }<br></p>
}</td>
        </tr>
        <tr>
            <td><b style="color: #2a9bda">POST</b> /GameApi/StartGame-<b>id1</b>=33&<b>id2</b>=33</td>
            <td>{
                "contentType": null,
                "serializerSettings": null,
                "statusCode": 400,
                "value": "Error: The ids must be different"
              }</td>
        </tr>
    </tbody>
</table>
