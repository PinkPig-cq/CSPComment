    //评分处理
    function fnPoint(iArg, arr) {
        //分数赋值
        iScore = iArg || iStar;
        for (var i = 0; i < arr.length; i++) {
            arr[i].src = i < iScore ? "/images/star24_on@2x.png" : "/images/star24_off@2x.png";
        };
    }
