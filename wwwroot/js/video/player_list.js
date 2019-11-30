showList();

$('#show').click(function () {
    var text = $('#addList').val();
    console.log('text=' + text);
    addList(text);
    showList(text);
    showVideo(text);
});

function showList() {
    var html = '';
    var urls = getUrls();
    for (var i in urls) {
        html += '<option value = "' + urls[i] + '"/>';//<option value = "VVO" label="qwe"/>
    }
    $('#airports').html(html);
}

function addList(url) {
    console.log('url=' + url);
    if (url == '')
        return;
    var urls = getUrls();
    if (urls.indexOf(url) == -1) {
        urls.push(url)
    }
    
    Cookies.set('urls', JSON.stringify(urls));
    console.log('urls = ' + JSON.stringify(urls));
}

function showVideo(url) {

}

function getUrls() {
    var urls = [];
    if (Cookies.get('urls') != null && Cookies.get('urls') != '') {
        urls = JSON.parse(Cookies.get('urls'));
    }

    return urls;
}
