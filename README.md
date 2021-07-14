```
[HttpGet]
        [Route("GetApprovals")]
        public IEnumerable<Approval> Get()
        {
            var approvals = new List<Approval>
         {
             new Approval { Id = 1, reqid = 1, level = "Level1", emailto = "baraneetharan.r@kgisl.com", emailcc = "pavithra.balan@kgisl.com", status = "A", iscompleted = "N" },
             new Approval { Id = 2, reqid = 1, level = "Level1", emailto = "pavithra.balan@kgisl.com", emailcc = "baraneetharan.r@kgisl.com", status = "A", iscompleted = "N" }
         };
            return approvals;
        }
```

```
const uri = "https://localhost:5001/api/Approval";
const flowuri="https://prod-31.southeastasia.logic.azure.com:443/workflows/34ab86c231d64c0ab244b65de56cdc7d/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=_GyfOBt8qug1EgLK7qwYZE9o1GD8pV2F55dlPTit6tM";

let approvals = [];
let updateIndex = 0;

function getApprovals() {
  $.ajax({
    url: uri,
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

function oapflow(data){
    alert(JSON.stringify(data));

  $.ajax({
    type: "POST",
    url: flowuri,
    data: JSON.stringify(data),
    success: function (response) {
        console.log(response)
    },
    error: function (result) {
      alert("msg");
    },
  });
}
```