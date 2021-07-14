const uri = "https://localhost:5001/api/Approval";
const flowuri =
  "https://prod-31.southeastasia.logic.azure.com:443/workflows/34ab86c231d64c0ab244b65de56cdc7d/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=_GyfOBt8qug1EgLK7qwYZE9o1GD8pV2F55dlPTit6tM";

let approvals = [];
let updateIndex = 0;

function getApprovals() {
    let reqid=document.getElementById("reqid").value;
  $.ajax({
    url: uri+"/"+reqid,
    type: "GET",
    dataType: "json",
    success: function (data) {
      console.log(data);
      approvals.push(data);
      oapflow(data);
      //   _displayItems(data);
    },
    error: function (error) {
      console.log(`Error ${error}`);
    },
  });
}

function oapflow(data) {
//   alert(JSON.stringify(data));

  $.ajax({
    type: "POST",
    url: flowuri,
    data: JSON.stringify(data),
    contentType: "text/json; charset=utf-8",
    dataType: "text",
    success: function (response) {
      console.log(response);
    },
    error: function (result) {
      alert("msg");
    },
  });
}
