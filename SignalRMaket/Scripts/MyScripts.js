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

function showCars() {
    myHub.server.getHtmlSv('showCars').done(function (html) {
        replaceHtml('main', html);
    });
}

function onSuccessfulLoginImpl() {

    myHub.server.getHtmlSv('user').done(function (html) {
        replaceHtml('buttonlogin', html);
    });

	myHub.server.getHtmlSv('menu').done(function (html) {
        replaceHtml('main', html);
    });
    
}
function showMain() {
    myHub.server.getHtmlSv('menu').done(function (html) {
        replaceHtml('main', html);
    });
}

function showMenupolzSdan() {
    myHub.server.getHtmlSv('menupolzSdan').done(function (html) {
        replaceHtml('main', html);
    });
}


function showOnas() {
    myHub.server.getHtmlSv('Onas').done(function (html) {
        replaceHtml('main', html);
    });
}


function showContact() {
    myHub.server.getHtmlSv('contact').done(function (html) {
        replaceHtml('main', html);
    });
}

function showReg() {
    myHub.server.getHtmlSv('showReg').done(function (html) {
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

function alertAllCl() {
	myHub.server.alertAllSv('hello');
}

function rentCar(carId) {
    myHub.server.rentCar(carId);
}