var myHub;
function Initialize() {
	myHub = $.connection.myHub;
	myHub.client.alertFuncCl = function (mes) { alert(mes) };
	myHub.client.onSuccessfulLoginCl = onSuccessfulLoginImpl;
	$.connection.hub.start().done(hubStarted);
}

function hubStarted() {
   
}

function replaceHtml(id, html) {
	$('#' + id).empty().append(html);
}

function logInCl() {
	myHub.server.logInSv($('#tbLogin').val(), $('#tbPassword').val());
}

function Registr() {
    myHub.server.getHtmlSv('reg').done(function (html) {
    replaceHtml('main', html);
    });

}

function showLogin() {
    myHub.server.getHtmlSv('showLogin').done(function (html) {
        replaceHtml('main', html);
    });
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
function reg() {
    myHub.server.registr($('#tbLogin').val(), $('#tbPassword').val(), $('#tbName').val(), $('#tbFname').val(), $('#tbOname').val());
}

function exit() {
    myHub.server.getHtmlSv('menu').done(function (html) {
        replaceHtml('reg', html);
    });;
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