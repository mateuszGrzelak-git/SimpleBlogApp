var cmd = '';
function clickHandle() {
    cmd += '    <input type=\"text\" id=\"blogContainment\" />';
    document.getElementById("moreBlogs").innerHTML = cmd;
}

var button = document.getElementById("submitButton").addEventListener("click", clickHandle);