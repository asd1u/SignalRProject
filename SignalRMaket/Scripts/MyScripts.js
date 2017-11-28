var myHub;
function Initialize() {  
    myHub = $.connection.myHub;
    myHub.client.alertFuncCl = function (mes) { alert(mes) };
    myHub.client.onSuccessfulLoginCl = onSuccessfulLoginImpl;
    myHub.client.showMenupolzSdan = function () { showMenupolzSdan() };
    myHub.client.showMenupolzZakaz = function () { showMenupolzZakaz() };
    myHub.client.showMenuTablpolz = function () { showMenuTablpolz() };
    myHub.client.showMenuAllAuto = function () { showMenuAllAuto() };
    $.connection.hub.start().done(hubStarted).done(function () {
        myHub.server.getHtmlSv('menu').done(function (html) {
            replaceHtml('main', html);
        });
    });
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

    myHub.server.getHtmlSvPolz('user').done(function (html) {
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
    myHub.server.getHtmlSvPolz('menupolzSdan').done(function (html) {
        replaceHtml('main', html);
    });
}
function showMenuAllAuto() {
    myHub.server.getHtmlSv('showCars').done(function (html) {
        replaceHtml('main', html);
    });
}


function showMenupolzZakaz() {
    myHub.server.getHtmlSvPolz('menupolzZakaz').done(function (html) {
        replaceHtml('main', html);
    });
}
function showMenuTablpolz() {
    myHub.server.getHtmlSv('menuTablpolz').done(function (html) {
        replaceHtml('main', html);
    });
}
function addAuto() {
    myHub.server.addauto( $('#tbmodel').val(), $('#tbOpis').val(), $('#tbStoim').val(), $('#tbFile').val());
   
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
    location.reload(true);
}

function alertAllCl() {
	myHub.server.alertAllSv('hello');
}

function rentCar(carId) {
  myHub.server.rentCar(carId, $('#hourSelector').val());
}

function delCar(carId) {
    myHub.server.deltCar(carId);
}

function delPolz(userId) {
    myHub.server.deltPolz(userId);
}


function Otziv(carId, zakId) {
    $('#idAuto').text(carId);
    $('#idZak').text(zakId);
}
function Profil(userId, userLogin, userName, userFname, userOname, userStatus)
{
    document.getElementById('Userid').value = userId;
    document.getElementById('inLogin').value = userLogin;
    document.getElementById('inPassword').value = "";
    document.getElementById('inName').value = userName;
    document.getElementById('inFname').value = userFname;
    document.getElementById('inOname').value = userOname;
    if (userStatus)
        document.getElementById('inStatus').value = "Администратор";
    else
        document.getElementById('inStatus').value = "Пользователь";
    
}


function readCarSave(carId, model, marka, opis, stoim)
{
    document.getElementById('carId').value = carId;
    document.getElementById('inModel').value = model + " " + marka;
    document.getElementById('inMod').value = model;
    document.getElementById('inMark').value = marka;
    document.getElementById('inOpis').value = opis;
    document.getElementById('inStoim').value = stoim;
    //document.getElementById('inFile').value = file;


}

function saveProfil() {
    myHub.server.sVP(
        $('#Userid').val(),
        $('#inLogin').val(),
        $('#inPassword').val(),
        $('#inName').val(),
        $('#inFname').val(),
        $('#inOname').val(),
        $('#inStatus').val() );
}
function changAuto() {
    myHub.server.cngAuto(
        $('#carId').val(),
        $('#inMod').val(),
        $('#inMark').val(),
        $('#inOpis').val(),
        $('#inStoim').val(),
        $('#inFile').val(), );
}

function saveOtziv(carId , zakId) {
    myHub.server.saveOtziv(carId, zakId, $('#tbrait').val(), $('#tbText').val());
}
    

function showCar(carId) {
    myHub.server.getHtmlWithIdSv('showCar',carId).done(function (html) {
        replaceHtml('main', html);
    });

}










function filterCars() {
    myHub.server.getHtmlFilterCars('', $('#dost').is(':checked'), $('#minPrice').val(), $('#maxPrice').val()).done(function (html) {
        replaceHtml('allcars', html);
    });
} 