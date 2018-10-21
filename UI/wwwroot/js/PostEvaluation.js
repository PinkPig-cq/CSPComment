window.onload = function () {
    var total_oStar = document.getElementById("total_star");
    var total_lbl = document.getElementById("total_lbl");
    var total_aLi = total_oStar.getElementsByTagName("li");

    var performance_star = document.getElementById("performance_star");
    var performance_lbl = document.getElementById("performance_lbl");
    var performance_aLi = performance_star.getElementsByTagName("li");

    var service_star = document.getElementById("service_star");
    var service_lbl = document.getElementById("service_lbl");
    var service_aLi = service_star.getElementsByTagName("li");

    var i = iScore = iStar = 0;
    for (i = 1; i <= total_aLi.length; i++) {

        total_aLi[i - 1].index = i;
        //鼠标移过显示分数
        total_aLi[i - 1].onmouseover = function () {
            fnPoint(this.index, total_aLi, total_lbl);
        };
        //鼠标离开后恢复上次评分
        total_aLi[i - 1].onmouseout = function () {
            fnPoint(iStar, total_aLi, total_lbl);
        };
        //点击后进行评分处理
        total_aLi[i - 1].onclick = function () {
            iStar = this.index;
            document.getElementById("sGrade").value = this.index;
        }
    }
    for (i = 1; i <= performance_aLi.length; i++) {

        performance_aLi[i - 1].index = i;
        //鼠标移过显示分数
        performance_aLi[i - 1].onmouseover = function () {
            fnPointNum(this.index, performance_aLi, performance_lbl);
        };
        //鼠标离开后恢复上次评分
        performance_aLi[i - 1].onmouseout = function () {
            fnPointNum(iStar, performance_aLi, performance_lbl);
        };
        //点击后进行评分处理
        performance_aLi[i - 1].onclick = function () {
            iStar = this.index;
        }
    }
    for (i = 1; i <= service_aLi.length; i++) {

        service_aLi[i - 1].index = i;
        //鼠标移过显示分数
        service_aLi[i - 1].onmouseover = function () {
            fnPointNum(this.index, service_aLi, service_lbl);
        };
        //鼠标离开后恢复上次评分
        service_aLi[i - 1].onmouseout = function () {
            fnPointNum(iStar, service_aLi, service_lbl);
        };
        //点击后进行评分处理
        service_aLi[i - 1].onclick = function () {
            iStar = this.index;
        }
    }

    function fnPointNum(iArg, arr, lable) {
        //分数赋值
        iScore = iArg || iStar;
        for (var i = 0; i < arr.length; i++) {
            arr[i].getElementsByTagName("a")[0].className = i < iScore ? "onNum" : "";
        };
        switch (iScore) {
            case 1:
                lable.innerHTML = "不满意";
                break;
            case 2:
                lable.innerHTML = "一般";
                break;
            case 3:
                lable.innerHTML = "不错";
                break;
            case 4:
                lable.innerHTML = "满意";
                break;
            case 5:
                lable.innerHTML = "超赞";
                break;
        }
    }
    //评分处理
    function fnPoint(iArg, arr, lable) {
        //分数赋值
        iScore = iArg || iStar;
        for (var i = 0; i < arr.length; i++) {
            arr[i].className = i < iScore ? "on" : "";
        };
        switch (iScore) {
            case 1:
                lable.innerHTML = "不满意";
                break;
            case 2:
                lable.innerHTML = "一般";
                break;
            case 3:
                lable.innerHTML = "不错";
                break;
            case 4:
                lable.innerHTML = "满意";
                break;
            case 5:
                lable.innerHTML = "超赞";
                break;
        }
    }
};