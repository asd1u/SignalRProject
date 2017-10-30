var myHub;
function Initialize() {
	myHub = $.connection.myHub;
	myHub.client.alertFuncCl = function (mes) { alert(mes) };
	myHub.client.onSuccessfulLoginCl = onSuccessfulLoginImpl;
	$.connection.hub.start().done(hubStarted);
}

function hubStarted() {
	$('#btnLogin').click(logInCl);
	$('#tbLogin').val('qpIlIpp');
}

function replaceHtml(id, html) {
	$('#' + id).empty().append(html);
}

function logInCl() {
	myHub.server.logInSv($('#tbLogin').val(), $('#tbPassword').val());
}

function onSuccessfulLoginImpl() {
	myHub.server.getHtmlSv('menu').done(function (html) {
        replaceHtml('main', html);
	});
}

function changeContent(htmlTag) {
	myHub.server.getHtmlSv(htmlTag).done(function (html) {
		replaceHtml('cont', html);
	});
}

function changeContent1() {
	changeContent('cont1');
}
function changeContent2() {
	changeContent('cont2');
}
function changeContent3() {
    changeContent('cont3');
}
function changeContent4() {
    changeContent('showCars');
}


function alertAllCl() {
	myHub.server.alertAllSv('hello');
}

function rentCar(carId) {
    myHub.server.rentCar(carId);
}