$.ajax({
    url: svcHeader + "findbytime",
    success: function (data) {

        PrizeList = data;
        console.log(PrizeList);

        for (var i = 0; i < PrizeList.length; i++) {
            // console.log(PrizeList[i]["photo"]);
            var imageUrl=imageHeader+PrizeList[i]["photo"]
            $("#bg2").append('<li style=" float:left;width: 50%;text-align: center;list-style-type: none;margin: 0px;padding: 0px;">'
                + '<span style=" display: block;color: #474747;font-size: 15px;line-height: 15px; margin-top: 10px;">'
                + '<img src='+imageUrl+' height="80" width="80">'
                + '<span>' + PrizeList[i]["name"] + '</span>'
                + '</li>'
            );
            nameList.push(PrizeList[i]["name"]);
        }

        finish();
    }


})

